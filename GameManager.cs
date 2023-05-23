using Comora;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

public class GameManager
{
    //variabler o sånt
    private Map _map;
    private GraphicsDevice _device;
    public player Player;
    private Camera camera;
    private Random rnd = new Random();
    trappa Trappa = new trappa(new(6, 6));
    bool ScreenShown, GameStarted;
    Button StartButton, HelpButton, BackButton;
    

    public GameManager(GraphicsDevice gd)
    {
        // initiera
        ScoreManager.CheckFile();
        StartButton = new Button(new Vector2(370, 135), "Start");
        HelpButton = new Button(new Vector2(420, 225), "Help");
        BackButton = new Button(new Vector2(500, 400), "Tillbaka");
        

        _map = new Map(new(20, 20));
        Player = new(new(Globals.TileSize.X, Globals.TileSize.Y));
        Player.SetBounds(_map.MapSize, _map.TileSize);
        Globals.BonkList = new List<IBonkable>();
        Globals.WinPos = new Vector2(
            rnd.Next(Globals.MapSize.X / Globals.TileSize.X),
            rnd.Next(Globals.MapSize.Y / Globals.TileSize.Y)
        );
        _device = gd;
        this.camera = new(_device);
        Trappa.Position = Globals.WinPos;

        //Exempel stenar

        Globals.BonkList.Add(new Sten(new(Globals.TileSize.X * 6, Globals.TileSize.Y * 6)));
        Globals.BonkList.Add(new ArgSten(new(Globals.TileSize.X * 6, Globals.TileSize.Y * 9)));

        Globals.BonkList.Add(new Sten(new(Globals.TileSize.X * 3, Globals.TileSize.Y * 3)));
        Globals.BonkList.Add(new Sten(new(Globals.TileSize.X * 4, Globals.TileSize.Y * 3)));
        Globals.BonkList.Add(new Sten(new(Globals.TileSize.X * 5, Globals.TileSize.Y * 3)));

    }


    private void Init()
    {
        //Init gör en ny bana med en annan storlek av bana och ett antal stenar.

        Globals.BonkList.Clear();
        
        
        //Lägg till stenar beroende på vilken bana man är på.

        for (int i = 0; i != Globals.Level; i++)
        {
            Globals.BonkList.Add(
                new Sten(
                    new(
                        Globals.TileSize.X * rnd.Next(1, (Globals.MapSize.X / 64) - 1),
                        Globals.TileSize.Y * rnd.Next(1, (Globals.MapSize.Y / 64) - 1)
                    )
                )
            );
            Globals.BonkList.Add(
                new Sten(
                    new(
                        Globals.TileSize.X * rnd.Next(1, (Globals.MapSize.X / 64) - 1),
                        Globals.TileSize.Y * rnd.Next(1, (Globals.MapSize.Y / 64) - 1)
                    )
                )
            );

            Globals.BonkList.Add(
                new ArgSten(
                    new(
                        Globals.TileSize.X * rnd.Next(1, (Globals.MapSize.X / 64) - 1),
                        Globals.TileSize.Y * rnd.Next(1, (Globals.MapSize.Y / 64) - 1)
                    )
                )
            );
        }
        // skapa bana, sppelare och trappa

        _map = new Map(new(rnd.Next(20, 30), rnd.Next(20, 30)));
        Player = new(new(Globals.TileSize.X, Globals.TileSize.Y));
        Player.SetBounds(_map.MapSize, _map.TileSize);
        Globals.WinPos = new Vector2(
            rnd.Next(Globals.MapSize.X / Globals.TileSize.X),
            rnd.Next(Globals.MapSize.Y / Globals.TileSize.Y)
        );
        Trappa.Position = Globals.WinPos;
    }

    public void Update(GameTime gt)
    {
        //Uppdatera allting

        if (Globals.Lose)
            return;

        InputManager.Update();
        Player.Update();

        //även arga stenar uppdateras pga. polymorfism
        foreach (Sten sten in Globals.BonkList.OfType<Sten>().ToList())
        {
            sten.Update();
            if (sten.Position / 64 == Globals.WinPos)
            {
                // döda sten och ge poäng om stenen ligger på trappan
                Globals.BonkList.Remove(sten);
                Globals.Stones++;
            }
        }

        //kamera saker
        this.camera.Update(gt);
        this.camera.Position = Player.Position;
        Vector2 minpos = Globals.WindowSize.ToVector2() / 2;
        Vector2 maxpos =
            new(
                Globals.MapSize.X - (Globals.WindowSize.X / 2),
                Globals.MapSize.Y - Globals.WindowSize.Y / 2
            );
        camera.Position = Vector2.Clamp(camera.Position, minpos, maxpos);

        

        // Gå till nästa bana
        if ((Globals.PlayerPos / 64) == Globals.WinPos)
        {
            Init();
            Globals.Level++;
        }
    }

    public void StartScreen()
    {
        //visa startskärmen

        Globals.spriteBatch.Draw(Globals.StartScreen, new Rectangle(0,0,Globals.WindowSize.X, Globals.WindowSize.Y), Color.White);
        Globals.spriteBatch.DrawString(Globals.font, "CobbleCat", new Vector2(Globals.WindowSize.X / 2 - 50, 10), Color.White);


        HelpButton.Update();
        HelpButton.Draw();

        StartButton.Update();
        StartButton.Draw();

        //if (HelpButton.Clicked) TutorialText();
        if (StartButton.Clicked) GameStarted = true;
        
        Globals.spriteBatch.End();
    }

    public void Lose()
    {
        int score = Globals.Level * Globals.Stones;

        if (!ScreenShown) ScoreManager.SaveScore(score);
        

        //Rensa allt. se till att man inte kan göra något i bakgrunden och visa poäng.
       

        //standardisera förutsättningar när man dör.
        _device.Clear(Color.Black);
        camera.Position = new Vector2(0, 0);

        Globals.spriteBatch.Begin();
        Globals.spriteBatch.DrawString(Globals.font, "You Lose", camera.Position, Color.White);
        Globals.spriteBatch.DrawString(
            Globals.font,
            String.Format(
                "Score: levels {0} * stones {1} = {2} Points",
                Globals.Level,
                Globals.Stones,
                score
            ),
            camera.Position + new Vector2(0, 50),
            Color.White
        );
        
        //List<string> ScoresString = new List<string>();
        string s = "";

        for (int i = 0; i < ScoreManager.GetScores().Count; i++)
        {
            s += String.Format("{0}.  {1} pts.\r\n", (i + 1).ToString(), ScoreManager.GetScores()[i].ToString());
        }

       

        Globals.spriteBatch.DrawString(
            Globals.font,
            s,
            camera.Position + new Vector2(0, 100),
            Color.White);



        Globals.spriteBatch.End();
        ScreenShown = true;

    }

    private void TutorialLevel()
    {
        
        Globals.spriteBatch.Draw(Globals.TeacherCat, new Rectangle(0,0,Globals.WindowSize.X, Globals.WindowSize.Y), Color.White);

        Globals.spriteBatch.DrawString(Globals.font, "Anvand WASD for att flytta katten  \r\nPutta stenar till trappan som visas med pilen\r\nAkta dig for arga stenar, de ar dumma ", new Vector2(370, 50), Color.Black);
        
        BackButton.Update();
        BackButton.Draw();

        if (BackButton.Clicked) HelpButton.Clicked = false;
        //GameStarted = false;
        Globals.spriteBatch.End();
    }

    public void Draw()
    {
        //Rita allting

        Globals.spriteBatch.Begin(this.camera);
        if (HelpButton.Clicked) { TutorialLevel(); return; }


        Globals.spriteBatch.DrawString(
                   Globals.font,
                   InputManager.LastClicked().ToString(),
                   camera.Position - new Vector2(0, Globals.WindowSize.Y / 2),
                   Color.White,
                   0f,
                   Vector2.Zero,
                   1.5f,
                   SpriteEffects.None,
                   0
               );


        if (!GameStarted) { StartScreen(); return; }
        

        _map.Draw();
        Trappa.Draw();

        //if (HelpButton.Clicked) TutorialText();

        foreach (Sten sten in Globals.BonkList.OfType<Sten>())
        {
            sten.Draw();
        }

        Player.Draw();

        Globals.spriteBatch.DrawString(
            Globals.font,
            Globals.Level.ToString(),
            camera.Position - new Vector2(0, Globals.WindowSize.Y / 2),
            Color.White,
            0f,
            Vector2.Zero,
            1.5f,
            SpriteEffects.None,
            0
        );

        Globals.spriteBatch.End();
    }
}
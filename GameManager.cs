using Comora;
using System;
using System.Collections;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using TileMaps;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

public class GameManager
{
	private Map _map;
	private GraphicsDevice _device;

	public player Player;
	private Camera camera;
	private Random rnd = new Random();
	//List<trappa> trapplist = new List<trappa>();
	trappa Trappa = new trappa(new(6,6));
	Arrow arrow = new Arrow(Globals.PlayerPos);
	
	public GameManager(GraphicsDevice gd)
	{
		_map = new Map(new(20,20));
		Player = new(new(Globals.TileSize.X, Globals.TileSize.Y));
		Player.SetBounds(_map.MapSize, _map.TileSize);
		Globals.BonkList = new List<IBonkable>();
		Globals.WinPos = new Vector2(rnd.Next(Globals.MapSize.X/Globals.TileSize.X), rnd.Next(Globals.MapSize.Y/ Globals.TileSize.Y));
		
		Trappa.Position = Globals.WinPos;

		//_map._tiles[(int)Globals.WinPos.X, (int)Globals.WinPos.Y] = Trappa;
		
		//Globals.BonkList.Add(Player);
        
		Globals.BonkList.Add(new ArgSten(new(Globals.TileSize.X * 3, Globals.TileSize.Y * 3)));
        Globals.BonkList.Add(new Sten(new(Globals.TileSize.X * 5, Globals.TileSize.Y * 5)));
        Globals.BonkList.Add(new Sten(new(Globals.TileSize.X * 3, Globals.TileSize.Y * 5)));
        Globals.BonkList.Add(new Sten(new(Globals.TileSize.X * 4, Globals.TileSize.Y * 5)));
        Globals.BonkList.Add(new Sten(new(Globals.TileSize.X * 7, Globals.TileSize.Y * 5)));

		//trapplist.Add(new trappa(new(6 * 64, 6 * 64)));
		
		//trappa Trappa = new trappa(new(0,0), new(0,0));




		_device = gd;

        this.camera = new(_device);

	}

	private void Init()
	{
		Globals.BonkList.Clear();

		for (int i = 0; i < Globals.Level; i++)
		{
			Globals.BonkList.Add(new Sten(new(Globals.TileSize.X * rnd.Next(1, (Globals.MapSize.X / 64) - 1), Globals.TileSize.Y * rnd.Next(1, (Globals.MapSize.Y / 64) - 1 ))));
			Globals.BonkList.Add(new Sten(new(Globals.TileSize.X * rnd.Next(1, (Globals.MapSize.X / 64) - 1), Globals.TileSize.Y * rnd.Next(1, (Globals.MapSize.Y / 64) - 1))));

            Globals.BonkList.Add(new ArgSten(new(Globals.TileSize.X * rnd.Next(1, (Globals.MapSize.X / 64) - 1), Globals.TileSize.Y * rnd.Next(1, (Globals.MapSize.Y / 64) - 1))));
        }


        _map = new Map(new(rnd.Next(20, 30), rnd.Next(20, 30)));

        
		
		Player = new(new(Globals.TileSize.X, Globals.TileSize.Y));
        Player.SetBounds(_map.MapSize, _map.TileSize);
        Globals.WinPos = new Vector2(rnd.Next(Globals.MapSize.X / Globals.TileSize.X), rnd.Next(Globals.MapSize.Y / Globals.TileSize.Y));

		Trappa.Position = Globals.WinPos;
	}


	public void Update(GameTime gt)
	{
		if (Globals.Lose) return;

		InputManager.Update();
		Player.Update();
		this.camera.Update(gt);
		this.camera.Position = Player.Position;
		Vector2 minpos = Globals.WindowSize.ToVector2() / 2;
		Vector2 maxpos = new(Globals.MapSize.X - (Globals.WindowSize.X /2), Globals.MapSize.Y - Globals.WindowSize.Y / 2);

        camera.Position = Vector2.Clamp(camera.Position,minpos,maxpos);

		foreach (Sten sten in Globals.BonkList.OfType<Sten>().ToList()) 
		{ 
			sten.Update();
			if (sten.Position / 64 == Globals.WinPos)
			{
				Globals.BonkList.Remove(sten);
				Globals.Stones++;
			}
		}

		if((Globals.PlayerPos / 64) == Globals.WinPos)
		{
			Init();
			Globals.Level++;
		}




		if (Globals.Lose)
		{
				
		}

			

		
	}

	public void Lose()
	{

	_device.Clear(Color.Black);
	Texture2D rect = new Texture2D(_device, Globals.WindowSize.X, Globals.WindowSize.Y);
		Globals.spriteBatch.Begin();
		Player.SetBounds(new Point(0, 0), new Point(0, 0));
		Globals.spriteBatch.Draw(rect, camera.Position, Color.Black);
		Globals.spriteBatch.DrawString(Globals.font, "You Lose", camera.Position, Color.White);
		Globals.spriteBatch.DrawString(Globals.font, String.Format("Score: levels {0} * stones {1} = {2} Points", Globals.Level, Globals.Stones, Globals.Level * Globals.Stones), camera.Position + new Vector2(0, 50), Color.White);
		Globals.spriteBatch.End();

	}

	public void Draw()
	{
		Globals.spriteBatch.Begin(this.camera);

		_map.Draw();

				
		Trappa.Draw();

		foreach (Sten sten in Globals.BonkList.OfType<Sten>())
		{
			sten.Draw();
		}

		arrow.Draw();
        Player.Draw();

		Globals.spriteBatch.DrawString(Globals.font, (Globals.PlayerPos / 64).ToString(), Globals.PlayerPos + new Vector2(300, 0), Color.White);

		Globals.spriteBatch.DrawString(Globals.font, Globals.Level.ToString(), camera.Position - new Vector2(0, Globals.WindowSize.Y / 2),Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0);
		

		


        Globals.spriteBatch.End();
	}

}

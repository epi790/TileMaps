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

	public GameManager(GraphicsDevice gd)
	{
		_map = new Map(new(20,20));
		Player = new(new(Globals.TileSize.X, Globals.TileSize.Y));
		Player.SetBounds(_map.MapSize, _map.TileSize);
		Globals.BonkList = new List<IBonkable>();
		Globals.WinPos = new Vector2(rnd.Next(Globals.MapSize.X/Globals.TileSize.X), rnd.Next(Globals.MapSize.Y/ Globals.TileSize.Y));

		//Globals.BonkList.Add(Player);
        Globals.BonkList.Add(new ArgSten(new(Globals.TileSize.X * 3, Globals.TileSize.Y * 3)));
        Globals.BonkList.Add(new Sten(new(Globals.TileSize.X * 5, Globals.TileSize.Y * 5)));
        Globals.BonkList.Add(new Sten(new(Globals.TileSize.X * 3, Globals.TileSize.Y * 5)));
        Globals.BonkList.Add(new Sten(new(Globals.TileSize.X * 4, Globals.TileSize.Y * 5)));
        Globals.BonkList.Add(new Sten(new(Globals.TileSize.X * 7, Globals.TileSize.Y * 5)));

		_device = gd;

        this.camera = new(_device);

	}

	public void NewMap()
	{
		_map = new Map(new(rnd.Next(5, 15),rnd.Next(5, 15)));
	}

	public void Update(GameTime gt)
	{
		InputManager.Update();
		Player.Update();
		this.camera.Update(gt);
		this.camera.Position = Player.Position;
		Vector2 minpos = Globals.WindowSize.ToVector2() / 2;
		Vector2 maxpos = new(Globals.MapSize.X - (Globals.WindowSize.X /2), Globals.MapSize.Y - Globals.WindowSize.Y / 2);

        camera.Position = Vector2.Clamp(camera.Position,minpos,maxpos);

		foreach (Sten sten in Globals.BonkList.OfType<Sten>()) sten.Update();

		if((Globals.PlayerPos / 64) == Globals.WinPos)
		{


			NewMap();
			Globals.WinPos = new Vector2(rnd.Next(Globals.MapSize.X / Globals.TileSize.X), rnd.Next(Globals.MapSize.Y / Globals.TileSize.Y));
            Player = new(new(Globals.TileSize.X, Globals.TileSize.Y));
            
			Player.SetBounds(Globals.MapSize, Globals.TileSize);


		}

		//foreach (var item in _map._tiles)
		//{
		//	item.contains();
		//} 
		

		
	}

	public void Draw()
	{
		Globals.spriteBatch.Begin(this.camera);

		_map.Draw();
		


		foreach (Sten sten in Globals.BonkList.OfType<Sten>())
		{
			sten.Draw();
		}

        Player.Draw();

		Globals.spriteBatch.DrawString(Globals.font, (Globals.PlayerPos / 64).ToString(), Globals.PlayerPos + new Vector2(300, 0), Color.White);

		Globals.spriteBatch.DrawString(Globals.font, Globals.WinPos.ToString(), Globals.PlayerPos + new Vector2(0, 100), Color.White);
        Globals.spriteBatch.End();
	}

}

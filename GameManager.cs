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
	private readonly Map _map;
	private GraphicsDevice _device;

	public player Player;
	private Camera camera;

	public GameManager(GraphicsDevice gd)
	{
		_map = new Map();
		Player = new(new(Globals.TileSize.X, Globals.TileSize.Y));
		Player.SetBounds(_map.MapSize, _map.TileSize);
		Globals.BonkList = new List<IBonkable>();

		Globals.BonkList.Add(Player);
        Globals.BonkList.Add(new ArgSten(new(Globals.TileSize.X * 3, Globals.TileSize.Y * 3)));
        Globals.BonkList.Add(new Sten(new(Globals.TileSize.X * 5, Globals.TileSize.Y * 5)));
        Globals.BonkList.Add(new Sten(new(Globals.TileSize.X * 3, Globals.TileSize.Y * 5)));
        Globals.BonkList.Add(new Sten(new(Globals.TileSize.X * 4, Globals.TileSize.Y * 5)));
        Globals.BonkList.Add(new Sten(new(Globals.TileSize.X * 7, Globals.TileSize.Y * 5)));

		_device = gd;

        this.camera = new(_device);

	}

	public void Update(GameTime gt)
	{
		InputManager.Update();
		Player.Update();
		this.camera.Update(gt);
		this.camera.Position = Player.Position;
		Vector2 minpos = Globals.WindowSize.ToVector2() / 2;
		Vector2 maxpos = new(Globals.MapSize.X - Globals.Windowsize.X, Globals.MapSize.Y - Globals.Windowsize.Y * 3);

        camera.Position = Vector2.Clamp(camera.Position,minpos,maxpos);

		foreach (Sten sten in Globals.BonkList.OfType<Sten>()) sten.Update();


		
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

		Globals.spriteBatch.DrawString(Globals.font, this.camera.Position.ToString(), Globals.PlayerPos + new Vector2(300, 0), Color.White);
        Globals.spriteBatch.End();
	}

}

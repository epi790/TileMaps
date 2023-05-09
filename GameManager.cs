using Comora;
using System;
using System.Collections;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using TileMaps;
using System.Diagnostics;
using System.Collections.Generic;

public class GameManager
{
	private readonly Map _map;

	public player Player;
	private Camera camera;
	public List<Sten> stenlist;
	public GameManager(GraphicsDevice gd)
	{
		_map = new Map();
		Player = new(new(Globals.TileSize.X, Globals.TileSize.Y));
		Player.SetBounds(_map.MapSize, _map.TileSize);
		stenlist = new List<Sten>();

        stenlist.Add(new ArgSten(new(Globals.TileSize.X * 7, Globals.TileSize.Y * 7)));
        stenlist.Add(new Sten(new(Globals.TileSize.X * 5, Globals.TileSize.Y * 5)));



        this.camera = new(gd);

	}

	public void Update(GameTime gt)
	{
		InputManager.Update();
		Player.Update();
		this.camera.Update(gt);
		this.camera.Position = Player.Position;
		this.camera.Position += new Vector2(1, 1);

		foreach (Sten sten in stenlist) sten.Update();


		
	}

	public void Draw()
	{
		Globals.spriteBatch.Begin(this.camera);

		_map.Draw();
		


		foreach (var item in stenlist)
		{
			item.Draw();
		}

        Player.Draw();
        Globals.spriteBatch.End();
	}

}

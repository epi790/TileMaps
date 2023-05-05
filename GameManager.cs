using Comora;
using System;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using TileMaps;
using System.Diagnostics;

public class GameManager
{
	private readonly Map _map;

	public player Player;
	private Camera camera;
	public GameManager(GraphicsDevice gd)
	{
		_map = new Map();
		Player = new(new(0, 0), new(1 * Globals.TileSize.X, 1 * Globals.TileSize.Y));
		Player.SetBounds(_map.MapSize, _map.TileSize);

		this.camera = new(gd);

	}

	public void Update(GameTime gt)
	{
		InputManager.Update();
		Player.Update();
		this.camera.Update(gt);
		this.camera.Position = Player.Position;
		this.camera.Position += new Vector2(1, 1);
		
	}

	public void Draw()
	{
		Globals.spriteBatch.Begin(this.camera);

		_map.Draw();
		Player.Draw();

		

		Globals.spriteBatch.End();
	}

}

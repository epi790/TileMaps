using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;
using SharpDX.Win32;

// Basic class som får object att tex Rita sig själva och ha en position.
public class GameSprite
{
	protected Texture2D _tilemap;
	public Vector2 Position { get; set; }
	public GameSprite contains { get; set; }
	public Vector2 Origin { get; protected set; }
	protected Point tile;
	
	public GameSprite(Vector2 position)
	{
        _tilemap = Globals.Tilemap;
        Position = position;
        Origin = new(_tilemap.Width / 2, _tilemap.Height / 2);
    }
	public GameSprite(Point tile, Vector2 position)
	{
		_tilemap = Globals.Tilemap;
		Position = position;
		Origin = new(_tilemap.Width / 2, _tilemap.Height / 2);

		this.tile = tile;
	}

	private void Contain()
	{
		foreach (var item in Globals.BonkList)
		{
			if (item.Position == this.Position) contains = (GameSprite)item;
		}
	}
	public virtual void Draw()
	{
		Globals.spriteBatch.Draw(_tilemap, Position, new Rectangle(tile.X * 32, tile.Y * 32, 32, 32), Color.White, 0, Vector2.Zero, 2f, SpriteEffects.None, 0f);
	}
}

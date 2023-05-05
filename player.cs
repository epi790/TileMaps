using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

public class player : GameSprite
{
	private int speed = 500;

	private Vector2 _minPos, _maxPos;
	private bool pressed;
	private Vector2 startPos;
	private Vector2 Destination;

	private float elapsedTime;

	public player(Point tile, Vector2 position ) : base( tile, position )
	{
		this.Position = position;
		this._tilemap = Globals.PlayerSprite;
		
	}

	public void SetBounds(Point mapSize, Point TileSize)
	{
		_minPos = new Vector2((-TileSize.X/2) + Origin.X, (-TileSize.Y/2) + Origin.Y );
		_maxPos = new Vector2(mapSize.X - (TileSize.X / 2), mapSize.Y - (TileSize.Y / 2));
	}


	public void Update()
	{
		if (!pressed)
		{
			startPos = Position;
			//elapsedTime = 0;

			Destination = new(Position.X + InputManager.Direction.X * Globals.TileSize.X, Position.Y + InputManager.Direction.Y * Globals.TileSize.Y);
			Position = Destination;

			//Position += InputManager.Direction;
			pressed = true;
        }

		elapsedTime += Globals.Time;

		Debug.WriteLine(elapsedTime);

		//Position = Vector2.Lerp(startPos, Destination, elapsedTime);

		//Position = Vector2.Clamp(Position, Vector2.Zero, _maxPos);
		
		if (InputManager.Released) pressed = false;
		
		
	}

	public override void Draw()
	{
		//	Globals.spriteBatch.Draw(_texture, Position, null, Color.White, 0f, Origin, 1f, SpriteEffects.None, 0f);
		Globals.spriteBatch.Draw(_tilemap, Position, new Rectangle(tile.X * 32, tile.Y * 64, 32, 64), Color.White, 0, Vector2.Zero, 2f, SpriteEffects.None, 0f);
	}
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.DirectWrite;
using System;
using System.Diagnostics;

public class player : GameSprite
{
	private int speed = 500;

	private Vector2 _minPos, _maxPos;
	private bool pressed;
	private Vector2 startPos;
	private Vector2 Destination;
	private Rectangle source;

	

	private float elapsedTime;

	public player(Point tile, Vector2 position ) : base( tile, position )
	{
		this.Position = position;
		this._tilemap = Globals.PlayerSprite; 
		source = new Rectangle(tile.X * 32, tile.Y * 64, 32, 64);
		this.Origin = new(source.X / 2, (source.Y / 2) + 32);


		
		
	}

	public void SetBounds(Point mapSize, Point TileSize)
	{
		_minPos = new Vector2((-TileSize.X/2), (-TileSize.Y/2) + source.Height );
		_maxPos = new Vector2(mapSize.X - (TileSize.X), mapSize.Y);
	}


	public void Update()
	{
		if (!pressed)
		{
			startPos = Position;
			//elapsedTime = 0;

			Destination = new(Position.X + InputManager.Direction.X * Globals.TileSize.X, Position.Y + InputManager.Direction.Y * Globals.TileSize.Y);
			this.Position = Destination;
			this.Origin = new(source.X / 2, (source.Y / 2));


			//Position += InputManager.Direction;
			pressed = true;
        }

		elapsedTime += Globals.Time;


		//Position = Vector2.Lerp(startPos, Destination, elapsedTime);

		Position = Vector2.Clamp(Position, Vector2.Zero, _maxPos);
		
		if (InputManager.Released) pressed = false;
		
		
	}

	public override void Draw()
	{
		//	Globals.spriteBatch.Draw(_texture, Position, null, Color.White, 0f, Origin, 1f, SpriteEffects.None, 0f);
		Globals.spriteBatch.Draw(_tilemap, Position - new Vector2(0, 64), source,  Color.White, 0, Vector2.Zero, 2f, SpriteEffects.None, 0f);
		Globals.spriteBatch.DrawString(Globals.font, Position.ToString(), Position + new Vector2(-100, -100), Color.White);
		Globals.spriteBatch.DrawString(Globals.font, (Position.X / 64).ToString() + " " + (Position.Y / 64).ToString(), Position + new Vector2(100, -100), Color.White);
		
	}
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.DirectWrite;
using System;
using System.Diagnostics;

public class player : GameSprite
{

	private Vector2 _minPos, _maxPos;
	private Vector2 startPos;
	private Vector2 Destination;
	private Rectangle source;
	float TargetFrames = 3;
	bool IsMoving = false;
		

	private float elapsedTime;

	public player(Vector2 position ) : base(position )
	{
		// Variabler
		this.Position = position;
		this._tilemap = Globals.PlayerSprite; 
		source = new Rectangle(tile.X * 32, tile.Y * 64, 32, 64);
		this.Origin = new(source.X / 2, (source.Y / 2) + 32);
		this.tile = new(0, 0);
		this.tileSize = new(1, 2);
	}

	public void SetBounds(Point mapSize, Point TileSize)
	{
		// fixa så att man inte kan gå av banan.
		_minPos = new Vector2((-TileSize.X/2), (-TileSize.Y/2) + source.Height );
		_maxPos = new Vector2(Globals.MapSize.X - (TileSize.X), Globals.MapSize.Y - TileSize.Y);
	}

	public void Update()
	{
		//gör spelarens runda

		if ( ( InputManager.HasBeenPressed(Keys.W) || InputManager.HasBeenPressed(Keys.A) || InputManager.HasBeenPressed(Keys.S) || InputManager.HasBeenPressed(Keys.D) ) && !IsMoving )
		{
			startPos = Position;
			elapsedTime = 0;

			Destination = new(Position.X + InputManager.Direction.X * Globals.TileSize.X, Position.Y + InputManager.Direction.Y * Globals.TileSize.Y);
			this.Origin = new(source.X / 2, (source.Y / 2));
        }

	
		this.Position = Vector2.Lerp(startPos, Destination, elapsedTime/TargetFrames);
		this.Position = Vector2.Clamp(Position, Vector2.Zero, _maxPos);

		if (elapsedTime < TargetFrames)
		{
			elapsedTime++;
			IsMoving = true;
		}
		else 
		{
			if (IsMoving) { Globals.Round++; Globals.PlayerPos = this.Position; }
;
			IsMoving = false;
		}
	}

   
    public override void Draw()
	{
		//rita åt vilket håll spelaren rör sig.

		if (InputManager.LastDirection == new Vector2(0, 1)) this.tile = new(0, 0);
		if (InputManager.LastDirection == new Vector2(0, -1)) this.tile = new(1, 0);
		if (InputManager.LastDirection == new Vector2(-1, 0)) this.tile = new(2, 0);
		if (InputManager.LastDirection == new Vector2(1, 0)) this.tile = new(0, 1);
		source = new Rectangle(tile.X * 32, tile.Y * 64, 32, 64);
		Globals.spriteBatch.Draw(_tilemap, Position - new Vector2(0, 64), source,  Color.White, 0, Vector2.Zero, 2f, SpriteEffects.None, 0f);
		
	}
}

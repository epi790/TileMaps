using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.DirectWrite;
using System;
using System.Diagnostics;

public class player : GameSprite, IBonkable
{

	private Vector2 _minPos, _maxPos;
	private Vector2 startPos;
	private Vector2 Destination;
	private Rectangle source;
	float TargetFrames = 3
		;
	bool IsMoving = false;

	private float elapsedTime;

	public player(Vector2 position ) : base(position )
	{
		this.Position = position;
		this._tilemap = Globals.PlayerSprite; 
		source = new Rectangle(tile.X * 32, tile.Y * 64, 32, 64);
		this.Origin = new(source.X / 2, (source.Y / 2) + 32);
		this.tile = new(0, 0);

	}

	public void SetBounds(Point mapSize, Point TileSize)
	{
		_minPos = new Vector2((-TileSize.X/2), (-TileSize.Y/2) + source.Height );
		_maxPos = new Vector2(Globals.MapSize.X - (TileSize.X), Globals.MapSize.Y - TileSize.Y);
	}


	public void Update()
	{

		

		if ( ( InputManager.HasBeenPressed(Keys.W) || InputManager.HasBeenPressed(Keys.A) || InputManager.HasBeenPressed(Keys.S) || InputManager.HasBeenPressed(Keys.D) ) && !IsMoving )
		{
			startPos = Position;
			elapsedTime = 0;

			Destination = new(Position.X + InputManager.Direction.X * Globals.TileSize.X, Position.Y + InputManager.Direction.Y * Globals.TileSize.Y);
			//this.Position = Destination;
			this.Origin = new(source.X / 2, (source.Y / 2));

		
		

		
			//Position += InputManager.Direction;
			
			
        }

	
		this.Position = Vector2.Lerp(startPos, Destination, elapsedTime/TargetFrames);
		//this.Position = Destination;



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
		if (InputManager.LastDirection == new Vector2(0, 1)) this.tile = new(0, 0);
		if (InputManager.LastDirection == new Vector2(0, -1)) this.tile = new(1, 0);
		if (InputManager.LastDirection == new Vector2(-1, 0)) this.tile = new(2, 0);
		if (InputManager.LastDirection == new Vector2(1, 0)) this.tile = new(0, 1);
		source = new Rectangle(tile.X * 32, tile.Y * 64, 32, 64);
		
		Globals.spriteBatch.Draw(_tilemap, Position - new Vector2(0, 64), source,  Color.White, 0, Vector2.Zero, 2f, SpriteEffects.None, 0f);
		//Globals.spriteBatch.DrawString(Globals.font, Position.ToString(), Position + new Vector2(-100, -100), Color.White);
		//Globals.spriteBatch.DrawString(Globals.font, (Position.X / 64).ToString() + " " + (Position.Y / 64).ToString(), Position + new Vector2(100, -100), Color.White);
		
	}
}

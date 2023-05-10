using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.DirectWrite;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class Sten : GameSprite
{
	private int Round = 0;
	
	public Sten(Vector2 pos) : base(pos)
	{
		this._tilemap = Globals.StenSprite;
		this.tile = new(5, 15);
		this.Position = pos;
	}

	public virtual void Update()
	{
		if (Round != Globals.Round)
		{
            AdvanceRound();
			Round = Globals.Round;
           
		}
	}

	protected virtual void AdvanceRound()
	{
        if (this.Position == Globals.PlayerPos )
        {
            this.Position += new Vector2(InputManager.Direction.X * Globals.TileSize.X, InputManager.Direction.Y * Globals.TileSize.Y);
        }
        
    }

}

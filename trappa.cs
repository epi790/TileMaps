using SharpDX.Direct2D1.Effects;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.DirectWrite;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class trappa : GameSprite
{
	public trappa(Vector2 Position) : base(Position)
	{
        this._tilemap = Globals.StructTexture;
        this.tile = new(7, 5);
        this.tileSize = new(2, 3);
        this.scale = 1f;
        this.Position = Globals.WinPos * 64;
	}

    public override void Draw()
    {

		Globals.spriteBatch.Draw(this._tilemap, this.Position * 64, new Rectangle(this.tile.X * 32, this.tile.Y * 32, this.tileSize.X * 32, this.tileSize.Y * 32), Color.White, 0, Vector2.Zero, this.scale, SpriteEffects.None, 0f);
    }
}

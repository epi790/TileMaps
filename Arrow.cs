using System;
using SharpDX.Direct2D1.Effects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.DirectWrite;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class Arrow : GameSprite
{
    SpriteEffects effect;
	public Arrow(Vector2 position) : base(position)
	{
		this.Position = Globals.PlayerPos;
        this._tilemap = Globals.ArrowTexture;
        this.rotation = (float)Math.PI / 2f;
	}

    public override void Draw()
    {
        this.Position = new Vector2(Globals.PlayerPos.X + 30, Globals.PlayerPos.Y);
       

        // https://stackoverflow.com/questions/13458992/angle-between-two-vectors-2d

        rotation =  (float)Math.Atan2((this.Position.Y / 64 - Globals.WinPos.Y) - 1, (this.Position.X / 64 - Globals.WinPos.X) - 0.5f);
        //if (rotation < 0)  effect = SpriteEffects.FlipHorizontally; 
        //else effect = SpriteEffects.None;
        //this.rotation = MathHelper.ToRadians((float)Math.Acos(Vector2.Dot(Normalised1, Nomalised2)));

        //this.rotation = (float)Math.Atan2((double)Globals.WinPos.Y - (double)Globals.PlayerPos.Y, (double)Globals.PlayerPos.X - (double)Globals.WinPos.X);
        //this.rotation = MathHelper.ToRadians(this.rotation);
        Globals.spriteBatch.DrawString(Globals.font, String.Format("thispos {0} winpos {1} distance {2}", this.Position, Globals.WinPos.ToString(), (this.Position - Globals.WinPos).ToString()), Globals.PlayerPos + new Vector2(200, -100), Color.White);
       Globals.spriteBatch.Draw(this._tilemap, this.Position, new Rectangle(0, 0, 360, 360), Color.White, rotation + (float)Math.PI, new(0, _tilemap.Height / 2), .25f, SpriteEffects.None, 0); ;
    }

}

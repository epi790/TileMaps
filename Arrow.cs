using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

public class Arrow : GameSprite
{

    public Arrow(Vector2 position) : base(position)
    {
        this.Position = Globals.PlayerPos;
        this._tilemap = Globals.ArrowTexture;
        this.rotation = (float)Math.PI / 2f;
    }

    public override void Draw()
    {
    //räkna ut rotation och rita
        rotation = (float)Math.Atan2((this.Position.Y / 64 - Globals.WinPos.Y) - 1, (this.Position.X / 64 - Globals.WinPos.X) - 0.5f);
        Globals.spriteBatch.Draw(this._tilemap, this.Position, new Rectangle(0, 0, 360, 360), Color.White, rotation + (float)Math.PI, new(0, _tilemap.Height / 2), .25f, SpriteEffects.None, 0); ;
    }

}

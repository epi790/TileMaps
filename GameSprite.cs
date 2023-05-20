using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Basic class som får object att tex Rita sig själva och ha en position.
public class GameSprite
{
    protected Texture2D _tilemap;
    public Vector2 Position { get; set; }
    public Vector2 Origin { get; protected set; }
    protected Point tile;
    protected Point tileSize = new(1, 1);
    protected float scale = 2f;
    protected float rotation = 0f;

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


    public virtual void Draw()
    {
        Globals.spriteBatch.Draw(this._tilemap, this.Position, new Rectangle(this.tile.X * 32, this.tile.Y * 32, this.tileSize.X * 32, this.tileSize.Y * 32), Color.White, this.rotation, Vector2.Zero, this.scale, SpriteEffects.None, 0f);
    }
}

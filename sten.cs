using Microsoft.Xna.Framework;

public class Sten : GameSprite, IBonkable
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
        //bli flyttad om spelare går på sten

        if (Globals.PlayerPos == this.Position) this.Position += new Vector2(InputManager.LastDirection.X * Globals.TileSize.X, InputManager.LastDirection.Y * Globals.TileSize.Y);

        if (Round != Globals.Round)
        {
            AdvanceRound();
            Round = Globals.Round;
        }
    }

    public virtual void AdvanceRound()
    {
        // se till att stenar puttas på rad.

        foreach (var item in Globals.BonkList)
        {
            if (item.Position == this.Position && item != this)
            {
                item.Position += new Vector2(InputManager.LastDirection.X * Globals.TileSize.X, InputManager.LastDirection.Y * Globals.TileSize.Y);

                item.AdvanceRound();
            }
        }


    }

}

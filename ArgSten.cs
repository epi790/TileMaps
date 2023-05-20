using Microsoft.Xna.Framework;
using System;

public class ArgSten : Sten
{
    private bool Angry;
    float dx;
    float dy;
    int counter = 0;

    public ArgSten(Vector2 pos) : base(pos)
    {
        this.Position = pos;
    }

    public override void AdvanceRound()
    {
        if (this.Angry)
        {
            AngryStuff();
        }


        if (Math.Abs(this.Position.X - Globals.PlayerPos.X) < Globals.TileSize.X * 3 && Math.Abs(this.Position.Y - Globals.PlayerPos.Y) < Globals.TileSize.Y * 3)
        {
            //Bli arg och byt bild
            this.Angry = true;
            this.tile = new(6, 15);
        }

        base.AdvanceRound();
    }

    private void AngryStuff()
    {
        //delta x och y
        dx = this.Position.X - Globals.PlayerPos.X;
        dy = this.Position.Y - Globals.PlayerPos.Y;

        //skippa var 3:e runda
        counter++;
        if (counter % 3 == 0) return;

        //gå
        if (Math.Abs(dx) > Math.Abs(dy)) this.Position -= new Vector2(dx / Math.Abs(dx) * Globals.TileSize.X, 0);
        else this.Position -= new Vector2(0, dy / Math.Abs(dy) * Globals.TileSize.Y);
        
        //få spelaren att förlora
        if (this.Position == Globals.PlayerPos) Globals.Lose = true;

    }

}

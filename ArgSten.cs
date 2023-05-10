using Microsoft.Xna.Framework;
using System;
using System.Configuration;
using System.Diagnostics;

public class ArgSten : Sten
{
    private bool Angry;
    float dx;
    float dy;



	public ArgSten(Vector2 pos) : base(pos)
	{

	}



    protected override void AdvanceRound()
    {

        if (this.Position.X - Globals.PlayerPos.X < Globals.TileSize.X * 3 && this.Position.Y - Globals.PlayerPos.Y < Globals.TileSize.Y * 3)
        {
            Angry = true;
			this.tile = new(6, 15);
            
        }

        if (Angry)
        {
            AngryStuff();
        }

        base.AdvanceRound();

    }

    private void AngryStuff()
    {
            //dx = this.Position.X - Globals.PlayerPos.X;  
            //dy = this.Position.Y - Globals.PlayerPos.Y;

            //if (Math.Abs(dx) > Math.Abs(dy))
            //{
            //    //this.Position -= new Vector2(dx / Math.Abs(dx) * Globals.TileSize.X, 0);
            //}
            //else
            //{
            //    //this.Position -= new Vector2(0, dy / Math.Abs(dy) * Globals.TileSize.Y);
            //}


    }

   


}

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
            
        }

        if (Angry)
        {
            dx = this.Position.X - Globals.PlayerPos.X;  
            dy = this.Position.Y - Globals.PlayerPos.Y;

            if (Math.Abs(dx) > Math.Abs(dy))
            {
                this.Position += new Vector2(dx / Math.Abs(dx), 0);
            }
            else
            {
                this.Position += new Vector2(dy / Math.Abs(dy), 0);
            }
        }

        base.AdvanceRound();

    }



}

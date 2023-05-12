using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.DirectWrite;
using System;
using System.Diagnostics;

public interface IBonkable
{
    public Vector2 Position { get; set; }
    public void AdvanceRound() { }

    //abstract void bonk { }
}

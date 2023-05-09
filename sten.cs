using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.DirectWrite;
using System;
using System.Diagnostics;

public class Sten : GameSprite
{
	
	public Sten(Point tile, Vector2 pos) : base(tile, pos)
	{
		_tilemap = Globals.StenSprite;
	}
}

using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
public static class Globals
{
	public static float Time { get; set; }
	public static ContentManager Content { get; set; }
	public static SpriteBatch spriteBatch {get; set;}
	public static Point Windowsize { get; set; }
	public static GameTime GameTime { get; set; }
	public static Texture2D PlayerSprite { get; set; }
	public static Texture2D Tilemap { get; set; }

	public static Point TileSize { get; set; }

	public static void Update(GameTime gameTime)
	{
		Time = (float)gameTime.ElapsedGameTime.TotalSeconds;
	}

}

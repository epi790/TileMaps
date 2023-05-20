using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

public static class Globals
{

    // Variabler som allt kan komma åt
   
    public static ContentManager Content { get; set; }
    public static SpriteBatch spriteBatch { get; set; }
    public static Texture2D PlayerSprite { get; set; }
    public static Vector2 PlayerPos { get; set; }
    public static Texture2D StenSprite { get; set; }
    public static Texture2D Tilemap { get; set; }
    public static Texture2D ArrowTexture { get; set; }
    public static SpriteFont font { get; set; }
    public static int Round { get; set; }
    public static int Stones { get; set; }

    public static Point TileSize { get; set; }
    public static Point MapSize { get; set; }
    public static Point WindowSize { get; set; }

    public static List<IBonkable> BonkList { get; set; }
    public static Vector2 WinPos { get; set; }
    public static Texture2D StructTexture { get; set; }
    public static bool Lose { get; set; }
    public static int Level = 1;

}

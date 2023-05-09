using System;
using System.Threading;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using TileMaps;

public class Map
{

	private readonly Point _mapTileSize = new(201, 20);
	private readonly GameSprite[,] _tiles;
	public Point TileSize { get; set; }
	public Point MapSize { get; set; }

	private Point tile;



	public Map()
	{
		_tiles = new GameSprite[_mapTileSize.X, _mapTileSize.Y];

		//List<Texture2D> textures = new List<Texture2D>(64);

		TileSize = new Point(64, 64);
		Globals.TileSize = TileSize;

		MapSize = new Point(TileSize.X * _mapTileSize.X, TileSize.Y * _mapTileSize.Y);

		Random random = new(DateTime.Now.Millisecond);

		for (int i = 0; i < _mapTileSize.X; i++)
		{
			for (int j = 0; j < _mapTileSize.Y; j++)
			{
				tile = new(random.Next(8), random.Next(8));
				
				while (tile == new Point(7, 7) || tile == new Point(6,7)) tile = new(random.Next(8), random.Next(8));


				_tiles[i, j] = new GameSprite(tile, new Vector2(TileSize.X * i, TileSize.Y * j));
			}
		}


		

	}

	public void Draw()
	{
		for (int i = 0; i < _mapTileSize.X; i++)
		{
			for (int j = 0; j < _mapTileSize.Y; j++)
			{


				_tiles[i, j].Draw();




			}
		}


		//_tiles[0,0].Draw();
	}
}

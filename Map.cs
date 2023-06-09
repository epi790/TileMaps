﻿using Microsoft.Xna.Framework;
using System;

public class Map
{
    //Generera kartan

    private readonly Point _mapTileSize;
    public GameSprite[,] _tiles;
    public Point TileSize { get; set; }
    public Point MapSize { get; set; }

    private Point tile;

    Random random = new(DateTime.Now.Millisecond);


    public Map(Point _mapTileSize)
    {
    // initera spelplan
        this._mapTileSize = _mapTileSize;
        
        _tiles = new GameSprite[_mapTileSize.X, _mapTileSize.Y];

        
        TileSize = new Point(64, 64);

        Globals.TileSize = TileSize;

        Globals.MapSize = new Point(TileSize.X * _mapTileSize.X, TileSize.Y * _mapTileSize.Y);


        for (int i = 0; i < _mapTileSize.X; i++)
        {
            for (int j = 0; j < _mapTileSize.Y; j++)
            {
                tile = new(random.Next(8), random.Next(8));

                while (tile == new Point(7, 7) || tile == new Point(6, 7)) tile = new(random.Next(8), random.Next(8));


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


    }
}

﻿using SFML.Graphics;
using SFML.System;
using System;

namespace Terraria
{
    class World : Transformable, Drawable
    {
        public const int WORLD_WIDTH = 100;
        public const int WORLD_HEIGHT = 100;

        public static Random Rand { private set; get; }

        Tile[,] tiles;

        public World()
        {
            tiles = new Tile[WORLD_WIDTH, WORLD_HEIGHT];
        }

        public void GenerateWorld(int seed = -1)
        {
            Rand = seed >= 0 ? new Random(seed) : new Random((int)DateTime.Now.Ticks);

            int groundLevelMax = Rand.Next(10, 20);
            int groundLevelMin = groundLevelMax + Rand.Next(10, 20);

            int[] arr = new int[WORLD_WIDTH];

            for (int i = 0; i < WORLD_WIDTH; i++)
            {
                int dir = Rand.Next(0, 2) == 1 ? 1 : -1;

                if (i > 0)
                {
                    if (arr[i - 1] + dir < groundLevelMax || arr[i - 1] + dir > groundLevelMin)
                        dir = -dir;

                    arr[i] = arr[i - 1] + dir;
                }
                else arr[i] = groundLevelMin;
            }

            for (int i = 0; i < WORLD_WIDTH; i++)
            {
                float sum = arr[i];
                int count = 1;

                for (int k = 1; k <= 5; k++)
                {
                    int i1 = i - k;
                    int i2 = i + k;

                    if (i1 > 0)
                    {
                        sum += arr[i1];
                        count++;
                    }
                    if (i2 < WORLD_WIDTH)
                    {
                        sum += arr[i2];
                        count++;
                    }
                }

                arr[i] = (int)(sum / count);
            }

            for (int i = 0; i < WORLD_WIDTH; i++)
            {
                SetTile(TileType.GRASS, i, arr[i]);

                for (int j = arr[i] + 1; j < WORLD_HEIGHT; j++)
                    SetTile(TileType.GROUND, i, j);
            }
        }

        public void SetTile(TileType type, int i, int j)
        {
            if (!(i >= 0 && j >= 0 && i < WORLD_WIDTH && j < WORLD_HEIGHT))
                return;

            Tile upTile = GetTile(i, j - 1);
            Tile downTile = GetTile(i, j + 1);
            Tile leftTile = GetTile(i - 1, j);
            Tile rightTile = GetTile(i + 1, j);

            var tile = new Tile(type, upTile, downTile, leftTile, rightTile);
            tile.rectShape.Position = new Vector2f(i * Tile.TILE_SIZE, j * Tile.TILE_SIZE) + Position;
            tiles[i, j] = tile;
        }

        public Tile GetTile(int i, int j)
        {
            if (i >= 0 && j >= 0 && i < WORLD_WIDTH && j < WORLD_HEIGHT) return tiles[i, j];
            else return null;
        }

        public void Update()
        {

        }

        // Draw world
        public void Draw(RenderTarget target, RenderStates states)
        {
            // Draw tiles
            for (int i = 0; i < Program.Window.Size.X / Tile.TILE_SIZE + 1; i++)
                for (int j = 0; j < Program.Window.Size.Y / Tile.TILE_SIZE + 1; j++)
                {
                    if (tiles[i, j] != null)
                        target.Draw(tiles[i, j]);
                }
        }
    }
}

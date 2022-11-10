using Terraria.Items;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;

namespace Terraria
{
    class World : Transformable, Drawable
    {
        public const int WORLD_WIDTH = 100;
        public const int WORLD_HEIGHT = 100;

        public static Random Rand { private set; get; }

        Tile[,] tiles;

        List<Item> items = new List<Item>();

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

            // Smoothing
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

            // Tile building
            for (int i = 0; i < WORLD_WIDTH; i++)
            {
                SetTile(TileType.GRASS, i, arr[i]);

                for (int j = arr[i] + 1; j < WORLD_HEIGHT; j++)
                    SetTile(TileType.GROUND, i, j);

                for (int j = arr[i] + 8; j < WORLD_HEIGHT; j++)
                    SetTile(TileType.STONE, i, j);
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

            if (type != TileType.NONE)
            {
                var tile = new Tile(type, upTile, downTile, leftTile, rightTile);
                tile.Position = new Vector2f(i * Tile.TILE_SIZE, j * Tile.TILE_SIZE) + Position;
                tiles[i, j] = tile;
            }
            else
            {
                var tile = tiles[i, j];
                if (tile != null)
                {
                    var item = new ItemTile(this, InfoItem.ItemGround);
                    item.Position = tile.Position;
                    items.Add(item);
                }

                tiles[i, j] = null;

                if (upTile != null) upTile.DownTile = null;
                if (downTile != null) downTile.UpTile = null;
                if (leftTile != null) leftTile.RightTile = null;
                if (rightTile != null) rightTile.LeftTile = null;
            }
        }

        public Tile GetTileByWorldPos(float x, float y)
        {
            int i = (int)(x / Tile.TILE_SIZE);
            int j = (int)(y / Tile.TILE_SIZE);
            return GetTile(i, j);
        }

        public Tile GetTileByWorldPos(Vector2f pos)
        {
            return GetTileByWorldPos(pos.X, pos.Y);
        }

        public Tile GetTileByWorldPos(Vector2i pos)
        {
            return GetTileByWorldPos(pos.X, pos.Y);
        }

        public Tile GetTile(int i, int j)
        {
            if (i >= 0 && j >= 0 && i < WORLD_WIDTH && j < WORLD_HEIGHT) return tiles[i, j];
            else return null;
        }

        public void Update()
        {
            int i = 0;
            while (i < items.Count)
            {
                if (items[i].isDestroyed)
                    items.RemoveAt(i);
                else
                {
                    items[i].Update();
                    i++;
                }
            }
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

            // Draw items
            foreach (var item in items)
                target.Draw(item);
        }
    }
}

using SFML.Graphics;
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
            for (int i = 0; i < WORLD_WIDTH; i++)
                for (int j = 0; j < WORLD_HEIGHT; j++)
                {
                    SetTile(i, j);
                }
        }

        public void SetTile(int i, int j)
        {
            if (!(i >= 0 && j >= 0 && i < WORLD_WIDTH && j < WORLD_HEIGHT))
                return;

            var tile = new Tile();
            tile.rectShape.Position = new Vector2f(i * Tile.TILE_SIZE, j * Tile.TILE_SIZE) + Position;
            tiles[i, j] = tile;
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

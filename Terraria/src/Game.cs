using SFML.System;
using SFML.Graphics;

namespace Terraria
{
    class Game
    {
        Tile tile;

        public Game()
        {
            tile = new Tile();
        }

        public void Update()
        {
            tile.UpdateView();
        }

        public void Draw()
        {
            Program.Window.Draw(tile);
        }
    }
}

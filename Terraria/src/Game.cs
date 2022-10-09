using SFML.System;
using SFML.Graphics;

namespace Terraria
{
    class Game
    {
        World world;

        public Game()
        {
            world = new World();
            world.GenerateWorld();
        }

        public void Update()
        {
            world.Update();
        }

        public void Draw()
        {
            Program.Window.Draw(world);
        }
    }
}

using SFML.System;
using Terraria.Npc;
using SFML.Graphics;

namespace Terraria
{
    class Game
    {
        World world;
        NpcSlime slime;

        public Game()
        {
            world = new World();
            world.GenerateWorld();

            slime = new NpcSlime(world);
            slime.StartPosition = new Vector2f(500, 150);
            slime.Spawn();
        }

        public void Update()
        {
            world.Update();

            slime.Update();
        }

        public void Draw()
        {
            Program.Window.Draw(world);
            Program.Window.Draw(slime);
        }
    }
}

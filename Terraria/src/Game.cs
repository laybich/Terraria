using SFML.System;
using Terraria.Npc;
using System.Collections.Generic;
using SFML.Window;
using System.Linq;

namespace Terraria
{
    class Game
    {
        World world;
        List<NpcSlime> slimes = new List<NpcSlime>();

        public Game()
        {
            world = new World();
            world.GenerateWorld();

            for (int i = 0; i < 5; i++)
            {
                var s = new NpcSlime(world);
                s.StartPosition = new Vector2f(World.Rand.Next(0, (int)Program.Window.Size.X), 150);
                s.Direction = World.Rand.Next(0, 2) == 0 ? 1 : -1;
                s.Spawn();

                slimes.Add(s);
            }
        }

        public void Update()
        {
            world.Update();

            foreach (var s in slimes)
                s.Update();
        }

        public void Draw()
        {
            Program.Window.Draw(world);

            foreach (var s in slimes)
                Program.Window.Draw(s);

            DebugRender.Draw(Program.Window);
        }
    }
}

using SFML.System;
using Terraria.Npc;
using Terraria.UI;
using System.Collections.Generic;

namespace Terraria
{
    class Game
    {
        public Player Player { get; private set; }
        List<NpcSlime> slimes = new List<NpcSlime>();
        World world;
        Splash splash;

        public Game()
        {
            splash = new Splash();

            world = new World();
            world.GenerateWorld();

            Player = new Player(world);
            Player.StartPosition = new Vector2f(300, 150);
            Player.Spawn();

            for (int i = 0; i < 5; i++)
            {
                var s = new NpcSlime(world);
                s.StartPosition = new Vector2f(World.Rand.Next(0, (int)Program.Window.Size.X), 150);
                s.Direction = World.Rand.Next(0, 2) == 0 ? 1 : -1;
                s.Spawn();

                slimes.Add(s);
            }

            Player.Invertory = new UIInvertory();
            UIManager.AddControl(Player.Invertory);
            UIManager.AddControl(splash);
        }

        public void Update()
        {
            if (Splash.ShowSplash)
            {
                splash.Update();
            }
            else
            {
                world.Update();
                Player.Update();

                foreach (var s in slimes)
                    s.Update();

                UIManager.UpdateOver();
                UIManager.Update();
            }
        }

        public void Draw()
        {
            // Draw world
            Program.Window.Draw(world);
            Program.Window.Draw(Player);

            // Draw slimes
            foreach (var s in slimes)
                Program.Window.Draw(s);

            // Debug draw
            DebugRender.Draw(Program.Window);

            // Draw UI
            UIManager.Draw();
        }
    }
}

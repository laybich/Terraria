using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;

namespace Terraria
{
    class Program
    {
        public static RenderWindow Window { private set; get; }
        public static Game Game { private set; get; }
        public static float Delta { private set; get; }
        public static Dictionary<Keyboard.Key, bool> keys = new Dictionary<Keyboard.Key, bool>();

        static void Main(string[] args)
        {
            Window = new RenderWindow(new SFML.Window.VideoMode(1360, 720), "Terraria");
            Window.SetVerticalSyncEnabled(true);

            Window.Closed += Window_Close;
            Window.Resized += Window_Resized;
            Window.KeyPressed += Window_Pressed;
            Window.KeyReleased += Window_Realesed;

            keys[Keyboard.Key.F3] = false;

            Content.Load();
            Game = new Game();
            Clock clock = new Clock();

            while (Window.IsOpen)
            {
                Delta = clock.Restart().AsSeconds();

                Window.DispatchEvents();
                Game.Update();

                Window.Clear(Color.Black);
                Game.Draw();
                Window.Display();
            }
        }

        private static void Window_Close(object sender, EventArgs e)
        {
            Window.Close();
        }

        private static void Window_Resized(object sender, SizeEventArgs e)
        {
            Window.SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));
        }

        private static void Window_Pressed(object sender, KeyEventArgs e)
        {
            // Exit game
            if (e.Code == Keyboard.Key.Escape)
            {
                Window.Close();
            }
            if (e.Code == Keyboard.Key.F3 != keys[Keyboard.Key.F3])
            {
                DebugRender.Enabled = !DebugRender.Enabled;
                keys[e.Code] = true;
            }
        }

        private static void Window_Realesed(object sender, KeyEventArgs e)
        {
            switch (e.Code)
            {
            case Keyboard.Key.F3:
            {
                keys[Keyboard.Key.F3] = false;
                break;
            }

            case Keyboard.Key.Num1:
            case Keyboard.Key.Num2:
            case Keyboard.Key.Num3:
            case Keyboard.Key.Num4:
            case Keyboard.Key.Num5:
            case Keyboard.Key.Num6:
            case Keyboard.Key.Num7:
            case Keyboard.Key.Num8:
            case Keyboard.Key.Num9:
            case Keyboard.Key.Num0:
            {
                for (int i = 0; i < Game.Player.Invertory.cells.Count; i++)
                    Game.Player.Invertory.cells[i].IsSelected = false;

                if (e.Code == Keyboard.Key.Num1)
                    Game.Player.Invertory.cells[0].IsSelected = true;
                else if (e.Code == Keyboard.Key.Num2)
                    Game.Player.Invertory.cells[1].IsSelected = true;
                else if (e.Code == Keyboard.Key.Num3)
                    Game.Player.Invertory.cells[2].IsSelected = true;
                else if (e.Code == Keyboard.Key.Num4)
                    Game.Player.Invertory.cells[3].IsSelected = true;
                else if (e.Code == Keyboard.Key.Num5)
                    Game.Player.Invertory.cells[4].IsSelected = true;
                else if (e.Code == Keyboard.Key.Num6)
                    Game.Player.Invertory.cells[5].IsSelected = true;
                else if (e.Code == Keyboard.Key.Num7)
                    Game.Player.Invertory.cells[6].IsSelected = true;
                else if (e.Code == Keyboard.Key.Num8)
                    Game.Player.Invertory.cells[7].IsSelected = true;
                else if (e.Code == Keyboard.Key.Num9)
                    Game.Player.Invertory.cells[8].IsSelected = true;
                else if (e.Code == Keyboard.Key.Num0)
                    Game.Player.Invertory.cells[9].IsSelected = true;

                break;
            }
            }
        }
    }
}

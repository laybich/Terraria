﻿using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace Terraria
{
    class Program
    {
        public static RenderWindow Window { private set; get; }

        static void Main(string[] args)
        {
            Window = new RenderWindow(new SFML.Window.VideoMode(1360, 720), "Terraria");

            Window.Closed += Window_Close;
            Window.Resized += Window_Resized;
            Window.KeyPressed += Window_Pressed;
            Window.KeyReleased += Window_Realesed;

            while (Window.IsOpen)
            {
                Window.DispatchEvents();

                Window.Clear(Color.Black);
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
            if (e.Code == Keyboard.Key.Escape)
            {
                Window.Close();
            }
        }

        private static void Window_Realesed(object sender, KeyEventArgs e)
        {

        }
    }
}
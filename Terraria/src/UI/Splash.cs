using SFML.Graphics;
using SFML.System;
using System;

namespace Terraria.UI
{
    class Splash : Transformable, Drawable
    {
        public static bool ShowSplash = true;
        private RectangleShape rectShape;
        private SpriteSheet spriteSheet;
        private int splashCounter = 0;
        byte color = 0;

        public Splash()
        {
            rectShape = new RectangleShape(new Vector2f(Program.Window.Size.X, Program.Window.Size.Y));
            rectShape.Texture = Content.texShplash;
        }

        public void Update()
        {
            splashCounter++;
            if (splashCounter <= 0x4b) color = (byte)((float)splashCounter / 0x4bf * 0xfff);
            else if (splashCounter <= 200) color = 0xff;
            else if (splashCounter < 0x113) color = (byte)((float)(0x113 - splashCounter) / 0x4bf * 0xfff);
            else ShowSplash = false;

            rectShape.FillColor = new Color(color, color, color);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            target.Draw(rectShape);
        }
    }
}

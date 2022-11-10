using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Terraria.UI
{
    class Splash : UIBase
    {
        public static bool ShowSplash = true;
        private int splashCounter = 0;
        byte color = 0;

        public Splash()
        {
            rectShape = new RectangleShape(new Vector2f(Program.Window.Size.X, Program.Window.Size.Y));
            rectShape.Texture = Content.texShplash;
        }

        public override void UpdateOver(Vector2i mousePos)
        {
        }

        public override void Update()
        {
            splashCounter++;
            if (splashCounter <= 0x4b) color = (byte)((float)splashCounter / 0x4bf * 0xfff);
            else if (splashCounter <= 200) color = 0xff;
            else if (splashCounter < 0x113) color = (byte)((float)(0x113 - splashCounter) / 0x4bf * 0xfff);
            else ShowSplash = false;

            rectShape.FillColor = new Color(color, color, color);

            base.Update();
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            if (ShowSplash)
            {
                states.Transform *= Transform;

                target.Draw(rectShape);
            }
        }
    }
}

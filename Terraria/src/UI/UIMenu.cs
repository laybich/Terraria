using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Terraria.UI
{
    class UIMenu : UIBase
    {
        public static bool MenuActive = true;
        public static int MenuMode = 0;
        RectangleShape logo;
        const int maxMenuItems = 11;
        Text[] menuItems = new Text[maxMenuItems];
        int iCount = 0;
        int iYStart = 250;
        int iXStart = (int) Program.Window.Size.X / 2;
        int iYGap = 80;
        int focusMenu = -1;
        int selectedMenu = -1;

        public UIMenu()
        {
            // Init background
            rectShape = new RectangleShape(new Vector2f(Program.Window.Size.X, Program.Window.Size.Y));
            rectShape.Texture = Content.texBackground;

            // Init logo
            logo = new RectangleShape(new Vector2f(Content.texLogo.Size.X, Content.texLogo.Size.Y));
            logo.Position = new Vector2f((float) Program.Window.Size.X / 2, 100f);
            logo.Origin = new Vector2f((float) Content.texLogo.Size.X / 2, (float) Content.texLogo.Size.Y / 2);
            logo.Texture = Content.texLogo;
        }

        public override void UpdateOver(Vector2i mousePos)
        {
        }

        public override void Update()
        {
            if (!MenuActive) return;

            // Check menu mode
            if (MenuMode == -1)
            {
                MenuMode = 0;
            }
            else if (MenuMode == 0)
            {
                menuItems[0] = new Text("Single Player", Content.font, 50);
                menuItems[1] = new Text("Exit", Content.font, 50);
                iCount = 3;

                // Exit
                if (selectedMenu == 1)
                {
                    Program.Window.Close();
                }

                // Single Player
                if (selectedMenu == 0)
                {
                    MenuActive = false;
                }
            }

            // Check over & press
            for (int i = 0; i < iCount; i++)
            {
                if (menuItems[i] != null)
                {
                    menuItems[i].Position = new Vector2f(iXStart, iYStart + (iYGap * i));
                    menuItems[i].Origin = new Vector2f(menuItems[i].GetGlobalBounds().Width / 2, menuItems[i].GetGlobalBounds().Height / 2);

                    var mousePos = Mouse.GetPosition(Program.Window);
                    FloatRect mouseRect = new FloatRect(new Vector2f(mousePos.X, mousePos.Y), new Vector2f(1f, 1f));
                    if (menuItems[i].GetGlobalBounds().Intersects(mouseRect))
                    {
                        focusMenu = i;
                        menuItems[i].Scale *= 1.1f;
                        DebugRender.AddRectangle(menuItems[i].GetGlobalBounds(), Color.Red);

                        if (Mouse.IsButtonPressed(Mouse.Button.Left))
                        {
                            selectedMenu = i;
                        }
                    }
                }
            }

            base.Update();
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            if (MenuActive)
            {
                states.Transform *= Transform;

                // Draw background
                target.Draw(rectShape);

                // Draw logo
                target.Draw(logo);

                // Draw menu items
                for (int i = 0; i < iCount; i++)
                {
                    if (menuItems[i] != null)
                    {
                        target.Draw(menuItems[i]);
                    }
                }
            }
        }
    }
}

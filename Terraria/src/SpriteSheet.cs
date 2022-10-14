using SFML.Graphics;
using System;

namespace Terraria
{
    class SpriteSheet
    {
        public int SubWidth { get; private set; }
        public int SubHeight { get; private set; }
        public int SubCountX { get; private set; }
        public int SubCountY { get; private set; }

        public Texture Texture;

        int borderSize;

        public SpriteSheet(int a, int b, int borderSize, Texture texture, bool isSmooth = true)
        {
            if (borderSize > 0) this.borderSize = borderSize + 1;
            else this.borderSize = 0;

            Texture = texture;
            texture.Smooth = isSmooth;

            SubWidth = a;
            SubHeight = b;
            SubCountX = (int)Math.Ceiling((float)texture.Size.X / a);
            SubCountY = (int)Math.Ceiling((float)texture.Size.Y / b);
        }

        public IntRect GetTextureRect(int i, int j)
        {
            int x = i * SubWidth + i * borderSize;
            int y = j * SubHeight + j * borderSize;
            return new IntRect(x, y, SubWidth, SubHeight);
        }
    }
}

using SFML.System;
using SFML.Graphics;

namespace Terraria
{
    class Tile : Transformable, Drawable
    {
        public const int TILE_SIZE = 16;
        RectangleShape rectShape;
        Texture texture;

        public Tile()
        {
            rectShape = new RectangleShape(new Vector2f(TILE_SIZE, TILE_SIZE));
            rectShape.Position = new Vector2f(380, 184);
            texture = new Texture("Content\\Textures\\Tiles_0.png");
            rectShape.Texture = texture;
            rectShape.TextureRect = new IntRect(0, 0, TILE_SIZE, TILE_SIZE);
        }

        public void UpdateView()
        {

        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            target.Draw(rectShape);
        }

        public FloatRect GetFloatRect()
        {
            return new FloatRect(Position, new Vector2f(TILE_SIZE, TILE_SIZE));
        }
    }
}

using SFML.System;
using SFML.Graphics;

namespace Terraria
{
    enum TileType
    {
        NONE,
        GROUND,
        GRASS
    }

    class Tile : Transformable, Drawable
    {
        public const int TILE_SIZE = 16;
        public TileType type = TileType.GROUND;
        public RectangleShape rectShape;
        Texture texture;

        public Tile(TileType type)
        {
            this.type = type;

            rectShape = new RectangleShape(new Vector2f(TILE_SIZE, TILE_SIZE));

            switch(type)
            {
                case TileType.GROUND:
                    texture = new Texture("Content\\Textures\\Tiles_0.png");
                    break;

                case TileType.GRASS:
                    texture = new Texture("Content\\Textures\\Tiles_1.png");
                    break;
            }

            rectShape.Texture = texture;
            rectShape.TextureRect = new IntRect(0, 0, TILE_SIZE, TILE_SIZE);

            UpdateView();
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

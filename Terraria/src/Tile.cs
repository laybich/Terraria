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

        public SpriteSheet SpriteSheet { get; set; }
        public TileType type = TileType.GROUND;
        public RectangleShape rectShape;

        public Tile(TileType type)
        {
            this.type = type;

            rectShape = new RectangleShape(new Vector2f(TILE_SIZE, TILE_SIZE));

            switch(type)
            {
                case TileType.GROUND:
                    SpriteSheet = Content.ssTileGround;
                    break;

                case TileType.GRASS:
                    SpriteSheet = Content.ssTileGrass;
                    break;
            }

            rectShape.Texture = SpriteSheet.Texture;
            rectShape.TextureRect = SpriteSheet.GetTextureRect(1, 1);

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

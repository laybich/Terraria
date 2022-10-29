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

        Tile upTile = null;
        Tile downTile = null;
        Tile leftTile = null;
        Tile rightTile = null;

        public Tile UpTile {
            set { upTile = value; UpdateView(); }
            get { return upTile; }
        }

        public Tile DownTile {
            set { downTile = value; UpdateView(); }
            get { return downTile; }
        }

        public Tile LeftTile {
            set { leftTile = value; UpdateView(); }
            get { return leftTile; }
        }

        public Tile RightTile {
            set { rightTile = value; UpdateView(); }
            get { return rightTile; }
        }

        public Tile(TileType type, Tile upTile, Tile downTile, Tile leftTile, Tile rightTile)
        {
            this.type = type;

            if (upTile != null)
            {
                this.upTile = upTile;
                this.upTile.DownTile = this;
            }
            if (downTile != null)
            {
                this.downTile = downTile;
                this.downTile.UpTile = this;
            }
            if (leftTile != null)
            {
                this.leftTile = leftTile;
                this.leftTile.RightTile = this;
            }
            if (rightTile != null)
            {
                this.rightTile = rightTile;
                this.rightTile.LeftTile = this;
            }

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

            UpdateView();
        }

        public void UpdateView()
        {
            int i = World.Rand.Next(0, 3);

            if (upTile != null && downTile != null && leftTile != null && rightTile != null)
                rectShape.TextureRect = SpriteSheet.GetTextureRect(1 + i, 1);

            else if (upTile == null && downTile == null && leftTile == null && rightTile == null)
                rectShape.TextureRect = SpriteSheet.GetTextureRect(9 + i, 3);

            else if (upTile == null && downTile != null && leftTile != null && rightTile != null)
                rectShape.TextureRect = SpriteSheet.GetTextureRect(1 + i, 0);
            else if (upTile != null && downTile == null && leftTile != null && rightTile != null)
                rectShape.TextureRect = SpriteSheet.GetTextureRect(1 + i, 2);
            else if (upTile != null && downTile != null && leftTile == null && rightTile != null)
                rectShape.TextureRect = SpriteSheet.GetTextureRect(0, i);
            else if (upTile != null && downTile != null && leftTile != null && rightTile == null)
                rectShape.TextureRect = SpriteSheet.GetTextureRect(4, i);

            else if (upTile == null && downTile != null && leftTile == null && rightTile != null)
                rectShape.TextureRect = SpriteSheet.GetTextureRect(0 + i * 2, 3);
            else if (upTile == null && downTile != null && leftTile != null && rightTile == null)
                rectShape.TextureRect = SpriteSheet.GetTextureRect(1 + i * 2, 3);
            else if (upTile != null && downTile == null && leftTile == null && rightTile != null)
                rectShape.TextureRect = SpriteSheet.GetTextureRect(0 + i * 2, 4);
            else if (upTile != null && downTile == null && leftTile != null && rightTile == null)
                rectShape.TextureRect = SpriteSheet.GetTextureRect(1 + i * 2, 4);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            target.Draw(rectShape, states);
        }

        public FloatRect GetFloatRect()
        {
            return new FloatRect(Position, new Vector2f(TILE_SIZE, TILE_SIZE));
        }
    }
}

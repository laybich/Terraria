using SFML.Graphics;

namespace Terraria
{
    class Content
    {
        public const string CONTENT_DIR = "Content\\";

        public static SpriteSheet ssTileGround;
        public static SpriteSheet ssTileGrass;

        public static void Load()
        {
            ssTileGround = new SpriteSheet(Tile.TILE_SIZE, Tile.TILE_SIZE, 1, new Texture(CONTENT_DIR + "Textures\\Tiles_0.png"));
            ssTileGrass = new SpriteSheet(Tile.TILE_SIZE, Tile.TILE_SIZE, 1, new Texture(CONTENT_DIR + "Textures\\Tiles_1.png"));
        }
    }
}

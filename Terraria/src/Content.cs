using SFML.Graphics;

namespace Terraria
{
    class Content
    {
        public const string CONTENT_DIR = "Content\\";

        public static SpriteSheet ssTileGround;
        public static SpriteSheet ssTileGrass;

        // NPC
        public static SpriteSheet ssNpcSlime;

        public static void Load()
        {
            ssTileGround = new SpriteSheet(Tile.TILE_SIZE, Tile.TILE_SIZE, false, 1, new Texture(CONTENT_DIR + "Textures\\Tiles_0.png"));
            ssTileGrass = new SpriteSheet(Tile.TILE_SIZE, Tile.TILE_SIZE, false, 1, new Texture(CONTENT_DIR + "Textures\\Tiles_1.png"));

            // NPC
            ssNpcSlime = new SpriteSheet(1, 2, true, 0, new Texture(CONTENT_DIR + "Textures\\NPC_16.png"));
        }
    }
}

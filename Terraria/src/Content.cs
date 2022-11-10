using SFML.Graphics;

namespace Terraria
{
    class Content
    {
        public const string CONTENT_DIR = "Content\\";

        // UI
        public static Texture texShplash;
        public static Texture texUIInvertoryBack;
        public static Font font;

        // Terrain
        public static SpriteSheet ssTileGround;
        public static SpriteSheet ssTileStone;
        public static SpriteSheet ssTileGrass;

        // NPC
        public static SpriteSheet ssNpcSlime;

        // Player
        public static SpriteSheet ssPlayerHair;
        public static SpriteSheet ssPlayerHands;
        public static SpriteSheet ssPlayerHead;
        public static SpriteSheet ssPlayerLegs;
        public static SpriteSheet ssPlayerShirt;
        public static SpriteSheet ssPlayerShoes;
        public static SpriteSheet ssPlayerUndershirt;

        public static void Load()
        {
            // UI
            texShplash = new Texture(CONTENT_DIR + "Textures\\splash.png");
            texUIInvertoryBack = new Texture(CONTENT_DIR + "Textures\\ui\\Inventory_Back.png");

            // Font
            font = new Font(CONTENT_DIR + "Fonts\\brushtype-normal.ttf");

            // Terrain
            ssTileGround = new SpriteSheet(Tile.TILE_SIZE, Tile.TILE_SIZE, false, 1, new Texture(CONTENT_DIR + "Textures\\Tiles_0.png"));
            ssTileStone = new SpriteSheet(Tile.TILE_SIZE, Tile.TILE_SIZE, false, 1, new Texture(CONTENT_DIR + "Textures\\Tiles_1.png"));
            ssTileGrass = new SpriteSheet(Tile.TILE_SIZE, Tile.TILE_SIZE, false, 1, new Texture(CONTENT_DIR + "Textures\\Tiles_2.png"));

            // NPC
            ssNpcSlime = new SpriteSheet(1, 2, true, 0, new Texture(CONTENT_DIR + "Textures\\NPC_16.png"));

            // Player
            ssPlayerHair = new SpriteSheet(1, 14, true, 0, new Texture(CONTENT_DIR + "Textures\\Player_Hair_29.png"));
            ssPlayerHands = new SpriteSheet(1, 20, true, 0, new Texture(CONTENT_DIR + "Textures\\Player_Hands.png"));
            ssPlayerHead = new SpriteSheet(1, 20, true, 0, new Texture(CONTENT_DIR + "Textures\\Player_Head.png"));
            ssPlayerLegs = new SpriteSheet(1, 20, true, 0, new Texture(CONTENT_DIR + "Textures\\Player_Pants.png"));
            ssPlayerShirt = new SpriteSheet(1, 20, true, 0, new Texture(CONTENT_DIR + "Textures\\Player_Shirt.png"));
            ssPlayerShoes = new SpriteSheet(1, 20, true, 0, new Texture(CONTENT_DIR + "Textures\\Player_Shoes.png"));
            ssPlayerUndershirt = new SpriteSheet(1, 20, true, 0, new Texture(CONTENT_DIR + "Textures\\Player_Undershirt.png"));
        }
    }
}

using SFML.Graphics;
using SFML.System;

namespace Terraria.Npc
{
    class NpcSlime : NPC
    {
        SpriteSheet spriteSheet;

        public NpcSlime(World world) : base(world)
        {
            spriteSheet = Content.ssNpcSlime;

            rect = new RectangleShape(new Vector2f(30, 40));
            rect.Origin = new Vector2f(rect.Size.X / 2, 0);
            rect.FillColor = new Color(0, 255, 0, 200);

            rect.Texture = spriteSheet.Texture;
            rect.TextureRect = spriteSheet.GetTextureRect(0, 0);
        }

        public override void UpdateNPC()
        {
            if (!isFly)
            {
                rect.TextureRect = spriteSheet.GetTextureRect(0, 0);
            }
            else
                rect.TextureRect = spriteSheet.GetTextureRect(0, 1);
        }

        public override void DrawNPC(RenderTarget target, RenderStates states)
        {
        }
    }
}

using SFML.Graphics;
using SFML.System;

namespace Terraria.Npc
{
    enum SlimeColors
    {
        Green,
        Blue,
        Red,
    }

    class NpcSlime : NPC
    {
        SpriteSheet spriteSheet;
        float waitTimer = 0f;

        public NpcSlime(World world) : base(world)
        {
            spriteSheet = Content.ssNpcSlime;

            rect = new RectangleShape(new Vector2f(spriteSheet.SubWidth / 1.5f, spriteSheet.SubHeight / 1.5f));
            rect.Origin = new Vector2f(rect.Size.X / 2, 0);

            SlimeColors color = (SlimeColors)World.Rand.Next(0, 3);

            if (color == SlimeColors.Green)
                rect.FillColor = new Color(0, 255, 0, 200);
            else if (color == SlimeColors.Blue)
                rect.FillColor = new Color(0, 0, 255, 200);
            else if (color == SlimeColors.Red)
                rect.FillColor = new Color(255, 0, 0, 200);

            rect.Texture = spriteSheet.Texture;
            rect.TextureRect = spriteSheet.GetTextureRect(0, 0);
        }

        public override void OnKill()
        {
            Spawn();
        }

        public override void OnWallCollided()
        {
            Direction *= -1;
            velocity = new Vector2f(-velocity.X * 0.8f, velocity.Y);
        }

        public override void UpdateNPC()
        {
            if (!isFly)
            {

                if (waitTimer >= World.Rand.Next(1, 5))
                {
                    velocity = GetJumpVelocity();
                    waitTimer = 0;
                }
                else
                {
                    waitTimer += 0.05f;
                    velocity.X = 0;
                }

                rect.TextureRect = spriteSheet.GetTextureRect(0, 0);
            }
            else
                rect.TextureRect = spriteSheet.GetTextureRect(0, 1);
        }

        public override void DrawNPC(RenderTarget target, RenderStates states)
        {
        }

        public virtual Vector2f GetJumpVelocity()
        {
            return new Vector2f(Direction * World.Rand.Next(1, 15), -World.Rand.Next(8, 15));
        }
    }
}

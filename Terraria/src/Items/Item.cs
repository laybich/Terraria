using Terraria.UI;
using SFML.Graphics;
using SFML.System;

namespace Terraria.Items
{
    abstract class Item : Entity
    {
        public const float MOVE_DISTANCE_TO_PLAYER = 100f;
        public const float TAKE_DISTANCE_TO_PLAYER = 20f;
        public const float MOVE_SPEED_COEF = 2f;

        InfoItem infoItem;

        public Item(World world, InfoItem infoItem) : base(world)
        {
            this.infoItem = infoItem;
            rect = new RectangleShape(new Vector2f(infoItem.SpriteSheet.SubWidth, infoItem.SpriteSheet.SubHeight));
            rect.Texture = infoItem.SpriteSheet.Texture;
            rect.TextureRect = infoItem.SpriteSheet.GetTextureRect(infoItem.SpriteI, infoItem.SpriteJ);
        }

        public override void Update()
        {
            Vector2f playerPos = Program.Game.Player.Position;
            float dist = MathHelper.GetDistance(Position, playerPos);

            isGhost = dist < MOVE_DISTANCE_TO_PLAYER;
            if (isGhost)
            {
                if (dist < TAKE_DISTANCE_TO_PLAYER)
                {
                    isDestroyed = true;

                    Program.Game.Player.Invertory.AddItemStack(new UIItemStack(infoItem, 1));
                }
                else
                {
                    Vector2f dir = MathHelper.Normalize(playerPos - Position);
                    float speed = 1f - dist / MOVE_DISTANCE_TO_PLAYER;
                    velocity += dir * speed * MOVE_SPEED_COEF;
                }
            }

            base.Update();
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            if (isRectVisible)
                target.Draw(rect, states);
        }
    }
}

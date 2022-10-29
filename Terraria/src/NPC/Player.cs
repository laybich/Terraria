using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Terraria.Npc
{
    class Player : NPC
    {
        public const float PLAYER_MOVE_SPEED = 4f;
        public const float PLAYER_MOVE_SPEED_ACCELERATION = 0.2f;


        public Color HairColor = new Color(255, 150, 0);
        public Color BodyColor = new Color(255, 209, 186);
        public Color ShirtColor = new Color(205, 255, 0);
        public Color LegsColor = new Color(10, 76, 135);

        AnimSprite asHair;
        AnimSprite asHead;
        AnimSprite asShirt;
        AnimSprite asUndershirt;
        AnimSprite asHands;
        AnimSprite asLegs;
        AnimSprite asShoes;

        public Player(World world) : base(world)
        {
            rect = new RectangleShape(new Vector2f(Tile.TILE_SIZE * 1.5f, Tile.TILE_SIZE * 2.8f));
            rect.Origin = new Vector2f(rect.Size.X / 2, 0);
            isRectVisible = false;

            // Hair
            asHair = new AnimSprite(Content.ssPlayerHair);
            asHair.Position = new Vector2f(0, 19);
            asHair.Color = HairColor;
            asHair.AddAnimation("idle", new Animation(
                new[] { new AnimationFrame(0, 0, 0.1f) }
            ));

            // Head
            asHead = new AnimSprite(Content.ssPlayerHead);
            asHead.Position = new Vector2f(0, 19);
            asHead.Color = BodyColor;
            asHead.AddAnimation("idle", new Animation(
                new[] { new AnimationFrame(0, 0, 0.1f) }
            ));

            // Shirt
            asShirt = new AnimSprite(Content.ssPlayerShirt);
            asShirt.Position = new Vector2f(0, 19);
            asShirt.Color = ShirtColor;
            asShirt.AddAnimation("idle", new Animation(
                new[] { new AnimationFrame(0, 0, 0.1f) }
            ));

            // Undershirt
            asUndershirt = new AnimSprite(Content.ssPlayerUndershirt);
            asUndershirt.Position = new Vector2f(0, 19);
            asUndershirt.Color = ShirtColor;
            asUndershirt.AddAnimation("idle", new Animation(
                new[] { new AnimationFrame(0, 0, 0.1f) }
            ));

            // Hands
            asHands = new AnimSprite(Content.ssPlayerHands);
            asHands.Position = new Vector2f(0, 19);
            asHands.Color = BodyColor;
            asHands.AddAnimation("idle", new Animation(
                new[] { new AnimationFrame(0, 0, 0.1f) }
            ));

            // Legs
            asLegs = new AnimSprite(Content.ssPlayerLegs);
            asLegs.Position = new Vector2f(0, 19);
            asLegs.Color = LegsColor;
            asLegs.AddAnimation("idle", new Animation(
                new[] { new AnimationFrame(0, 0, 0.1f) }
            ));

            // Shoes
            asShoes = new AnimSprite(Content.ssPlayerShoes);
            asShoes.Position = new Vector2f(0, 19);
            asShoes.Color = Color.Black;
            asShoes.AddAnimation("idle", new Animation(
                new[] { new AnimationFrame(0, 0, 0.1f) }
            ));
        }

        public override void OnKill()
        {
            Spawn();
        }

        public override void OnWallCollided()
        {
        }

        public override void UpdateNPC()
        {
            
        }

        public override void DrawNPC(RenderTarget target, RenderStates states)
        {
            target.Draw(asHead, states);
            target.Draw(asHair, states);
            target.Draw(asShirt, states);
            target.Draw(asUndershirt, states);
            target.Draw(asHands, states);
            target.Draw(asLegs, states);
            target.Draw(asShoes, states);
        }

        private void updateMovement()
        {
            movement = new Vector2f();

            asHair.Play("idle");
            asHead.Play("idle");
            asShirt.Play("idle");
            asUndershirt.Play("idle");
            asHands.Play("idle");
            asLegs.Play("idle");
            asShoes.Play("idle");
        }
    }
}

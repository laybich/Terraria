using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Terraria.UI;

namespace Terraria.Npc
{
    class Player : NPC
    {
        public const float PLAYER_MOVE_SPEED = 4f;
        public const float PLAYER_MOVE_SPEED_ACCELERATION = 0.2f;

        // Colors
        public Color HairColor = new Color(0xd7, 90, 0x37);
        public Color BodyColor = new Color(0xff, 0x7d, 90);
        public Color ShirtColor = new Color(0xaf, 0xa5, 140);
        public Color LegsColor = new Color(0xff, 230, 0xaf);

        // UI
        public UIInvertory Invertory;

        // Sprites with animation
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
            asHair.AddAnimation("run", new Animation(
                new [] {
                    new AnimationFrame(0, 0, 0.1f),
                    new AnimationFrame(0, 1, 0.1f),
                    new AnimationFrame(0, 2, 0.1f),
                    new AnimationFrame(0, 3, 0.1f),
                    new AnimationFrame(0, 4, 0.1f),
                    new AnimationFrame(0, 5, 0.1f),
                    new AnimationFrame(0, 6, 0.1f),
                    new AnimationFrame(0, 7, 0.1f),
                    new AnimationFrame(0, 8, 0.1f),
                    new AnimationFrame(0, 9, 0.1f),
                    new AnimationFrame(0, 10, 0.1f),
                    new AnimationFrame(0, 11, 0.1f),
                    new AnimationFrame(0, 12, 0.1f),
                    new AnimationFrame(0, 13, 0.1f),
                }
            ));

            // Head
            asHead = new AnimSprite(Content.ssPlayerHead);
            asHead.Position = new Vector2f(0, 19);
            asHead.Color = BodyColor;
            asHead.AddAnimation("idle", new Animation(
                new[] { new AnimationFrame(0, 0, 0.1f) }
            ));
            asHead.AddAnimation("run", new Animation(
                new[] {
                    new AnimationFrame(0, 6, 0.1f),
                    new AnimationFrame(0, 7, 0.1f),
                    new AnimationFrame(0, 8, 0.1f),
                    new AnimationFrame(0, 9, 0.1f),
                    new AnimationFrame(0, 10, 0.1f),
                    new AnimationFrame(0, 11, 0.1f),
                    new AnimationFrame(0, 12, 0.1f),
                    new AnimationFrame(0, 13, 0.1f),
                    new AnimationFrame(0, 14, 0.1f),
                    new AnimationFrame(0, 15, 0.1f),
                    new AnimationFrame(0, 16, 0.1f),
                    new AnimationFrame(0, 17, 0.1f),
                    new AnimationFrame(0, 18, 0.1f),
                    new AnimationFrame(0, 19, 0.1f),
                }
            ));

            // Shirt
            asShirt = new AnimSprite(Content.ssPlayerShirt);
            asShirt.Position = new Vector2f(0, 19);
            asShirt.Color = ShirtColor;
            asShirt.AddAnimation("idle", new Animation(
                new[] { new AnimationFrame(0, 0, 0.1f) }
            ));
            asShirt.AddAnimation("run", new Animation(
                new[] {
                    new AnimationFrame(0, 6, 0.1f),
                    new AnimationFrame(0, 7, 0.1f),
                    new AnimationFrame(0, 8, 0.1f),
                    new AnimationFrame(0, 9, 0.1f),
                    new AnimationFrame(0, 10, 0.1f),
                    new AnimationFrame(0, 11, 0.1f),
                    new AnimationFrame(0, 12, 0.1f),
                    new AnimationFrame(0, 13, 0.1f),
                    new AnimationFrame(0, 14, 0.1f),
                    new AnimationFrame(0, 15, 0.1f),
                    new AnimationFrame(0, 16, 0.1f),
                    new AnimationFrame(0, 17, 0.1f),
                    new AnimationFrame(0, 18, 0.1f),
                    new AnimationFrame(0, 19, 0.1f),
                }
            ));

            // Undershirt
            asUndershirt = new AnimSprite(Content.ssPlayerUndershirt);
            asUndershirt.Position = new Vector2f(0, 19);
            asUndershirt.Color = ShirtColor;
            asUndershirt.AddAnimation("idle", new Animation(
                new[] { new AnimationFrame(0, 0, 0.1f) }
            ));
            asUndershirt.AddAnimation("run", new Animation(
                new[] {
                    new AnimationFrame(0, 6, 0.1f),
                    new AnimationFrame(0, 7, 0.1f),
                    new AnimationFrame(0, 8, 0.1f),
                    new AnimationFrame(0, 9, 0.1f),
                    new AnimationFrame(0, 10, 0.1f),
                    new AnimationFrame(0, 11, 0.1f),
                    new AnimationFrame(0, 12, 0.1f),
                    new AnimationFrame(0, 13, 0.1f),
                    new AnimationFrame(0, 14, 0.1f),
                    new AnimationFrame(0, 15, 0.1f),
                    new AnimationFrame(0, 16, 0.1f),
                    new AnimationFrame(0, 17, 0.1f),
                    new AnimationFrame(0, 18, 0.1f),
                    new AnimationFrame(0, 19, 0.1f),
                }
            ));

            // Hands
            asHands = new AnimSprite(Content.ssPlayerHands);
            asHands.Position = new Vector2f(0, 19);
            asHands.Color = BodyColor;
            asHands.AddAnimation("idle", new Animation(
                new[] { new AnimationFrame(0, 0, 0.1f) }
            ));
            asHands.AddAnimation("run", new Animation(
                new[] {
                    new AnimationFrame(0, 6, 0.1f),
                    new AnimationFrame(0, 7, 0.1f),
                    new AnimationFrame(0, 8, 0.1f),
                    new AnimationFrame(0, 9, 0.1f),
                    new AnimationFrame(0, 10, 0.1f),
                    new AnimationFrame(0, 11, 0.1f),
                    new AnimationFrame(0, 12, 0.1f),
                    new AnimationFrame(0, 13, 0.1f),
                    new AnimationFrame(0, 14, 0.1f),
                    new AnimationFrame(0, 15, 0.1f),
                    new AnimationFrame(0, 16, 0.1f),
                    new AnimationFrame(0, 17, 0.1f),
                    new AnimationFrame(0, 18, 0.1f),
                    new AnimationFrame(0, 19, 0.1f),
                }
            ));

            // Legs
            asLegs = new AnimSprite(Content.ssPlayerLegs);
            asLegs.Position = new Vector2f(0, 19);
            asLegs.Color = LegsColor;
            asLegs.AddAnimation("idle", new Animation(
                new[] { new AnimationFrame(0, 0, 0.1f) }
            ));
            asLegs.AddAnimation("run", new Animation(
                new[] {
                    new AnimationFrame(0, 6, 0.1f),
                    new AnimationFrame(0, 7, 0.1f),
                    new AnimationFrame(0, 8, 0.1f),
                    new AnimationFrame(0, 9, 0.1f),
                    new AnimationFrame(0, 10, 0.1f),
                    new AnimationFrame(0, 11, 0.1f),
                    new AnimationFrame(0, 12, 0.1f),
                    new AnimationFrame(0, 13, 0.1f),
                    new AnimationFrame(0, 14, 0.1f),
                    new AnimationFrame(0, 15, 0.1f),
                    new AnimationFrame(0, 16, 0.1f),
                    new AnimationFrame(0, 17, 0.1f),
                    new AnimationFrame(0, 18, 0.1f),
                    new AnimationFrame(0, 19, 0.1f),
                }
            ));

            // Shoes
            asShoes = new AnimSprite(Content.ssPlayerShoes);
            asShoes.Position = new Vector2f(0, 19);
            asShoes.Color = Color.Black;
            asShoes.AddAnimation("idle", new Animation(
                new[] { new AnimationFrame(0, 0, 0.1f) }
            ));
            asShoes.AddAnimation("run", new Animation(
                new[] {
                    new AnimationFrame(0, 6, 0.1f),
                    new AnimationFrame(0, 7, 0.1f),
                    new AnimationFrame(0, 8, 0.1f),
                    new AnimationFrame(0, 9, 0.1f),
                    new AnimationFrame(0, 10, 0.1f),
                    new AnimationFrame(0, 11, 0.1f),
                    new AnimationFrame(0, 12, 0.1f),
                    new AnimationFrame(0, 13, 0.1f),
                    new AnimationFrame(0, 14, 0.1f),
                    new AnimationFrame(0, 15, 0.1f),
                    new AnimationFrame(0, 16, 0.1f),
                    new AnimationFrame(0, 17, 0.1f),
                    new AnimationFrame(0, 18, 0.1f),
                    new AnimationFrame(0, 19, 0.1f),
                }
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
            updateMovement();

            if (UIManager.Over == null && UIManager.Drag == null)
            {
                var mousePos = Mouse.GetPosition(Program.Window);
                var tile = world.GetTileByWorldPos(mousePos);

                // Update over tile
                if (tile != null)
                {
                    FloatRect tileRect = tile.GetFloatRect();
                    DebugRender.AddRectangle(tileRect, Color.Green);

                    // Remove tile
                    if (Mouse.IsButtonPressed(Mouse.Button.Left))
                    {
                        int i = (int)(mousePos.X / Tile.TILE_SIZE);
                        int j = (int)(mousePos.Y / Tile.TILE_SIZE);
                        world.SetTile(TileType.NONE, i, j);
                    }
                }

                // Set tile
                if (Mouse.IsButtonPressed(Mouse.Button.Right))
                {
                    int i = (int)(mousePos.X / Tile.TILE_SIZE);
                    int j = (int)(mousePos.Y / Tile.TILE_SIZE);

                    if (world.GetTile(i, j) == null)
                        world.SetTile(TileType.GROUND, i, j);
                }
            }
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
            bool isMoveLeft = Keyboard.IsKeyPressed(Keyboard.Key.A);
            bool isMoveRight = Keyboard.IsKeyPressed(Keyboard.Key.D);
            bool isMoveUp = Keyboard.IsKeyPressed(Keyboard.Key.Space);

            // Jump
            if (isMoveUp && !isFly) velocity.Y = -10f;

            if (isMoveLeft || isMoveRight)
            {
                if (isMoveLeft)
                {
                    if (movement.X > 0)
                        movement.X = 0;

                    movement.X -= PLAYER_MOVE_SPEED_ACCELERATION;
                    Direction = -1;
                }
                else if (isMoveRight)
                {
                    if (movement.X < 0)
                        movement.X = 0;

                    movement.X += PLAYER_MOVE_SPEED_ACCELERATION;
                    Direction = 1;
                }

                if (movement.X > PLAYER_MOVE_SPEED)
                    movement.X = PLAYER_MOVE_SPEED;
                else if (movement.X < -PLAYER_MOVE_SPEED)
                    movement.X = -PLAYER_MOVE_SPEED;

                // Animation
                asHair.Play("run");
                asHead.Play("run");
                asShirt.Play("run");
                asUndershirt.Play("run");
                asHands.Play("run");
                asLegs.Play("run");
                asShoes.Play("run");
            } else
            {
                movement = new Vector2f();

                // Animation
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
}

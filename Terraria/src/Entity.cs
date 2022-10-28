using SFML.Graphics;
using SFML.System;

namespace Terraria
{
    abstract class Entity : Transformable, Drawable
    {
        protected RectangleShape rect;
        protected Vector2f velocity;
        protected Vector2f movement;
        protected World world;
        protected bool isFly = true;
        protected bool isRectVisible = true;
        protected bool isGhost = false;

        public Entity(World world)
        {
            this.world = world;
        }

        public virtual void Update()
        {
            updatePhysics();
        }

        private void updatePhysics()
        {
            velocity.X *= 0.99f;
            velocity.Y += 0.55f;

            var offset = velocity + movement;
            float dist = MathHelper.GetDistance(offset);

            int countStep = 1;
            if (dist > (float)Tile.TILE_SIZE / 2)
                countStep = (int)(dist / (Tile.TILE_SIZE / 2));

            Vector2f nextPos = Position + offset;
            Vector2f stepPos = Position - rect.Origin;
            FloatRect stepRect;
            Vector2f stepVec = (nextPos - Position) / countStep;

            for (int step = 0; step < countStep; step++)
            {
                bool isBreakStep = false;

                stepPos += stepVec;
                stepRect = new FloatRect(stepPos, rect.Size);

                int i = (int)((stepPos.X + rect.Size.X / 2) / Tile.TILE_SIZE);
                int j = (int)((stepPos.Y + rect.Size.Y) / Tile.TILE_SIZE);
                Tile topTile = world.GetTile(i, j - (int)rect.Size.Y / 16);
                Tile downTile = world.GetTile(i, j);

                if (downTile != null)
                {
                    FloatRect tileRect = new FloatRect(downTile.Position, new Vector2f(Tile.TILE_SIZE, Tile.TILE_SIZE));

                    if (updateCollision(stepRect, tileRect))
                    {
                        velocity.Y = 0;
                        isFly = false;
                        isBreakStep = true;
                    }
                    else
                        isFly = true;
                }
                else
                    isFly = true;

                if (isBreakStep)
                    break;
            }

            Position = stepPos + rect.Origin;
        }

        bool updateCollision(FloatRect rectNPC, FloatRect rectTile)
        {
            if (rectNPC.Intersects(rectTile))
            {
                return true;
            }

            return false;
        }

        public abstract void Draw(RenderTarget target, RenderStates states);
    }
}

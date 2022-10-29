using SFML.Graphics;
using SFML.System;

namespace Terraria.Npc
{
    abstract class NPC : Entity
    {
        public Vector2f StartPosition;

        public int Direction
        {
            set
            {
                int dir = value >= 0 ? 1 : -1;
                Scale = new Vector2f(dir, 1);
            }
            get
            {
                return Scale.X >= 0 ? 1 : -1;
            }
        }

        public NPC(World world) : base(world)
        {
        }

        public void Spawn()
        {
            Position = StartPosition;
            velocity = new Vector2f();
        }

        public override void Update()
        {
            UpdateNPC();
            base.Update();

            // If npc fall down, kill it
            if (Position.Y > Program.Window.Size.Y)
                OnKill();
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            if (isRectVisible)
                target.Draw(rect, states);

            DrawNPC(target, states);
        }

        abstract public void OnKill();
        abstract public void UpdateNPC();
        abstract public void DrawNPC(RenderTarget target, RenderStates states);
    }
}

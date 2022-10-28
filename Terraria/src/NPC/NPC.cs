using SFML.Graphics;
using SFML.System;

namespace Terraria.Npc
{
    abstract class NPC : Entity
    {
        public Vector2f StartPosition;

        public NPC(World world) : base(world)
        {
        }

        public void Spawn()
        {
            Position = StartPosition;
        }

        public override void Update()
        {
            UpdateNPC();
            base.Update();
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            target.Draw(rect, states);

            DrawNPC(target, states);
        }

        abstract public void UpdateNPC();
        abstract public void DrawNPC(RenderTarget target, RenderStates states);
    }
}

using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace Terraria.UI
{
    class UIBase : Transformable, Drawable
    {
        public UIBase OldParent = null;
        public UIBase Parent = null;
        public List<UIBase> Childs = new List<UIBase>();

        public new Vector2i Position
        {
            get { return (Vector2i)base.Position; }
            set { base.Position = (Vector2f)value; }
        }

        public new Vector2i Origin
        {
            get { return (Vector2i)base.Origin; }
            set { base.Origin = (Vector2f)value; }
        }

        public new Vector2i GlobalPosition
        {
            get
            {
                if (Parent == null) return Position;
                else return Parent.GlobalPosition;

            }
        }

        public new Vector2i GlobalOrigin
        {
            get
            {
                if (Parent == null) return Origin;
                else return Parent.GlobalOrigin;

            }
        }

        public new int Width
        {
            get { return (int)rectShape.Size.X; }
            set { rectShape.Size = new Vector2f(value, rectShape.Size.Y); }
        }

        public new int Height
        {
            get { return (int)rectShape.Size.Y; }
            set { rectShape.Size = new Vector2f(rectShape.Size.X, value); }
        }

        public new Vector2i Size
        {
            get { return (Vector2i)rectShape.Size; }
            set { rectShape.Size = (Vector2f) value; }
        }

        public bool IsAllowDrag = false;
        public Vector2i DragOffset { get; private set; }

        protected RectangleShape rectShape;

        public virtual void UpdateOver(Vector2i mousePos)
        {
            var localMousePos = mousePos - GlobalPosition + GlobalOrigin;

            if (rectShape.GetLocalBounds().Contains(localMousePos.X, localMousePos.Y))
            {
                if (UIManager.Drag == null)
                {
                    Mouse.Button? btn = null;

                    if (Mouse.IsButtonPressed(Mouse.Button.Left))
                        btn = Mouse.Button.Left;
                    else if (Mouse.IsButtonPressed(Mouse.Button.Right))
                        btn = Mouse.Button.Right;

                    if (IsAllowDrag && btn.HasValue)
                        DragIt(btn.Value);
                }

                if (UIManager.Drag != this)
                    UIManager.Over = this;

                for (int i = 0; i < Childs.Count; i++)
                    Childs[i].UpdateOver(mousePos);
            }
        }

        public void DragIt(Mouse.Button btn)
        {
            var mousePos = Mouse.GetPosition(Program.Window);

            if (UIManager.Drag != null)
                UIManager.Drag.OnCancelDrag();

            UIManager.Drag = this;
            DragOffset = Parent != null ? mousePos - GlobalPosition : new Vector2i(Size.X / 2, 10);
            OnDragBegin(btn);
        }

        public virtual void Update()
        {
            foreach (var c in Childs)
                c.Update();
        }

        public virtual void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            target.Draw(rectShape, states);

            foreach (var c in Childs)
                if (c != UIManager.Drag)
                    target.Draw(c, states);
        }

        public virtual void OnDragBegin(Mouse.Button btn)
        {
            OldParent = Parent;

            if (Parent != null)
                Parent.Childs.Remove(this);

            Parent = null;
        }

        public virtual void OnDrop(UIBase ui)
        {

        }

        public virtual void OnCancelDrag()
        {
            if (OldParent != null)
                OldParent.Childs.Add(this);

            Parent = OldParent;
            Position = new Vector2i();
        }
    }
}

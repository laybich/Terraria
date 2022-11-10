using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace Terraria.UI
{
    class UIItemStack : UIBase
    {
        public UIInvertoryCell InvertoryCell { get; set; }
        public int itemCount = 0;
        public int ItemCount
        {
            get { return itemCount; }
            set
            {
                itemCount = value;
                textCount.DisplayedString = itemCount.ToString();

                var textRect = textCount.GetGlobalBounds();
                textCount.Position = new Vector2f((int)(rectShape.Size.X / 6), (int)(rectShape.Size.Y - textCount.CharacterSize - 5));
            }
        }

        public int ItemCountMax
        {
            get { return InfoItem.MaxCountInStack; }
        }

        public bool IsFull
        {
            get { return ItemCount >= ItemCountMax;  }
        }

        public InfoItem InfoItem { get; private set; }
        RectangleShape rectShapeImage;
        Text textCount;

        public UIItemStack(InfoItem infoItem, int count)
        {
            InfoItem = infoItem;
            IsAllowDrag = true;

            var rectSize = (Vector2f)Content.texUIInvertoryBack.Size;
            rectShape = new RectangleShape(rectSize);
            rectShape.FillColor = Color.Transparent;

            var imgSize = new Vector2f(infoItem.SpriteSheet.SubWidth, infoItem.SpriteSheet.SubHeight);
            rectShapeImage = new RectangleShape(imgSize);
            rectShapeImage.Position = rectSize / 2 - imgSize / 2;
            rectShapeImage.Texture = infoItem.SpriteSheet.Texture;
            rectShapeImage.TextureRect = infoItem.SpriteSheet.GetTextureRect(infoItem.SpriteI, infoItem.SpriteJ);

            textCount = new Text("0", Content.font, 13);

            ItemCount = count;
        }

        public override void OnDragBegin(Mouse.Button btn)
        {
            base.OnDragBegin(btn);

            if (InvertoryCell == null) return;

            if (btn == Mouse.Button.Left || itemCount == 1)
            {
                InvertoryCell.ItemStack = null;
            }
            else if (btn == Mouse.Button.Right)
            {
                double count = ItemCount / 2d;
                ItemCount = (int)Math.Ceiling(count);

                var newStack = new UIItemStack(InfoItem, (int)Math.Floor(count));
                newStack.DragIt(Mouse.Button.Left);
            }
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            base.Draw(target, states);
            states.Transform *= Transform;

            if (InvertoryCell != null)
                textCount.FillColor = InvertoryCell.IsSelected ? Color.Black : Color.White;

            target.Draw(rectShapeImage, states);
            target.Draw(textCount, states);
        }

        public override void OnDrop(UIBase ui)
        {
            if (ui is UIItemStack)
            {
                var itemSrc = ui as UIItemStack;
                var itemDest = this;

                if (itemSrc.InfoItem == itemDest.InfoItem)
                {
                    if (itemDest.ItemCount + itemSrc.ItemCount <= itemDest.ItemCountMax)
                        itemDest.ItemCount += itemSrc.ItemCount;
                    else
                    {
                        int srcCount = itemSrc.ItemCount;
                        itemSrc.ItemCount = itemDest.ItemCount;
                        itemDest.ItemCount = srcCount;
                        ui.OnCancelDrag();
                    }
                }
                else
                    ui.OnCancelDrag();
            }
        }
    }
}

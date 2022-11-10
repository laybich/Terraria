using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace Terraria.UI
{
    class UIInvertory : UIWindow
    {
        public List<UIInvertoryCell> cells = new List<UIInvertoryCell>();

        public UIInvertory()
        {
            IsVisibleTitleBar = false;
            BodyColor = Color.Transparent;

            int cellCount = 10;

            for (int i = 0; i < cellCount; i++)
                AddCell();

            cells[0].IsSelected = true;

            Size = new Vector2i((int)Content.texUIInvertoryBack.Size.X * cellCount, (int)Content.texUIInvertoryBack.Size.Y);
        }

        public void AddCell()
        {
            var cell = new UIInvertoryCell(this);
            cell.Position = new Vector2i(cells.Count * cell.Width, 0);
            cells.Add(cell);
            Childs.Add(cell);
        }

        // return free cell
        UIInvertoryCell GetNotFullCellByInfoItem(InfoItem infoItem)
        {
            foreach (var c in cells)
                if (c.ItemStack != null && c.ItemStack.InfoItem == infoItem && !c.ItemStack.IsFull)
                    return c;

            return null;
        }

        public bool AddItemStack(UIItemStack itemStack)
        {
            var cell = GetNotFullCellByInfoItem(itemStack.InfoItem);

            if (cell != null)
            {
                cell.ItemStack = itemStack;
                return true;
            }
            else
            {
                foreach (var c in cells)
                {
                    if (c.ItemStack == null)
                    {
                        c.ItemStack = itemStack;
                        return true;
                    }
                }
            }

            return false;
        }
    }
}

using Sapper_Soul.Classes.Model;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Sapper_Soul.Controls
{
    public class SelectMenu : Control
    {
        public Color BorderColor { get; set; } = Color.Black;

        public List<SubMenu> Items { get; private set; } = new List<SubMenu>();

        public SelectMenu()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            Size = new Size(250, 150);
            Dock = DockStyle.Left;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            int num = 0;
            foreach (SubMenu subMenu in Items)
            {
                if (e.Y > num && e.Y <= num + subMenu.Heigth + 10)
                {
                    subMenu.PerfomClick();
                    ChangeFocusSubMenu(subMenu);
                }
                num += subMenu.Heigth + 10;
            }
            Invalidate();
        }

        private void ChangeFocusSubMenu(SubMenu item)
        {
            if (!Items.Contains(item))
                return;
            foreach (SubMenu subMenu in Items)
            {
                if (subMenu.Invalidate == null)
                    subMenu.Invalidate = Invalidate;
                subMenu.isFocused = item == subMenu;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.Clear(Parent.BackColor);
            Rectangle rect1 = new Rectangle(0, 0, Width - 1, Height - 1);
            graphics.DrawRectangle(new Pen(new SolidBrush(BorderColor)), rect1);
            graphics.FillRectangle(new SolidBrush(BackColor), rect1);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            int y = 0;
            for (int index = 0; index < Items.Count; ++index)
            {
                Rectangle rect2 = new Rectangle(1, y, Width - 2, (int)graphics.MeasureString(Items[index].Text, Items[index].Font, Width, format).Height + 10);
                Items[index].Heigth = (int)graphics.MeasureString(Items[index].Text, Items[index].Font, Width, format).Height;
                y += (int)graphics.MeasureString(Items[index].Text, Items[index].Font, Width, format).Height + 10;
                graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black)), rect2);
                if (!Items[index].isFocused)
                    graphics.FillRectangle(new SolidBrush(Items[index].BackColor), rect2);
                else
                    graphics.FillRectangle(new SolidBrush(Items[index].BackColorIsFocused), rect2);
                graphics.DrawString(Items[index].Text, Items[index].Font, new SolidBrush(Items[index].ForeColor), rect2, format);
            }
        }
    }
}

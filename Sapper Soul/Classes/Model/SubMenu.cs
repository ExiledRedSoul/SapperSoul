using System;
using System.Drawing;

namespace Sapper_Soul.Classes.Model
{
    public class SubMenu
    {
        private string _Text = "";
        private bool _isFocused;

        public event Action Click;

        public string Text
        {
            get => _Text;
            set
            {
                _Text = value;
                Invalidate?.Invoke();
            }
        }

        public Color ForeColor { get; set; } = Color.Black;

        public Color BackColor { get; set; } = Color.White;

        public Color BackColorIsFocused { get; set; } = Color.Gray;

        public Font Font { get; set; }

        public int Heigth { get; set; }

        public Action Invalidate { get; set; }

        public bool isFocused
        {
            get =>_isFocused;
            set
            {
                _isFocused = value;
                Invalidate?.Invoke();
                if (!value)
                    return;
               Click?.Invoke();
            }
        }

        public void PerfomClick()
        {
            Click?.Invoke();
        }
    }
}

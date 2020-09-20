using Sapper_Soul.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sapper_Soul.Forms
{
    public partial class ExitGameDialogResult : Form
    {
        public Form OwnedForm { get; set; }
        public ExitGameDialogResult()
        {
            InitializeComponent();

            Load += ((o, e) =>
            {
                SetLocalized();
                int index = -1;
                foreach (FontFamily family in SapperStatic.FontCollection.Families)
                {
                    if (family.Name == "Jet Set")
                        index = SapperStatic.FontCollection.Families.ToList().IndexOf(family);
                }
                if (index >= 0)
                {
                    Font = new Font(SapperStatic.FontCollection.Families[0], 12f);
                    label1.Font = new Font(SapperStatic.FontCollection.Families[0], 32f);
                }
                else
                {
                    Font = new Font("Times new Roman", 12f);
                    label1.Font = new Font("Times new Roman", 32f);
                }
                StartPosition = FormStartPosition.Manual;
                Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2 - Height / 2);
                //Label label1 = this.label1;
                int x1 = Width / 2 - label1.Width / 2;
                Point location = label1.Location;
                int y1 = location.Y;
                Point point1 = new Point(x1, y1);
                label1.Location = point1;
                Button yesBtn = YesBtn;
                int x2 = Width / 2 - YesBtn.Width - 100;
                location = YesBtn.Location;
                int y2 = location.Y;
                Point point2 = new Point(x2, y2);
                yesBtn.Location = point2;
                Button noBtn = NoBtn;
                int x3 = Width / 2 + 100;
                location = YesBtn.Location;
                int y3 = location.Y;
                Point point3 = new Point(x3, y3);
                noBtn.Location = point3;
            });
            Paint += ((o, e) =>
            {
                Graphics graphics = e.Graphics;
                Rectangle rectangle = new Rectangle(1, 1, Width - 2, Height - 2);
                Pen pen = new Pen(Brushes.Black, 2f);
                Rectangle rect = rectangle;
                graphics.DrawRectangle(pen, rect);
            });
            YesBtn.Click += ClickBtn;
            NoBtn.Click += ClickBtn;
        }

        private void ClickBtn(object sender, EventArgs e)
        {
            switch ((sender as Button).DialogResult)
            {
                case DialogResult.Yes:
                    Application.Exit();
                    break;
                case DialogResult.No:
                    Close();
                    OwnedForm.BackColor = Color.White;
                    (OwnedForm as Main).SetEnableBtn(true);
                    break;
            }
        }

        private void SetLocalized()
        {
            label1.Text = SapperStatic.Localized.Text[5];
            YesBtn.Text = SapperStatic.Localized.Text[6];
            NoBtn.Text = SapperStatic.Localized.Text[7];
        }
    }
}

using Sapper_Soul.Classes;
using Sapper_Soul.Enumerlables;
using System.Drawing;
using System.Windows.Forms;

namespace Sapper_Soul.Forms
{
    public partial class Select_Lvls_Game : Form
    {
        public Form OwnedForm { get; set; }
        public Select_Lvls_Game()
        {
            InitializeComponent();

            SapperStatic.Localized.ChangeLocalized += () => ChangeLocalized();
            StartGameBtn.Click += (o, e) =>
            {
                Close();
                OwnedForm.BackColor = Color.White;
                (OwnedForm as Main).SetEnableBtn(false);
                Form1 form1 = new Form1(!OneLvl.Checked ? (!TwoLvl.Checked ? DifficultyLevels.Hard : DifficultyLevels.Medium) : DifficultyLevels.Easy);
                form1.TopLevel = false;
                form1.Font = Font;
                form1.OwnedForm = OwnedForm;
                OwnedForm.Controls.Add(form1);
                form1.Location = new Point(OwnedForm.Width / 2 - form1.Width / 2, OwnedForm.Height / 2 - form1.Height / 2);
                form1.BringToFront();
                form1.Show();
            };
            CancelSelectLvlBtn.Click += (o, e) =>
            {
                Close();
                OwnedForm.BackColor = Color.White;
                (OwnedForm as Main).SetEnableBtn(true);
            };
            ChangeLocalized();
            OneLvl.Checked = true;
        }
        private void ChangeLocalized()
        {
            SelectLevelLabel.Text = SapperStatic.Localized.Text[15];
            OneLvl.Text = SapperStatic.Localized.Text[16];
            TwoLvl.Text = SapperStatic.Localized.Text[17];
            ThreeLvl.Text = SapperStatic.Localized.Text[18];
            StartGameBtn.Text = SapperStatic.Localized.Text[19];
            CancelSelectLvlBtn.Text = SapperStatic.Localized.Text[20];
        }
    }
}

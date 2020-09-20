using Sapper_Soul.Classes;
using System.Drawing;
using System.Windows.Forms;

namespace Sapper_Soul.Forms
{
    public partial class PauseForm : Form
    {
        private Color defColor;
        public PauseForm(Form containForm, Form MainForm)
        {
            PauseForm pauseForm = this;
            InitializeComponent();
            defColor = containForm.BackColor;
            (MainForm as Main).BackColor = Color.Gray;
            containForm.BackColor = Color.Gray;
            FormClosed += (o, e) =>
            {
                (MainForm as Main).BackColor = Color.White;
                containForm.BackColor = pauseForm.defColor;
            };
            ResumeBtn.Click += (o, e) =>
            {
                SapperStatic.Resume();
                pauseForm.Close();
            };
            SettingsBtn.Click += (o, e) =>
            {
                SettingsForm settingsForm = new SettingsForm();
                settingsForm.TopLevel = false;
                containForm.Controls.Add((Control)settingsForm);
                settingsForm.Location = new Point(containForm.Width / 2 - settingsForm.Width / 2, containForm.Height / 2 - settingsForm.Height / 2);
                settingsForm.BringToFront();
                settingsForm.Show();
                SapperStatic.SettingsFormOpen = true;
            };
            MainMenuBtn.Click += (o, e) =>
            {
                pauseForm.Close();
                containForm.Close();
                SapperStatic.isPause = false;
            };
            ExitToApplicationBtn.Click += (o, e) => Application.Exit();
            SetLocalized();
            SapperStatic.Localized.ChangeLocalized += () => pauseForm.SetLocalized();
            for (int index = 0; index < SapperStatic.FontCollection.Families.Length; index++)
            {
                if (SapperStatic.FontCollection.Families[index].Name == "Jet Set")
                {
                    Font font = new Font(SapperStatic.FontCollection.Families[index], 20f);
                    ResumeBtn.Font = font;
                    SettingsBtn.Font = font;
                    MainMenuBtn.Font = font;
                    ExitToApplicationBtn.Font = font;
                }
            }
        }

        private void SetLocalized()
        {
            ResumeBtn.Text = SapperStatic.Localized.Text[25];
            SettingsBtn.Text = SapperStatic.Localized.Text[2];
            MainMenuBtn.Text = SapperStatic.Localized.Text[24];
            ExitToApplicationBtn.Text = SapperStatic.Localized.Text[4];
        }
    }
}

using Sapper_Soul.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sapper_Soul.Forms
{
    public partial class Main : Form
    {
        private Font font;
        public Main()
        {
            InitializeComponent();
            SetLocalized();

            string str = Application.StartupPath + "\\Resources\\Font\\Jet Set.ttf";
            if (File.Exists(str))
                SapperStatic.FontCollection.AddFontFile(str);
            else
                SapperStatic.Logger.AddLog(string.Format("CODE: 0x22 | Отсуствует файл шрифта: \"{0}\" |Date: {1}|", str, DateTime.Now));
            Load += (o, e) => Updates();
            SizeChanged += (o, e) => Updates();
            StartGameBtn.Click += (o, e) =>
            {
                Select_Lvls_Game selectLvlsGame = new Select_Lvls_Game();
                selectLvlsGame.TopLevel = false;
                this.BackColor = Color.Gray;
                this.SetEnableBtn(false);
                selectLvlsGame.OwnedForm = this;
                this.Controls.Add(selectLvlsGame);
                selectLvlsGame.Location = new Point(this.Width / 2 - selectLvlsGame.Width / 2, this.Height / 2 - selectLvlsGame.Height / 2);
                selectLvlsGame.Font = Font;
                selectLvlsGame.BringToFront();
                selectLvlsGame.Show();
            };
            SettingsGameBtn.Click += ((o, e) =>
            {
                SettingsForm settingsForm = new SettingsForm();
                settingsForm.TopLevel = false;
                BackColor = Color.Gray;
                SetEnableBtn(false);
                settingsForm.OwnedForm = this;
                Controls.Add(settingsForm);
                settingsForm.Size = new Size(1200, 720);
                settingsForm.Location = new Point(this.Width / 2 - settingsForm.Width / 2, this.Height / 2 - settingsForm.Height / 2);
                settingsForm.Font = this.Font;
                settingsForm.BringToFront();
                settingsForm.Show();
            });
            ExitApplicationBtn.Click += (o, e) =>
            {
                ExitGameDialogResult gameDialogResult = new ExitGameDialogResult();
                gameDialogResult.TopLevel = false;
                BackColor = Color.Gray;
                SetEnableBtn(false);
                gameDialogResult.Location = new Point(Width / 2 - gameDialogResult.Width / 2, Height / 2 - gameDialogResult.Height / 2);
                gameDialogResult.OwnedForm = this;
                Controls.Add(gameDialogResult);
                gameDialogResult.BringToFront();
                gameDialogResult.Show();
            };
            SapperStatic.Localized.ChangeLocalized += () => SetLocalized();
            panel1.Paint += (o, e) =>
            {
                Graphics graphics = e.Graphics;
                Font font = new Font(Font.FontFamily, 72f, Font.Style);
                graphics.DrawString(Text, font, new SolidBrush(ForeColor), (panel1.Width / 2) - graphics.MeasureString(Text, font).Width / 2f, 20f);
            };
        }

        public void SetEnableBtn(bool enabled)
        {
            StartGameBtn.Enabled = enabled;
            SettingsGameBtn.Enabled = enabled;
            AboutBtn.Enabled = enabled;
            ExitApplicationBtn.Enabled = enabled;
        }

        private void Updates()
        {
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
            int width = workingArea.Width;
            workingArea = Screen.PrimaryScreen.WorkingArea;
            int height = workingArea.Height;
            Size = new Size(width, height);
            SetFonts();
            panel1.Location = new Point(Width / 2 - panel1.Width / 2, Height / 2 - panel1.Height / 2);
            StartGameBtn.Location = new Point(panel1.Width / 2 - StartGameBtn.Width / 2, StartGameBtn.Location.Y);
            SettingsGameBtn.Location = new Point(panel1.Width / 2 - SettingsGameBtn.Width / 2, SettingsGameBtn.Location.Y);
            AboutBtn.Location = new Point(panel1.Width / 2 - AboutBtn.Width / 2, AboutBtn.Location.Y);
            ExitApplicationBtn.Location = new Point(panel1.Width / 2 - ExitApplicationBtn.Width / 2, ExitApplicationBtn.Location.Y);
        }

        private void SetFonts()
        {
            if (SapperStatic.FontCollection.Families.Length != 0)
            {
                bool flag = false;
                int index1 = -1;
                for (int index2 = 0; index2 < SapperStatic.FontCollection.Families.Length; index2++)
                {
                    if (SapperStatic.FontCollection.Families[index2].Name == "Jet Set")
                    {
                        flag = true;
                        index1 = index2;
                    }
                }
                if (flag)
                {
                    font = new Font(SapperStatic.FontCollection.Families[index1], 12f);
                    SapperStatic.Logger.AddLog("Шрифт \"" + SapperStatic.FontCollection.Families[index1].Name + "\" успешно установлен!");
                }
                else
                {
                    font = new Font("Times new Roman", 12f);
                    SapperStatic.Logger.AddLog("Шрифт \"Jet Set\" не существует в коллекций. Установлен шрифт \"Times new Roman\"");
                }
                Font = font;
                StartGameBtn.Font = new Font(font.FontFamily, 20f, FontStyle.Bold);
                SettingsGameBtn.Font = StartGameBtn.Font;
                AboutBtn.Font = StartGameBtn.Font;
                ExitApplicationBtn.Font = StartGameBtn.Font;
            }
            Invalidate();
        }

        private void SetLocalized()
        {
            Text = SapperStatic.Localized.Text[0];
            StartGameBtn.Text = SapperStatic.Localized.Text[1];
            SettingsGameBtn.Text = SapperStatic.Localized.Text[2];
            AboutBtn.Text = SapperStatic.Localized.Text[3];
            ExitApplicationBtn.Text = SapperStatic.Localized.Text[4];
        }
    }
}

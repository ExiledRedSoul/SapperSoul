using Sapper_Soul.Classes;
using Sapper_Soul.Classes.Model;
using Sapper_Soul.Controls;
using Sapper_Soul.Enumerlables;
using Sapper_Soul.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace Sapper_Soul.Forms
{
    public partial class SettingsForm : Form
    {
        private int _CountChange;
        private SelectMenu menu;

        public int CountChange
        {
            get => _CountChange;
            set
            {
                _CountChange = value;
                if (value != 0)
                    ApplyBtn.Enabled = true;
                else
                    ApplyBtn.Enabled = false;
            }
        }

        public Form OwnedForm { get; set; }

        public SettingsForm()
        {
            InitializeComponent();

            SetFonts();
            SaveAndExitBtn.Click += (o, e) =>
            {
                SaveSettings();
                CancelBtn.PerformClick();
            };
            ApplyBtn.Click += (o, e) => SaveSettings();
            CancelBtn.Click += (o, e) =>
            {
                Close();
                if (OwnedForm != null)
                {
                    OwnedForm.BackColor = Color.White;
                    (OwnedForm as Main).SetEnableBtn(true);
                }
                SapperStatic.SettingsFormOpen = false;
            };
            menu = new SelectMenu();
            Controls.Add(menu);
            SubMenu subMenu1 = new SubMenu()
            {
                BackColor = BackColor,
                Font = new Font(Font.FontFamily, 22f, Font.Style),
                ForeColor = ForeColor,
                Invalidate = Invalidate
            };
            subMenu1.Click += () =>
            {
                GeneralPanel.Dock = DockStyle.Fill;
                GeneralPanel.Visible = true;
            };
            menu.Items.Add(subMenu1);
            SubMenu subMenu2 = new SubMenu()
            {
                BackColor = BackColor,
                Font = new Font(Font.FontFamily, 22f, Font.Style),
                ForeColor = ForeColor,
                Text = "Видео",
                Invalidate = Invalidate
            };
            subMenu2.Click += () => GeneralPanel.Visible = false;
            menu.Items.Add(subMenu2);
            menu.Items[0].isFocused = true;
            ChangeLocalized();
            SelectLanguage.SelectedIndex = (int)Settings.Default.Language;
            SelectLanguage.SelectedIndexChanged += (o, e) =>
            {
                if ((LocalizedName)SelectLanguage.SelectedIndex != Settings.Default.Language)
                {
                    CountChange++;
                    SelectLanguage.Tag = true;
                }
                else
                {
                    if (SelectLanguage.Tag == null || !(bool)SelectLanguage.Tag)
                        return;
                    CountChange--;
                }
            };
            SapperStatic.Localized.ChangeLocalized += () => ChangeLocalized();
        }

        private void SaveSettings()
        {
            Settings.Default.Language = (LocalizedName)SelectLanguage.SelectedIndex;
            Settings.Default.Save();
            SapperStatic.Localized.SetLocalized((LocalizedName)SelectLanguage.SelectedIndex);
        }

        private void ChangeLocalized()
        {
            LabelLanguage.Text = SapperStatic.Localized.Text[10];
            SelectLanguage.Items.Clear();
            SelectLanguage.Items.Add(SapperStatic.Localized.Text[9]);
            SelectLanguage.Items.Add(SapperStatic.Localized.Text[8]);
            SelectLanguage.SelectedIndex = (int)Settings.Default.Language;
            CancelBtn.Text = SapperStatic.Localized.Text[12];
            ApplyBtn.Text = SapperStatic.Localized.Text[13];
            SaveAndExitBtn.Text = SapperStatic.Localized.Text[14];
            menu.Items[0].Text = SapperStatic.Localized.Text[11];
        }

        private void SetFonts()
        {
            if (SapperStatic.FontCollection.Families.Length != 0)
            {
                bool flag = false;
                int index1 = -1;
                for (int index2 = 0; index2 < SapperStatic.FontCollection.Families.Length; ++index2)
                {
                    if (SapperStatic.FontCollection.Families[index2].Name == "Jet Set")
                    {
                        flag = true;
                        index1 = index2;
                    }
                }
                Font font;
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
            }
            Invalidate();
        }
    }
}

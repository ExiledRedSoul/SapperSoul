using Sapper_Soul.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sapper_Soul.Classes
{
    public static class SapperStatic
    {
        public static event Action PauseGame;

        public static event Action ResumeGame;

        public static System.Drawing.Text.PrivateFontCollection FontCollection { get; private set; } = new System.Drawing.Text.PrivateFontCollection();

        public static Logger Logger { get; private set; } = new Logger(Application.StartupPath);

        public static Localized Localized { get; private set; } = new Localized(Settings.Default.Language);

        public static System.Drawing.Color BorderColor { get; private set; } = System.Drawing.ColorTranslator.FromHtml("#757575");

        public static System.Drawing.Color BackColor { get; private set; } = System.Drawing.ColorTranslator.FromHtml("#b9b9b9");

        public static bool SettingsFormOpen { get; set; } = false;

        public static bool isPause { get; set; } = false;

        public static void Pause()
        {
            isPause = true;
            PauseGame?.Invoke();
        }

        public static void Resume()
        {
            isPause = false;
            ResumeGame?.Invoke();
        }
    }
}

using Newtonsoft.Json;
using Sapper_Soul.Classes.Model;
using Sapper_Soul.Enumerlables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Sapper_Soul.Classes
{
    public class Localized
    {
        public event Action ChangeLocalized;
        public LocalizedName LocalizedName { get; private set; }
        public List<string> Text { get; private set; } = new List<string>();

        public Localized(LocalizedName localized)
        {
            LocalizedName = localized;
            DeserializationJsonLocalized(LocalizedName);
        }

        public void SetLocalized(LocalizedName localized)
        {
            LocalizedName = localized;
            DeserializationJsonLocalized(LocalizedName);
            ChangeLocalized?.Invoke();
        }

        private void DeserializationJsonLocalized(LocalizedName localized)
        {
            string str = "";
            switch (localized)
            {
                case LocalizedName.Ru:
                    str = "Ru";
                    break;
                case LocalizedName.En:
                    str = "En";
                    break;
            }
            using (StreamReader streamReader = new StreamReader(Application.StartupPath + "\\Resources\\LocalizedText\\LocalizedText_" + str + ".json"))
            {
                JsonObjectLocalized jsonObjectLocalized = JsonConvert.DeserializeObject<JsonObjectLocalized>(streamReader.ReadToEnd());
                Text.Clear();
                Text.AddRange(jsonObjectLocalized.TextArray);
            }
            
        }
    }
}

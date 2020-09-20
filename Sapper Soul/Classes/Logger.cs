using System.IO;

namespace Sapper_Soul.Classes
{
    public class Logger
    {
        private StreamWriter StreamWriter;

        private string PathFile { get; set; }
        public bool isLogger { get; set; } = true;

        //public Logger()
        //{
        //    if (!Directory.Exists(Application.StartupPath + "\\Logs"))
        //        Directory.CreateDirectory(Application.StartupPath + "\\Logs");
        //    if (!File.Exists(Application.StartupPath + "\\Logs\\log.txt"))
        //        File.Create(Application.StartupPath + "\\Logs\\log.txt").Close();
        //    this.PathFile = Application.StartupPath + "\\Logs\\log.txt";
        //}

        public Logger(string path) => SetFilePath(path);

        public void SetFilePath(string path)
        {
            path += "\\Logs";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            path += "\\log.txt";
            if (File.Exists(path))
                PathFile = path;
            else
                File.Create(path).Close();

            PathFile = path;
        }

        public void AddLog(string strLog)
        {
            if (!isLogger)
                return;
            string str = "";
            using (StreamReader streamReader = new StreamReader(PathFile))
                str = streamReader.ReadToEnd();
            using (StreamWriter = new StreamWriter(PathFile))
                StreamWriter.WriteLine(str + strLog + "\n");
        }

        public void ClearLog()
        {
            using (StreamWriter = new StreamWriter(PathFile))
                StreamWriter.Write("");
        }
    }
}

using System.IO;

namespace BartenderUI.Util
{
    class FileWriter
    {
        public static void SaveFile(string path, string content)
        {
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(content);
            sw.Close();
        }
    }
}

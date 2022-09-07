using System;
using System.Drawing;
using System.IO;

namespace BartenderUI.Util
{
    class ImageUtil
    {
        public static void SaveImage(string path, string base64String)
        {
            byte[] bytes = Convert.FromBase64String(base64String);

            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }

            image.Save(path);
        }

        public static void SaveIcon(string path, string base64String)
        {
            byte[] bytes = Convert.FromBase64String(base64String);

            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }

            using (FileStream stream = File.OpenWrite(path))
            {
                Bitmap bitmap = image as Bitmap;
                Icon.FromHandle(bitmap.GetHicon()).Save(stream);
            }
        }
    }
}

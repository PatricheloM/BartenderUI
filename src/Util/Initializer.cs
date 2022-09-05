using System.IO;
using BartenderUI.Util.Structs;
using BartenderUI.Util.HelperTypes;

namespace BartenderUI.Util
{
    class Initializer
    {
        public static void Initialize()
        {
            foreach (string directory in FileStruct.Directories)
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
            }

            foreach (FileDetails details in FileStruct.Files)
            {
                if (!File.Exists(details.Path))
                {
                    switch (details.Type)
                    {
                        case FileTypeEnum.Image:
                            ImageUtil.SaveImage(details.Path, details.Content);
                            break;
                        case FileTypeEnum.Icon:
                            ImageUtil.SaveIcon(details.Path, details.Content);
                            break;
                        case FileTypeEnum.Json:
                            FileWriter.SaveFile(details.Path, details.Content);
                            break;
                    }
                }
            }
        }
    }
}

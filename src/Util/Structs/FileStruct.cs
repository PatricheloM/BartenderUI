using BartenderUI.Util.HelperTypes;

namespace BartenderUI.Util.Structs
{
    struct FileStruct
    {
        private const string ResourcesDir = FilePathStruct.Resources;
        private const string ImgDir = FilePathStruct.Img;

        private static readonly FileDetails Settings = new FileDetails(FilePathStruct.Settings, FileTypeEnum.Json, JsonStruct.SettingsDefault);
        private static readonly FileDetails Icon = new FileDetails(FilePathStruct.Icon, FileTypeEnum.Icon, Base64Struct.Icon);
        private static readonly FileDetails Szabad = new FileDetails(FilePathStruct.Szabad, FileTypeEnum.Image, Base64Struct.Szabad);
        private static readonly FileDetails Foglalt = new FileDetails(FilePathStruct.Foglalt, FileTypeEnum.Image, Base64Struct.Foglalt);

        public static string[] Directories = { ResourcesDir, ImgDir };

        public static FileDetails[] Files = { Settings, Icon, Szabad, Foglalt };
    }
}

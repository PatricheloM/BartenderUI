namespace BartenderUI.Util.HelperTypes
{
    class FileDetails
    {
        public string Path { get; private set; }
        public FileTypeEnum Type { get; private set; } 
        public string Content { get; private set; }

        public FileDetails(string path, FileTypeEnum type, string content)
        {
            Path = path;
            Type = type;
            Content = content;
        }
    }
}

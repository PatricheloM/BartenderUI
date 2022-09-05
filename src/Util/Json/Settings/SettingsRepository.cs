using BartenderUI.Util.Structs;

namespace BartenderUI.Util.Json.Settings
{
    class SettingsRepository : JsonHandling<Settings>
    {
        private static readonly SettingsRepository instance = new SettingsRepository();

        private SettingsRepository() : base(FilePathStruct.Settings)
        {
        }

        public static Settings GetSettings()
        {
            return instance.JsonObject;
        }
    }
}

using System.Collections.Generic;

namespace AppUX.Constants
{
    public static class AppConstants
    {
        public const string JsonSettingsFilePath = @"./setting.json";
        public const string UserFilePath         = @"C:\Users\micro\Desktop";
        public const string ResourcesFolder      = @"Resources/";
        public const string ExcelFile            = @"Excel";
        public const string WordFile             = @"Word";
        public const string TextFile             = @"Text";
        public const string DarkTheme            = @"Dark";
        public const string LightTheme           = @"Light";
        public const string Ascending            = @"ASC";
        public const string Descending           = @"DESC";

        public static Dictionary<string, string> LanguagesDictionary = new Dictionary<string, string>()
        {
            { "Русский", "RU-ru" },
            { "English", "En-en" },
            { "Français", "FR-fr" },
            { "Deutsch", "DE-de" }
        };

        public static Dictionary<int, string> ThemeDictionary = new Dictionary<int, string>()
        {
            { 0, DarkTheme },
            { 1, LightTheme }
        };

        public static Dictionary<int, string> FileTypeDictionary = new Dictionary<int, string>()
        {
            { 0, ExcelFile },
            { 1, WordFile },
            { 2, TextFile }
        };
    }
}

using System.Text.Json;
using System.Text.Json.Serialization;

namespace PluginConflictChecker
{
    public class Settings
    {
        public static readonly string SettingsVersion = "1.5";
        [JsonIgnore]
        public bool Valid = true;
        [JsonIgnore]
        public string LoadError { get; private set; } = String.Empty;

        [JsonInclude, JsonPropertyOrder(order: 1)]
        public string Version = String.Empty;
        [JsonInclude, JsonPropertyOrder(order: 2)]
        public bool Fallout4 = false;
        [JsonInclude, JsonPropertyOrder(order: 3)]
        public string PluginTXTPath { get; set; } = String.Empty;
        [JsonInclude, JsonPropertyOrder(order: 4)]
        public string DataFolder { get; set; } = String.Empty;
        [JsonInclude, JsonPropertyOrder(order: 5)]
        public string OutputName { get; set; } = String.Empty;//1.5
        [JsonInclude, JsonPropertyOrder(order: 6)]
        public bool FilterOutMasterOverrides = true;
        [JsonInclude, JsonPropertyOrder(order: 7)]
        public bool OutputToSeperateFiles = false;
        [JsonInclude, JsonPropertyOrder(order: 8)]
        public bool Explorer = false;
        [JsonInclude, JsonPropertyOrder(order: 9)]
        public bool OutputJson = false;
        [JsonInclude, JsonPropertyOrder(order: 10)]
        public FilterSettings FilterSettings { get; set; } = new FilterSettings();

        public static Settings Load(string path = "PluginConflictChecker_AppSettings.json")
        {
            try
            {
                Settings settings = JsonSerializer.Deserialize<Settings>(File.ReadAllText(path))!;
                if (settings.Version.Equals(SettingsVersion)) return settings;

                settings.Valid = false;
                settings.Version = SettingsVersion;
                File.WriteAllText(path, JsonSerializer.Serialize(settings, new JsonSerializerOptions()
                {
                    WriteIndented = true
                }));
                settings.LoadError = "Settings has been updated. Please view the Settings on the Skyrim Special Eddition page for new settings you might want.";
                return settings;
            }
            catch (FileNotFoundException)
            {
                GF.WriteLine("Generating AppSettings.json file.");
                GF.WriteLine("Settings has been Generated. Please view the Settings on the Skyrim Special Eddition page for new settings you might want.");
                GF.WriteLine("Please Rerun Program");
                Settings settings = new();
                settings.Version = SettingsVersion;
                File.WriteAllText(path, JsonSerializer.Serialize(settings, new JsonSerializerOptions()
                {
                    WriteIndented = true
                }));
                settings.Valid = false;
                return settings;
            }
            catch (Exception e)
            {
                GF.WriteLine(e.StackTrace!);
                GF.WriteLine(e.Message);
                GF.WriteLine("Check for single \\ they should be doubled \\\\");

                return new Settings(false);
            }
        }

        public void Write(string path)
        {
            File.WriteAllText(path, JsonSerializer.Serialize(this, new JsonSerializerOptions()
            {
                WriteIndented = true
            }));
        }

        public Settings() { }

        public Settings(bool valid)
        {
            Valid = valid;
        }
    }

    public class FilterSettings
    {
        [JsonInclude, JsonPropertyOrder(order: 1)]
        public int MinCountToOutput { get; set; } = 0;
        [JsonInclude, JsonPropertyOrder(order: 2)]
        public bool OnlyIncludeTypeFilter { get; set; } = false;
        [JsonInclude, JsonPropertyOrder(order: 3)]
        public HashSet<string> TypeFilter { get; set; } = new HashSet<string>();
    }
}

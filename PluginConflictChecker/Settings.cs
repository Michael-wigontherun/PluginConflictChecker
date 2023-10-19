using System.Text.Json;
using System.Text.Json.Serialization;

namespace PluginConflictChecker
{
    public class Settings
    {
        [JsonIgnore]
        public bool Valid = true;

        [JsonInclude]
        public string PluginTXTPath { get; set; } = String.Empty;
        [JsonInclude]
        public string DataFolder { get; set; } = String.Empty;
        [JsonInclude]
        public bool FilterOutMasterOverrides = true;
        [JsonInclude]
        public bool OutputToSeperateFiles = false;
        [JsonInclude]
        public bool Explorer = false;
        [JsonInclude]
        public FilterSettings FilterSettings { get; set; } = new FilterSettings();

        public static Settings Load()
        {
            try
            {
                return JsonSerializer.Deserialize<Settings>(File.ReadAllText("AppSettings.json"))!;
            }
            catch (FileNotFoundException)
            {
                GF.WriteLine("Generating AppSettings.json file.");
                GF.WriteLine("Please Rerun Program");

                return new Settings(false);
            }
            catch (Exception e)
            {
                GF.WriteLine(e.StackTrace!);
                GF.WriteLine(e.Message);
                GF.WriteLine("Check for single \\ they should be doubled \\\\");

                return new Settings(false);
            }
        }

        public Settings() { }

        public Settings(bool valid)
        {
            Valid = valid;
        }
    }

    public class FilterSettings
    {
        [JsonInclude]
        public int MinCountToOutput { get; set; } = 0;
        [JsonInclude]
        public HashSet<string> TypeFilter { get; set; } = new HashSet<string>();
    }
}

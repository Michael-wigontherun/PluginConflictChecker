namespace PluginConflictChecker
{
    public class ConflictsByModName
    {
        public string PluginName { get; set; } = String.Empty;
        public HashSet<Conflict> Conflicts { get; set; } = new();

        public ConflictsByModName(KeyValuePair<string, Dictionary<string, int>> formKeyPair)
        {
            PluginName = formKeyPair.Key;
            foreach(var pair in formKeyPair.Value)
            {
                if (pair.Value < Program.Settings.FilterSettings.MinCountToOutput) continue;
                
                Conflicts.Add(new Conflict(pair.Key, pair.Value));
            }
        }
    }

    public class Conflict
    {
        public Conflict(string pluginName, int number)
        {
            PluginName = pluginName;
            this.number = number;
        }

        public string PluginName { get; set; } = String.Empty;
        public int number { get; set; } = 0;
    }
}

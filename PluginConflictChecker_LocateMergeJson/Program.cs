namespace PluginConflictChecker_LocateMergeJson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PluginConflictChecker.GF.NoPause = true;
            PluginConflictChecker_CreateZMergeInstance.Program.NoPause = true;
            PluginConflictChecker.Program.NoExplorer = true;
            Console.WriteLine("Hello, World!");
            bool run = false;
            if(args.Length == 1)
            {
                if (args[0].Equals("-run", StringComparison.OrdinalIgnoreCase))
                {
                    run = true;
                }
            }
            try
            {
                PluginConflictChecker.Settings baseSettings = PluginConflictChecker.Settings.Load();
                IEnumerable<string> mergeFolders = Directory.EnumerateDirectories(baseSettings.DataFolder, "merge - *", SearchOption.TopDirectoryOnly);
                foreach (string mergeFolder in mergeFolders)
                {
                    Console.WriteLine(mergeFolder);
                    string json = Path.Combine(mergeFolder, "merge.json");
                    if (File.Exists(json))
                    {
                        Console.WriteLine(json);
                        List<string> createArgs = new List<string>();
                        createArgs.Add(json);
                        if (run)
                        {
                            PluginConflictChecker.Program.ConflictsByformKeyList = new();
                            PluginConflictChecker.Program.ConflictsByModNames = new();
                            createArgs.Add("-run");
                        }
                        PluginConflictChecker_CreateZMergeInstance.Program.Main(createArgs.ToArray());
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            Console.WriteLine("Press Enter to Close...");
            Console.ReadLine();

            PluginConflictChecker.Program.NoExplorer = false;
            PluginConflictChecker.Program.Explorer();
        }
    }
}
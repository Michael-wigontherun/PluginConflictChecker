using System.Text.Json;

namespace PluginConflictChecker_CreateZMergeInstance
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            PluginConflictChecker.GF.NoPause = true;
            try
            {
                var JSONFile = JsonSerializer.Deserialize<MergeJSON>(File.ReadAllText(args[0]))!;

                Directory.CreateDirectory("zMergeSettingInstances");
                string outputTxtPath = $"zMergeSettingInstances\\{JSONFile.name}.txt";
                File.WriteAllLines(outputTxtPath, JSONFile.ToList());

                PluginConflictChecker.Settings baseSettings = PluginConflictChecker.Settings.Load();
                baseSettings.PluginTXTPath = Path.GetFullPath(outputTxtPath);
                baseSettings.FilterOutMasterOverrides = false;
                baseSettings.OutputName = JSONFile.name;
                baseSettings.FilterSettings.MinCountToOutput = 0;

                string jsonPath = $"zMergeSettingInstances\\{JSONFile.name}.json";
                baseSettings.Write(jsonPath);

                if(args.Length == 2)
                {
                    if (args[1].Equals("-run", StringComparison.OrdinalIgnoreCase))
                    {
                        PluginConflictChecker.Program.Main(new string[] { jsonPath });
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("This program needs the first argument to be the path to a merge.json created and outputted by zMerge");
                Console.WriteLine("The second argument should be ");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace!);
            }
            EndProgram();
        }

        public static bool NoPause = false;
        static void EndProgram()
        {
            if(NoPause) return;
            Console.WriteLine("Press Enter to Close...");
            Console.ReadLine();
        }
    }
}
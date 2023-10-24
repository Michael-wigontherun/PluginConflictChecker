using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginConflictChecker_CreateZMergeInstance
{
    public class MergeJSON
    {
        public string name { get; set; } = String.Empty;
        public string filename { get; set; } = String.Empty;
        public string method { get; set; } = String.Empty;
        public List<string> loadOrder { get; set; } = new();
        public string archiveAction { get; set; } = String.Empty;
        public bool buildMergedArchive { get; set; } = false;
        public bool useGameLoadOrder { get; set; } = false;
        public bool handleFaceData { get; set; } = false;
        public bool handleVoiceData { get; set; } = false;
        public bool handleBillboards { get; set; } = false;
        public bool handleStringFiles { get; set; } = false;
        public bool handleTranslations { get; set; } = false;
        public bool handleIniFiles { get; set; } = false;
        public bool handleDialogViews { get; set; } = false;
        public bool copyGeneralAssets { get; set; } = false;
        public DateTime dateBuilt { get; set; } = DateTime.Now;
        public List<MergeJSONPlugin> plugins { get; set; } = new();

        internal List<string> ToList()
        {
            List<string> pluginsSet = new();
            foreach (var plugin in plugins)
            {
                //GL.WriteLine("");
                pluginsSet.Add("*" + plugin.filename);
            }
            return pluginsSet;
        }
    }
    public class MergeJSONPlugin
    {
        public string filename { get; set; } = String.Empty;
        public string hash { get; set; } = String.Empty;
        public string dataFolder { get; set; } = String.Empty;
    }
}

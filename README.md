# PluginConflictChecker
Plugin Conflict Checker scans each plugin in your load order for what FormIDs are present and then checks them against each other for conflicting IDs.

## Requirements
[.Net 6 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

## Installion & Usage
1. Install [.Net 6 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
2. Unpack the newest release build into a folder outside the Skyrim or Fallout 4's Data folder, You should create two instances of this one for Skyrim, one for Fallout 4
3. Run the program once to generate the "PluginConflictChecker_AppSettings.json" or download the base PluginConflictChecker_AppSettings.json file
4. Open "PluginConflictChecker_AppSettings.json" and change the path for "DataFolder" to Skyrim or Fallout 4's Data Folder
5. Change "PluginTXTPath" to the path to your plugins.txt, This can be the plguins.txt inside "Documents\My Games\Skyrim Special Edition\plugins.txt" or the plugins.txt inside of a MO2 profile
6. Ensure all \ are doubled in json. Example: "Documents\\My Games\\Skyrim Special Edition\\plugins.txt"
7. If the instance is for Fallout4, change "Fallout4": false to "Fallout4": true 
8. Run PluginConflictChecker.exe and let it generate

Files will be generated inside the Reports folder

### Additional Settings
```
"FilterOutMasterOverrides"          True will ignore conflicts between a 2 plugins if one requires the other
"OutputToSeperateFiles"             True will output the main list of plugins and seperated files for each plugin that
                                      conflicts with something
"Explorer"                          True will open the output folder in Windows Explorer
"MinCountToOutput"                  Is a integer changing the number will require plugins to have more then the value to be output
"TypeFilter"                        Is a string list, add Mutegen Major Record interface types to this list to remove them
                                      from the conflict count, See Major Record Interfaces.txt for a list, Cell
                                      and Worldspace Records are already added
```

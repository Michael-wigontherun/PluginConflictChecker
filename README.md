# PluginConflictChecker
Plugin Conflict Checker scans each plugin in your load order for what FormIDs are present and then checks them against each other for conflicting IDs.

## Requirements
[.Net 6 Desktop Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

## Installation & Usage
All executables and batch files must be run through MO2 if you are using it.

1. Install [.Net 6 Desktop Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
2. Unpack the newest release build into a folder outside the Skyrim or Fallout 4's Data folder, You should create two instances of this one for Skyrim, one for Fallout 4
3. Run the "PluginConflictChecker.exe" once to generate the "PluginConflictChecker_AppSettings.json" or download the base PluginConflictChecker_AppSettings.json file
4. Open "PluginConflictChecker_AppSettings.json" and change the path for "DataFolder" to Skyrim or Fallout 4's Data Folder
5. Change "PluginTXTPath" to the path to your plugins.txt, This can be the plugins.txt inside "AppData\Local\Skyrim Special Edition\plugins.txt" or the plugins.txt inside of a MO2 profile
6. Ensure all \ are doubled in json. Example: "AppData\\\\Local\\\\Skyrim Special Edition\\\\plugins.txt"
7. If the instance is for Fallout4, change "Fallout4": false to "Fallout4": true 
8. Run PluginConflictChecker.exe and let it generate the files for your perusing.

Files will be generated inside the Reports folder

### PluginConflictChecker_CreateZMergeInstance
This will create additional instance configurations for PluginConflictChecker based off a zMerge merge.json.
1. Configuration from Installation & Usage is required
2. Edit PluginConflictChecker_CreateZMergeInstance.bat
3. Set the first argument to the full path of a zMerge's merge.json
4. If you would like it to automatically generate the reports for the merge conflicts, Set as a second argument -run
4. Run the "PluginConflictChecker_CreateZMergeInstance.bat"

### PluginConflictChecker_LocateMergeJson
This will locate and run PluginConflictChecker_CreateZMergeInstance for all zMerge's in the Data Folder
1. Configuration from Installation & Usage is required
2. Run "PluginConflictChecker_LocateMergeJson.exe"
3. If you would like it to automatically generate the reports for the merge conflicts, instead run the "PluginConflictChecker_LocateMergeJson.bat"

### Additional Usage
If you wish to quickly run everything you can run "_GenerateAllConflictsReports.bat". This will generate all the merge reports and the report for the plugins.txt

## Additional Settings
```
"FilterOutMasterOverrides"          True will ignore conflicts between a 2 plugins if one requires the other
"OutputToSeparateFiles"             True will output the main list of plugins and separated files for each plugin that
                                        conflicts with something
"OutputName"                        Is a string to output extra name data for the conflict reports, not needed for regular 
                                        reports of your load order. It is used mainly for zMerge support
"Explorer"                          True will open the output folder in Windows Explorer
"MinCountToOutput"                  Is a integer changing the number will require plugins to have more then the value to be output
"TypeFilter"                        Is a string list, add Mutegen Major Record interface types to this list to remove them
                                        from the conflict count, See Major Record Interfaces.txt for a list, Cell
                                        and Worldspace Records are already added
"OnlyIncludeTypeFilter"             True will make "TypeFilter" only register conflicts of conflicts of of
                                        that particular type or types
```

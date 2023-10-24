rmdir /s /q ".\ReleaseSet\PluginConflictChecker"
mkdir ".\ReleaseSet\PluginConflictChecker"

xcopy /s /y ".\PluginConflictChecker_LocateMergeJson\bin\Release\net6.0" ".\ReleaseSet\PluginConflictChecker"

del \q ".\ReleaseSet\PluginConflictChecker.rar"
del \q ".\ReleaseSet\PluginConflictChecker Settings.rar"

"C:\Program Files\WinRAR\WinRAR.exe" a -s -ep1 ".\ReleaseSet\PluginConflictChecker.rar" ".\ReleaseSet\PluginConflictChecker"
"C:\Program Files\WinRAR\WinRAR.exe" a -s -ep1 ".\ReleaseSet\PluginConflictChecker Settings.rar" ".\PluginConflictChecker\PluginConflictChecker_AppSettings.json"

explorer.exe ".\ReleaseSet"
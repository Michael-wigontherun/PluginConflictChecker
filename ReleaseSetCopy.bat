echo Deleting ReleaseSet\PluginConflictChecker
rmdir /s /q ".\ReleaseSet\PluginConflictChecker"
echo Createing ReleaseSet\PluginConflictChecker
mkdir ".\ReleaseSet\PluginConflictChecker"
echo Copying ESLify Everything Release Build to ESLify Everything Release Set
xcopy /s /y ".\PluginConflictChecker\bin\Release\net6.0" ".\ReleaseSet\PluginConflictChecker"

echo Deleting ReleaseSet\PluginConflictChecker.rar
del \q ".\ReleaseSet\PluginConflictChecker.rar"

echo Createing PluginConflictChecker.rar
"C:\Program Files\WinRAR\WinRAR.exe" a -s -ep1 ".\ReleaseSet\PluginConflictChecker.rar" ".\ReleaseSet\PluginConflictChecker"

echo Deleting ReleaseSet\PluginConflictChecker Settings.rar
del \q ".\ReleaseSet\PluginConflictChecker Settings.rar"

echo Createing PluginConflictChecker.rar
"C:\Program Files\WinRAR\WinRAR.exe" a -s -ep1 ".\ReleaseSet\PluginConflictChecker Settings.rar" ".\PluginConflictChecker\PluginConflictChecker_AppSettings.json"

explorer.exe ".\ReleaseSet"
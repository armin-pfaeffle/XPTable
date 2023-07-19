git log --pretty=oneline -n1 > %1
git status >> %1

:: TODO: Write value to XPTable.csproj into InformationalVersion
:: TODO: Why not convert the whole script into PowerShell?
::git rev-parse --short HEAD > githash.txt
::set /p HASH=<githash.txt
::echo using System.Reflection; > %2
::echo [assembly: AssemblyInformationalVersion("git:%HASH%")] >> %2

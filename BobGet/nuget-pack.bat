@echo off

set replacetext=C:\EPiServer\phony-club-denmark\BobGet\ReplaceText.vbs
set framework=Net45

@echo ------------------------------------------------------------------------
@echo 1. Clean old folder
@echo ------------------------------------------------------------------------
@del content\*.* /S /F /Q > nul

echo.
echo.

@echo ------------------------------------------------------------------------
@echo 2. Copy files to NuGet folder
@echo ------------------------------------------------------------------------
@xcopy ..\wwwroot\website\*.cs content\%framework%\*.cs.pp /S /Q /EXCLUDE:dontcopy.txt
@xcopy ..\wwwroot\website\*.resx content\%framework%\*.resx /S /Q

echo.
echo.

@for /R %%x in (*.pp) do ren "%%x" *.cs.pp
@FORFILES /P "Content" /M *.pp /S /C "Cmd /C %replacetext% @path PhonyClubDenmark.Website $rootnamespace$ /I"

@echo ------------------------------------------------------------------------
@echo 3. Pack it all up
@echo ------------------------------------------------------------------------
@nuget.exe pack

echo.
echo.
@echo ------------------------------------------------------------------------
@echo DONE
@echo ------------------------------------------------------------------------

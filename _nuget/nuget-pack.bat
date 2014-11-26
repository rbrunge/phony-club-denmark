@echo off

set replacetext=%CD%\ReplaceText.vbs
set framework=Net45

@echo ------------------------------------------------------------------------
@echo 1. Clean old folder
@echo ------------------------------------------------------------------------
@del content\*.* /S /F /Q > nul
@rmdir /S /Q content
@mkdir content

echo.
echo.

@echo ------------------------------------------------------------------------
@echo 2. Copy files to NuGet folder
@echo ------------------------------------------------------------------------
@xcopy ..\wwwroot\website\*.* content\%framework%\*.* /S /Q /EXCLUDE:dontcopy.txt
@xcopy ..\wwwroot\website\content\c*.* content\%framework%\Content\*.* /Q
@xcopy ..\wwwroot\website\scripts\docs.min.js content\%framework%\scripts\*.* /Q
@xcopy copy-content\*.* content\%framework%\*.* /s /Q

echo.
echo.

@for /R %%x in (*.cs) do ren "%%x" *.cs.pp
@for /R %%x in (*.cshtml) do ren "%%x" *.cshtml.pp
@FORFILES /P "Content" /M *.pp /S /C "Cmd /C %replacetext% @path PhonyClubDenmark.Website $rootnamespace$ /I"

@echo ------------------------------------------------------------------------
@echo Target .NET 4.5.1 + 4.5.2
@echo ------------------------------------------------------------------------
@xcopy content\Net45\*.* content\Net451\ /s /q 
@xcopy content\Net45\*.* content\Net452\ /s /q 

@echo ------------------------------------------------------------------------
@echo 3. Pack it all up
@echo ------------------------------------------------------------------------
@nuget.exe pack

echo.
echo.
@echo ------------------------------------------------------------------------
@echo DONE
@echo ------------------------------------------------------------------------
:end
pause

set OPTNNAME=populateSqlite0x-0

set project=MarketplaceSQLAdminCLI
set bin=bin\Debug\net6.0
set exe=..\..\%project%\%bin%\%project%.exe
set cmd=%exe% %OPTNNAME%

%cmd%
@set errlvl=%ERRORLEVEL%

@if "%~1"=="" @pause
@exit /b %errlvl%

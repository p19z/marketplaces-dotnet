set OPTNNAME=initCoreSqlite

set project=MarketplaceSQLAdminCLI
set bin=bin\Debug\net6.0
set exe=..\..\%project%\%bin%\%project%.exe
set cmd=%exe% %OPTNNAME%

%cmd%

@if "%~1"=="" @pause

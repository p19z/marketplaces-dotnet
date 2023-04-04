set OPTNNAME=ss-populate
set OPTNNAME2=ss-stats

set project=MarketplaceSQLAdminCLI
set bin=bin\Debug\net6.0
set exe=..\..\%project%\%bin%\%project%.exe
set cmd=%exe% %OPTNNAME%

%cmd%

%exe% %OPTNNAME%
echo;
%exe% %OPTNNAME2%


@if "%~1"=="" @pause

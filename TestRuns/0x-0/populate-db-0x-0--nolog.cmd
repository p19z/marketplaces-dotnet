set OPTNNAME=sl-populate
set OPTNNAME2=sl-stats

set project=MarketplaceSQLAdminCLI
set bin=bin\Debug\net6.0
set exe=..\..\%project%\%bin%\%project%.exe

%exe% %OPTNNAME%
@echo;
%exe% %OPTNNAME2%

@if "%~1"=="" @pause

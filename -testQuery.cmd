@set bin=bin\Debug\net6.0

@pushd MarketplaceSQLAdminCLI\%bin%

MarketplaceSQLAdminCLI.exe query

@if "%~1"=="" @pause
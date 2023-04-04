@set bin=bin\Debug\net6.0

@pushd MarketplaceSQLAdminCLI\%bin%

MarketplaceSQLAdminCLI.exe sl-populate

@if "%~1"=="" @pause
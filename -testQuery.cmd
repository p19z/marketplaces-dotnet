@set bin=bin\Debug\net6.0

@pushd MarketplaceSQLAdminCLI\%bin%

MarketplaceSQLAdminCLI.exe sl-stats

@if "%~1"=="" @pause
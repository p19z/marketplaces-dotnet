pushd %~dp0..\..\MarketplaceObjects.SqlServer
dotnet ef database update --context SqlServerCtx
popd

@if "%~1"=="" @pause

pushd %~dp0..\..\MarketplaceObjects.SqlServer
dotnet ef database update --context MarketplaceSqlServerContext
popd

@pause

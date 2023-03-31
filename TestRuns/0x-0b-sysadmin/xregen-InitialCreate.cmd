pushd ..\..\MarketplaceObjects.SqlServer
dotnet ef migrations add InitialSqlServerCreate --context MarketplaceSqlServerContext
popd

@pause

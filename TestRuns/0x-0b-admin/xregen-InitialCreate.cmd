pushd ..\..\MarketplaceObjects.SqlServer
@rem --context MarketplaceSqlServerContext
dotnet ef migrations add InitialSqlServerCreate
popd

@pause

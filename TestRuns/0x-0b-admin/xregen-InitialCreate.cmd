pushd ..\..\MarketplaceObjects
dotnet ef migrations add InitialSQLiteCreate --context MarketplaceSQLiteContext
::dotnet ef migrations add InitialSqlServerCreate --context MarketplaceSqlServerContext
popd

@pause

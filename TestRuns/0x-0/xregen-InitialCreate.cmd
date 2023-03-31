pushd ..\..\MarketplaceObjects.SQLite
dotnet ef migrations add InitialSQLiteCreate --context MarketplaceSQLiteContext
popd

@pause

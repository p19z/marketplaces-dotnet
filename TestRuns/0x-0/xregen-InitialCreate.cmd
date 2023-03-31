pushd ..\..\MarketplaceObjects.SQLite
@rem --context MarketplaceSQLiteContext
dotnet ef migrations add InitialSQLiteCreate
popd

@pause

pushd ..\..\MarketplaceObjects
dotnet ef migrations add InitialSQLiteCreate --context MarketplaceSQLiteContext
popd

@pause

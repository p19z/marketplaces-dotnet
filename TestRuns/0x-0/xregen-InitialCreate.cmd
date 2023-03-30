pushd ..\..\MarketplaceObjects
dotnet ef migrations add InitialCreate --context MarketplaceSQLiteContext
popd

@pause

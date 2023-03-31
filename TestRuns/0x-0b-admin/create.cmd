set TESTNAME=_0_InitDatabase.InitSQLServerDatabase_v0

pushd %~dp0..\..\MarketplaceObjects.SqlServer
dotnet ef database update --context MarketplaceSqlServerContext
popd

@pause

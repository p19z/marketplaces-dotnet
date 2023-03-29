set TESTNAME=_0_InitDatabase.InitDatabase_v0

pushd ..\..\MarketplaceAdminCLI
dotnet ef database update
popd

copy /y %LocalAppData%\marketplaces.db .\%TESTNAME%.db
sqlite3 .\%TESTNAME%.db .dump > .\%TESTNAME%.db.sql
del .\%TESTNAME%.db

@pause

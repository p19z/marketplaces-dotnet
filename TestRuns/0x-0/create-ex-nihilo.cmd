set TESTNAME=_0_InitialDatabase.InitSqliteDatabase_v0

pushd ..\..\MarketplaceObjects.Sqlite
dotnet ef database update --context MarketplaceSqliteContext
popd

copy /y %LocalAppData%\marketplaces.db .\%TESTNAME%.db
sqlite3 .\%TESTNAME%.db .dump > .\%TESTNAME%.db.sql
del .\%TESTNAME%.db

@pause

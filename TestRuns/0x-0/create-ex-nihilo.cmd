set TESTNAME=_0_InitialDatabase.InitSQLiteDatabase_v0

pushd ..\..\MarketplaceObjects.SQLite
dotnet ef database update --context MarketplaceSQLiteContext
popd

copy /y %LocalAppData%\marketplaces.db .\%TESTNAME%.db
sqlite3 .\%TESTNAME%.db .dump > .\%TESTNAME%.db.sql
del .\%TESTNAME%.db

@pause

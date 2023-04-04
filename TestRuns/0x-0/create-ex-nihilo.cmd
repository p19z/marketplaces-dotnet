set TESTNAME=_0_InitialDatabase.InitSqliteDatabase_v0

pushd ..\..\MarketplaceObjects.Sqlite
dotnet ef database update --context SqliteCtx
popd

copy /y %LocalAppData%\marketplaces.db .\%TESTNAME%.db
sqlite3 .\%TESTNAME%.db .dump > .\%TESTNAME%.db.sql
del .\%TESTNAME%.db

@if "%~1"=="" @pause

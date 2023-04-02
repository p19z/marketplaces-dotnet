set TESTNAME=_0x_InitDatabase.FillSqliteDatabase_v0

set OPTNNAME=populateSqlite0x-0

set project=MarketplaceSQLAdminCLI
set bin=bin\Debug\net6.0
set exe=..\..\%project%\%bin%\%project%.exe
set cmd=%exe% %OPTNNAME%

2>&1 > %TESTNAME%.log %cmd%

copy /y %LocalAppData%\marketplaces.db .\%TESTNAME%.db
sqlite3 .\%TESTNAME%.db .dump > .\%TESTNAME%.db.sql
del .\%TESTNAME%.db

@if "%~1"=="" @pause

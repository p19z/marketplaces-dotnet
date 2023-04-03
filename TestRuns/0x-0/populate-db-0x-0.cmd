set TESTNAME=_0x_InitDatabase.FillSqliteDatabase_v0

set OPTNNAME=populateSqlite
set OPTNNAME2=statsSqlite

set project=MarketplaceSQLAdminCLI
set bin=bin\Debug\net6.0
set exe=..\..\%project%\%bin%\%project%.exe

2>&1 > %TESTNAME%.log %exe% %OPTNNAME%
>> %TESTNAME%.log echo;
2>&1 >> %TESTNAME%.log %exe% %OPTNNAME2%

copy /y %LocalAppData%\marketplaces.db .\%TESTNAME%.db
sqlite3 .\%TESTNAME%.db .dump > .\%TESTNAME%.db.sql
del .\%TESTNAME%.db

@if "%~1"=="" @pause

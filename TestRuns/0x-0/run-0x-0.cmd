set TESTNAME=_0x_InitDatabase.InitSQLiteDatabase_v0

set OPTNNAME=hardcodedPopulateSQLite0x-0
set exe=..\..\MarketplaceAdminCLI\bin\Debug\net6.0\MarketplaceAdminCLI.exe
set cmd= %exe% %OPTNNAME%

2>&1 > %TESTNAME%.log %cmd%
copy /y %LocalAppData%\marketplaces.db .\%TESTNAME%.db
sqlite3 .\%TESTNAME%.db .dump > .\%TESTNAME%.db.sql
del .\%TESTNAME%.db

@pause

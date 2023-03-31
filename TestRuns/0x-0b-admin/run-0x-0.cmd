set TESTNAME=_0x_InitDatabase.FillSqlServerDatabase_v0

set OPTNNAME=hardcodedPopulateSqlServer0x-0

set project=MarketplaceSqlServerAdminCLI
set bin=bin\Debug\net6.0
set exe=..\..\%project%\%bin%\%project%.exe
set cmd=%exe% %OPTNNAME%

2>&1 > %TESTNAME%.log %cmd%
copy /y %LocalAppData%\marketplaces.db .\%TESTNAME%.db
sqlite3 .\%TESTNAME%.db .dump > .\%TESTNAME%.db.sql
del .\%TESTNAME%.db

@pause

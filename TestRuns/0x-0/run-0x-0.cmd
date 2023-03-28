set TESTNAME=_0x_InitDatabase.InitDatabase_v0

2>&1 > %TESTNAME%.log ..\..\MarketplacesAdmin\bin\Debug\net6.0\MarketplaceAdminCLI.exe
copy /y %LocalAppData%\marketplaces.db .\%TESTNAME%.db
sqlite3 .\%TESTNAME%.db .dump > .\%TESTNAME%.db.sql
del .\%TESTNAME%.db

@pause

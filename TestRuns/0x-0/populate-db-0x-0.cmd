set TESTNAME=_0x_InitDatabase.FillSqliteDatabase_v0

2>&1 > %TESTNAME%.log call populate-db-0x-0--nolog.cmd

copy /y %LocalAppData%\marketplaces.db .\%TESTNAME%.db
sqlite3 .\%TESTNAME%.db .dump > .\%TESTNAME%.db.sql
del .\%TESTNAME%.db

@pause

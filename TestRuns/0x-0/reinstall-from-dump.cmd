@set args=%*

@set TESTNAME=_0_InitDatabase.InitSqliteDatabase_v0
@if not "%args%"=="" set TESTNAME=%args%

sqlite3 %LocalAppData%\marketplaces.db < .\%TESTNAME%.db.sql

@pause

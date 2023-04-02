set TESTNAME=_0_CleanedDatabase.DeletedContent_v0

set OPTNNAME=deleteSqliteContent0x-0

set project=MarketplaceSQLAdminCLI
set bin=bin\Debug\net6.0
set exe=..\..\%project%\%bin%\%project%.exe
set cmd=%exe% %OPTNNAME%

@rem ~ 2>&1 > %TESTNAME%.log %cmd%
%cmd%
@rem ~ timeout /t 1 >NUL

copy /y %LocalAppData%\marketplaces.db .\%TESTNAME%.db
sqlite3 .\%TESTNAME%.db .dump > .\%TESTNAME%.db.sql
del .\%TESTNAME%.db

@pause

set TESTNAME=_0_CleanedDatabase.DeletedContent_v0

set OPTNNAME=deleteSqliteContent

set project=MarketplaceSQLAdminCLI
set bin=bin\Debug\net6.0
set exe=..\..\%project%\%bin%\%project%.exe
set cmd=%exe% %OPTNNAME%

if exist %TESTNAME%.log del %TESTNAME%.log

>> %TESTNAME%.log echo run-1
>> %TESTNAME%.log %cmd%
@timeout /t 1 >NUL

>> %TESTNAME%.log echo;
>> %TESTNAME%.log echo run-2
2>&1 >> %TESTNAME%.log %cmd%
@timeout /t 1 >NUL

>> %TESTNAME%.log echo;
>> %TESTNAME%.log echo run-3
2>&1 >> %TESTNAME%.log %cmd%
@timeout /t 1 >NUL

copy /y %LocalAppData%\marketplaces.db .\%TESTNAME%.db
sqlite3 .\%TESTNAME%.db .dump > .\%TESTNAME%.db.sql
del .\%TESTNAME%.db

@if "%~1"=="" @pause

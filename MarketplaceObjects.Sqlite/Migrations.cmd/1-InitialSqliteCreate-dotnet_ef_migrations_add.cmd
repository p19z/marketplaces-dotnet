@set OLDTS=20230331164132

@pushd ..
	@rem Delete the old autogen
	@pushd Migrations
	del %OLDTS%_InitialSqliteCreate.cs
	del %OLDTS%_InitialSqliteCreate.Designer.cs
	del MarketplaceSqliteContextModelSnapshot.cs
	@popd

	@rem Autogen init and schema
	dotnet ef migrations add InitialSqliteCreate --context MarketplaceSqliteContext

	@rem Restore the old timestamps
	@pushd Migrations
	@set g_fileCounter=0
	@for /R . %%f in (*) do @(
		call :processFilename %%~nf
	)
	@popd
@popd

@pause
@exit /b

:processFilename
	@set /a g_fileCounter+=1
	@echo %g_fileCounter%: %1
	@if %g_fileCounter%==1 (call :replaceInFile %1.Designer.cs %1 %OLDTS%_InitialSqliteCreate)
	@if %g_fileCounter%==1 (rename %1.cs %OLDTS%_InitialSqliteCreate.cs)
	@if %g_fileCounter%==2 (rename %1.cs %OLDTS%_InitialSqliteCreate.Designer.cs)
@exit /b

:replaceInFile
	echo ^(Get-Content "%1"^) ^| ForEach-Object { $_ -replace "%2", "%3" } ^| Set-Content -Encoding utf8 "%1">"%TEMP%\rif.ps1"
	Powershell.exe -executionpolicy ByPass -File "%TEMP%\rif.ps1"
@exit /b

@rem ~ @cd TestRuns

@pushd ..\MarketplaceObjects.Sqlite\Migrations.cmd\
	call 1-InitialSqliteCreate-dotnet_ef_migrations_add.cmd /NOPAUSE
@popd

@pushd ..\MarketplaceObjects.SqlServer\Migrations.cmd\
	call 1-InitialSqlServerCreate-dotnet_ef_migrations_add.cmd /NOPAUSE
@popd

@pushd .\0x-0
	del *_v0.log
	del *_v0.db.sql
	call _delete-db-file.cmd /NOPAUSE
	call create-ex-nihilo.cmd /NOPAUSE
	call initialize-db-0x-0.cmd /NOPAUSE
	call populate-db-0x-0.cmd /NOPAUSE
	call xdelete-db-content.cmd /NOPAUSE
@popd

@pushd .\0x-0b-sysadmin
@popd

@if "%~1"=="" @pause

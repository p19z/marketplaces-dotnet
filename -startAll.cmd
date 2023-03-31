@set bin=bin\Debug\net6.0

@call :Start-Services
@goto lblEndRun
@pause
@exit /b

:Start-Services
@call :Start-MarketplaceWebAPI
@call :Start-MarketplaceWebUI
@exit /b

:Start-MarketplaceWebUI
@rem Take "wwwroot" into account
@rem => Do not use %bin% as CD.
@pushd MarketplaceWebUI
@rem ~ start /B %bin%/MarketplaceWebUI.exe
start /B dotnet run --launch-profile "MarketplaceWebUI"
@popd
@exit /b

:Start-MarketplaceWebAPI
:: PROBLEMS
:: Failed to bind to address http://127.0.0.1:5000: address already in use.
:: - OR - Browser says "The connection for this site is not secure".
:: - OR -  System.InvalidOperationException: No database provider has been configured for this DbContext. A provider can be configured by overriding the 'DbContext.OnConfiguring' method or by using 'AddDbContext' on the application service provider. If 'AddDbContext' is used, then also ensure that your DbContext type accepts a DbContextOptions<TContext> object in its constructor and passes it to the base constructor for DbContext.
@pushd MarketplaceWebAPI
@rem ~ start /B %bin%\MarketplaceWebAPI.exe
start /B dotnet run --launch-profile "MarketplaceWebAPI"
@popd
@exit /b

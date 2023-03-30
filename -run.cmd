@set bin=bin\Debug\net6.0

@rem Take "wwwroot" into account
@rem => Do not use %bin% as CD.
@pushd MarketplaceWebUI
start /B %bin%/MarketplaceWebUI.exe
@popd

:: PROBLEMS
:: Failed to bind to address http://127.0.0.1:5000: address already in use.
:: - OR - Browser says "The connection for this site is not secure".
@rem ~ @pushd MarketplaceWebAPI\%bin%
@rem ~ @pushd MarketplaceWebAPI
@rem ~ %bin%\MarketplaceWebAPI.exe
@rem ~ @popd

@rem ~ @echo.
@rem ~ @pause

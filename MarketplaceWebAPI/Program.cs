using MarketplaceObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.ClearProviders();
//builder.Logging.AddConsole(); // <=> AddSimpleConsole()
// var formatOptns = new SimpleConsoleFormatterOptions() { SingleLine = true };
// builder.Logging.AddSimpleConsole(Action<SimpleConsoleFormatterOptions>);
// OK: builder.Logging.AddSystemdConsole(); // (ConsoleFormatterNames.Systemd);
builder.Logging.AddJsonConsole(); // (ConsoleFormatterNames.Json);
//builder.Logging.AddDebug();
// builder.Logging.

// REF 230329-1
// Unhandled exception. System.ArgumentException: 'AddDbContext' was called with configuration,
// but the context type 'MarketplaceContext' only declares a parameterless constructor.
// This means that the configuration passed to 'AddDbContext' will never be used.
//builder.Services.AddDbContext<MarketplaceContext>(
//    options => options.UseSqlite($"Data Source={MarketplaceContext.GetDbPath()}"));
builder.Services.AddDbContext<MarketplaceDbCtx>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

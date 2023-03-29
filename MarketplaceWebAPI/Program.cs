using MarketplaceObjects;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
//builder.Logging.AddDebug();

// REF 230329-1
// Unhandled exception. System.ArgumentException: 'AddDbContext' was called with configuration,
// but the context type 'MarketplaceContext' only declares a parameterless constructor.
// This means that the configuration passed to 'AddDbContext' will never be used.
//builder.Services.AddDbContext<MarketplaceContext>(
//    options => options.UseSqlite($"Data Source={MarketplaceContext.BuildDbPath()}"));
builder.Services.AddDbContext<MarketplaceContext>();

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

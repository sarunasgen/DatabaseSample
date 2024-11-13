using DatabaseSample.Core.Contracts;
using DatabaseSample.Core.Repositories;
using DatabaseSample.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

IShopRepository shopRepository = new ShopRepository("Server=localhost\\MSSQLSERVER01;Database=shopping_sample;Trusted_Connection=True;TrustServerCertificate=true;");
IShopService shopService = new ShopService(shopRepository);

builder.Services.AddTransient<IShopRepository, ShopRepository>(x => new ShopRepository("Server=localhost\\MSSQLSERVER01;Database=shopping_sample;Trusted_Connection=True;TrustServerCertificate=true;"));
builder.Services.AddTransient<IShopService, ShopService>();
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

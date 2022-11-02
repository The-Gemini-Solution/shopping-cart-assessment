using Shopping.Cart.Data.Configuration;
using Shopping.Cart.Data.Context.Repositories;
using Shopping.Cart.Domain.Interfaces;
using Shopping.Cart.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IDBConfig>(new DBConfig(builder.Configuration["ConnectionString"]));
builder.Services.AddSingleton<ICartRepository, CartRepository>();
builder.Services.AddSingleton<IProductsRepository, ProductsRepository>();
builder.Services.AddSingleton<IItemsRepository, ItemsRepository>();
builder.Services.AddSingleton<ISeeder, Seeder>();
builder.Services.AddSingleton<IProductsService, ProductsService>();
builder.Services.AddSingleton<IShoppingCartService, ShoppingCartService>();

var app = builder.Build();
var seeder = app.Services.GetService<ISeeder>();

if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
  if (seeder != null) 
  {
    seeder.Seed();
  }
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

using Shopping.Cart.Data.Configuration;
using Shopping.Cart.Data.Context.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IDBConfig>(new DBConfig(builder.Configuration["ConnectionString"]));
builder.Services.AddSingleton<ICartRepository, CartRepository>();
builder.Services.AddSingleton<IProductsRepository, ProductsRepository>();
builder.Services.AddSingleton<IItemsRepository, ItemsRepository>();

var app = builder.Build();
var seeder = new DBSeeder(app.Services);

if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
  seeder.Execute();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

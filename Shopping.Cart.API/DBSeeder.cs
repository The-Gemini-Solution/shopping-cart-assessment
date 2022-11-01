using System.Collections.Concurrent;
using Shopping.Cart.Data.Context.Repositories;
using Shopping.Cart.Data.Models;

public class DBSeeder
{
  private const string SHOPPING_CART_DDL = "";
  private IServiceProvider _provider;

  public DBSeeder(IServiceProvider provider)
  {
    this._provider = provider;
  }

  public void Execute()
  {
    var shoppingCartRepository = this._provider.GetService<ICartRepository>();

    if (shoppingCartRepository != null)
    {
      shoppingCartRepository.CreateTable();
    }

    var productsRepository = this._provider.GetService<IProductsRepository>();

    if (productsRepository != null)
    {
      productsRepository.CreateTable();

      var count = productsRepository.Count().GetAwaiter().GetResult();
      
      if (count == 0)
      {
        productsRepository.Add(new Product()
        {
          BarCode = $"{Guid.NewGuid()}",
          Name = "Bananas",
          Description = "Bag of Bananas",
          Category = "Fruit",
          UnitPrice = 1995
        }).GetAwaiter().GetResult();
        productsRepository.Add(new Product()
        {
          BarCode = $"{Guid.NewGuid()}",
          Name = "Apples",
          Description = "Bag of Apples",
          Category = "Fruit",
          UnitPrice = 2995
        }).GetAwaiter().GetResult();
      }
    }

    var cartItemsRepository = this._provider.GetService<IItemsRepository>();

    if (cartItemsRepository != null)
    {
      cartItemsRepository.CreateTable();
    }
  }
}
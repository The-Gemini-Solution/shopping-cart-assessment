using Shopping.Cart.Data.Context.Repositories;
using Shopping.Cart.Data.Models;
using Shopping.Cart.Domain.Interfaces;

namespace Shopping.Cart.Domain.Services
{
  public class Seeder : ISeeder
  {
    private IProductsRepository _productsRepository;
    private IItemsRepository _itemsRepository;
    private ICartRepository _cartRepository;

    public Seeder(
      IProductsRepository productsRepository, 
      IItemsRepository itemsRepository, 
      ICartRepository cartRepository
      )
    {
      this._productsRepository = productsRepository;
      this._itemsRepository = itemsRepository;
      this._cartRepository = cartRepository;
    }

    public async Task Seed()
    {
      this._cartRepository.CreateTable();
      this._productsRepository.CreateTable();
      this._itemsRepository.CreateTable();

      if (await this._productsRepository.Count() == 0)
      {
        await this._productsRepository.Add(new Product()
        {
          BarCode = $"{Guid.NewGuid()}",
          Name = "Bananas",
          Description = "Bag of Bananas",
          Category = "Fruit",
          UnitPrice = 1995
        });
        await this._productsRepository.Add(new Product()
        {
          BarCode = $"{Guid.NewGuid()}",
          Name = "Apples",
          Description = "Bag of Apples",
          Category = "Fruit",
          UnitPrice = 2995
        });
      }
    }
  }
}
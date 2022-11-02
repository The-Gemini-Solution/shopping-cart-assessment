using Shopping.Cart.Data.Context.Repositories;
using Shopping.Cart.Data.Models;
using Shopping.Cart.Domain.Interfaces;

namespace Shopping.Cart.Domain.Services
{
  public class ProductsService: IProductsService

  {
    private IProductsRepository _productsRepository;

    public ProductsService(IProductsRepository productsRepository)
    {
      this._productsRepository = productsRepository;
    }

    public async Task Add(Product product)
    {
      await this._productsRepository.Add(product);
    }

    public async Task<int> Count()
    {
      return await this._productsRepository.Count();
    }

    public async Task<Product> GetById(string id)
    {
      return await this._productsRepository.GetById(id);
    }

    public Task<IEnumerable<Product>> QueryAll()
    {
      return this._productsRepository.QueryAll();
    }
  }
}
using Shopping.Cart.Data.Models;

namespace Shopping.Cart.Domain.Interfaces
{
  public interface IProductsService
  {
    Task Add(Product product);
    Task<int> Count();
    Task<IEnumerable<Product>> QueryAll();
    Task<Product> GetById(string id);
  }
}
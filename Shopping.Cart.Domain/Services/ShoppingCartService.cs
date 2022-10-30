using Shopping.Cart.Domain.Entities;
using Shopping.Cart.Domain.Interfaces;

namespace Shopping.Cart.Domain.Services
{
  public class ShoppingCartService : IShoppingCartService
  {
    public void Add(Product product)
    {
      throw new NotImplementedException();
    }

    public void Add(Product product, int quantity)
    {
      throw new NotImplementedException();
    }

    public T GetProduct<T>(Product product)
    {
      throw new NotImplementedException();
    }

    public IList<T> GetProducts<T>()
    {
      throw new NotImplementedException();
    }

    public void Remove(Product product)
    {
      throw new NotImplementedException();
    }

    public void Update(Product product, int quantity)
    {
      throw new NotImplementedException();
    }
  }
}
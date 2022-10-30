using Shopping.Cart.Domain.Entities;

namespace Shopping.Cart.Domain.Interfaces
{
  public interface IShoppingCartService
  {
    public void Add(Product product);
    public void Add(Product product, int quantity);
    public void Update(Product product, int quantity);
    public void Remove(Product product);
    public IList<T> GetProducts<T>();
    public T GetProduct<T>(Product product);
  }
}
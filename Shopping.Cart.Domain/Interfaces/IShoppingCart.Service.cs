using Shopping.Cart.Domain.Entities;

namespace Shopping.Cart.Domain.Interfaces
{
  public interface IShoppingCartService
  {
    public void Add();
    public void Update();
    public void Remove();
    public IList<T> GetProducts<T>();
    public T GetProduct<T>();
  }
}
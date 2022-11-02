using System.Reflection;
using Shopping.Cart.Domain.Entities;

namespace Shopping.Cart.Domain.Interfaces
{
  public interface IShoppingCartService
  {
    public Task Add(string barCode, string cartId, int quantity);
    public Task<Shopping.Cart.Data.Models.Cart?> GetCart(string id);
    public Task<IList<string>> GetCarts();
    public Task<string> NewCart();
    public Task Remove(string barCode, string cartId);
    public Task Update(string barCode, string cartId, int quantity);
  }
}
using System.Reflection;
using Shopping.Cart.Data.Context.Repositories;
using Shopping.Cart.Data.Models;
using Shopping.Cart.Domain.Entities;
using Shopping.Cart.Domain.Interfaces;

namespace Shopping.Cart.Domain.Services
{
  public class ShoppingCartService : IShoppingCartService
  {
    private ICartRepository _cartRepository;
    private IItemsRepository _itemsRepository;
    
    public ShoppingCartService(
      ICartRepository cartRepository, 
      IItemsRepository itemsRepository
      )
    {
      this._cartRepository = cartRepository;
      this._itemsRepository = itemsRepository;
    }

    public async Task Add(string barCode, string cartId, int quantity)
    {
      await this._itemsRepository.Add(barCode, cartId, quantity);
    }

    public async Task<Data.Models.Cart?> GetCart(string id)
    {
      return await this._cartRepository.GetById(id);
    }

    public async Task<IList<string>> GetCarts()
    {
      return (await this._cartRepository.QueryAll()).ToList();
    }

    public async Task<string> NewCart()
    {
      var cart = new Shopping.Cart.Data.Models.Cart() { Id = Guid.NewGuid().ToString() };

      await this._cartRepository.Add(cart);

      return cart.Id;
    }

    public async Task Remove(string barCode, string cartId)
    {
      await this._itemsRepository.Remove(barCode, cartId);
    }

    public async Task Update(string barCode, string cartId, int quantity)
    {
      await this._itemsRepository.Update(barCode, cartId, quantity);
    }
  }
}
using Microsoft.AspNetCore.Mvc;
using Shopping.Cart.API.Models;
using Shopping.Cart.Data.Context.Repositories;
using Shopping.Cart.Data.Models;

namespace Shopping.Cart.API.Controllers;

[ApiController]
[Route("api/carts")]
public class CartController : ControllerBase
{
  private readonly ICartRepository _cartRepository;
  private readonly IItemsRepository _itemsRepository;

  public CartController(ICartRepository cartRepository, IItemsRepository itemsRepository)
  {
    this._cartRepository = cartRepository;
    this._itemsRepository = itemsRepository;
  }

  [HttpGet()]
  public async Task<IEnumerable<string>> Get()
  {
    return await this._cartRepository.QueryAll();
  }

  [HttpGet("{cartId}")]
  public async Task<ActionResult<Data.Models.Cart>> GetById(string cartId)
  {
    var cart = await this._cartRepository.GetById(cartId);

    return Ok(cart);
  }

  [HttpPost()]
  public async Task<ActionResult> NewCart()
  {
    var cart = new Data.Models.Cart() { Id = $"{Guid.NewGuid()}" };

    await this._cartRepository.Add(cart);

    return CreatedAtAction(nameof(GetById), new { cartId = cart.Id });
  }

  [HttpPatch("{cartId}/items/{barCode}")]
  public async Task<ActionResult> UpdateItem([FromBody]ItemModel item, string cartId, string barCode)
  {
    await this._itemsRepository.Update(barCode, cartId, item.Quantity);

    return Ok();
  }

  [HttpDelete("{cartId}/items/{barCode}")]
  public async Task<ActionResult> DeleteItem(string cartId, string barCode)
  {
    await this._itemsRepository.Remove(barCode, cartId);

    return NoContent();
  }

  [HttpPost("{cartId}/items")]
  public async Task<ActionResult> AddItem(string cartId, [FromBody]ItemModel item)
  {
    await this._itemsRepository.Add(item.BarCode ?? "", cartId, item.Quantity);

    return CreatedAtAction(nameof(GetById), new { cartId = cartId });
  }
}

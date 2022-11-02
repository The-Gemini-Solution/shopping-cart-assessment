using Microsoft.AspNetCore.Mvc;
using Shopping.Cart.API.Models;
using Shopping.Cart.Domain.Interfaces;

namespace Shopping.Cart.API.Controllers;

[ApiController]
[Route("api/carts")]
public class CartController : ControllerBase
{
  private readonly IShoppingCartService _shoppingCartService;
  private readonly IProductsService _productsService;

  public CartController(IShoppingCartService shoppingCartService, IProductsService productsService)
  {
    this._shoppingCartService = shoppingCartService;
    this._productsService = productsService;
  }

  [HttpGet()]
  public async Task<IEnumerable<string>> Get()
  {
    return await this._shoppingCartService.GetCarts();
  }

  [HttpGet("{cartId}", Name = "GetById")]
  public async Task<ActionResult<Data.Models.Cart>> GetById(string cartId)
  {
    var cart = await this._shoppingCartService.GetCart(cartId);

    if (cart == null)
    {
        return NotFound(new { Message = $"Cart not found for [id: {cartId}]" });
    }

    return Ok(cart);
  }

  [HttpPost()]
  public async Task<ActionResult> NewCart()
  {
    var id = await this._shoppingCartService.NewCart();

    return CreatedAtRoute("GetById", new { cartId = id }, new { CartId = id });
  }

  [HttpPatch("{cartId}/items/{barCode}")]
  public async Task<ActionResult> UpdateItem([FromBody]ItemModel item, string cartId, string barCode)
  {
    var cart = await this._shoppingCartService.GetCart(cartId);

    if (cart == null)
    {
      return NotFound(new { Message = $"Cart not found for [id: {cartId}]" });
    }

    if (cart.Exists(barCode))
    {
      return NotFound(new { Message = $"Item [id: {barCode}] not found in cart" });
    }

    if (item.Quantity <= 0)
    {
      return BadRequest(new { Message = $"{item.Quantity} is an invalid value" });
    }

    await this._shoppingCartService.Update(barCode, cartId, item.Quantity);

    return Ok();
  }

  [HttpDelete("{cartId}/items/{barCode}")]
  public async Task<ActionResult> DeleteItem(string cartId, string barCode)
  {
    var cart = await this._shoppingCartService.GetCart(cartId);

    if (cart == null)
    {
      return NotFound(new { Message = $"Cart not found for [id: {cartId}]" });
    }

    if (cart.Exists(barCode))
    {
      return NotFound(new { Message = $"Item [id: {barCode}] not found in cart" });
    }

    await this._shoppingCartService.Remove(barCode, cartId);

    return NoContent();
  }

  [HttpPost("{cartId}/items")]
  public async Task<ActionResult> AddItem(string cartId, [FromBody]ItemModel item)
  {
    if (string.IsNullOrEmpty(item.BarCode))
    {
      return BadRequest(new { Message = $"Barcode is required" });
    }

    if (item.Quantity <= 0)
    {
      return BadRequest(new { Message = $"{item.Quantity} is an invalid value" });
    }

    if (await this._productsService.GetById(item.BarCode) == null)
    {
      return NotFound(new { Message = $"No product exists for {item.BarCode}" });
    }

    await this._shoppingCartService.Add(item.BarCode, cartId, item.Quantity);

    return CreatedAtRoute("GetById", new { cartId = cartId }, null);
  }
}

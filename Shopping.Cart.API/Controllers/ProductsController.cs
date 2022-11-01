using Microsoft.AspNetCore.Mvc;
using Shopping.Cart.Data.Context.Repositories;
using Shopping.Cart.Data.Models;

namespace Shopping.Cart.API.Controllers
{
  [ApiController]
  [Route("api/products")]
  public class ProductsController : ControllerBase
  {
    private readonly IProductsRepository _repository;

    public ProductsController(IProductsRepository repository)
    {
      this._repository = repository;
    }

    [HttpGet()]
    public async Task<IEnumerable<Product>> Get()
    {
      return await this._repository.QueryAll();
    }
  }
}
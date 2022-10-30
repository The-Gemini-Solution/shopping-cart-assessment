using Shopping.Cart.Domain.Services;

namespace Shopping.Cart.Domain.xTests.Services
{
  public class ShoppingCartServiceTests
  {
    [Fact]
    public void CanCreateShoppingCart()
    {
      var cart = new ShoppingCartService();

      Assert.NotNull(cart);
    }

    [Fact]
    public void Can_Add1Item()
    {
      var cart = new ShoppingCartService();

      Assert.Throws<NotImplementedException>(() => cart.Add(ProductsObjectMother.Bananas));
    }

    [Fact]
    public void Can_AddMultipleOfTheSameItem()
    {
      var cart = new ShoppingCartService();

      Assert.Throws<NotImplementedException>(() => cart.Add(ProductsObjectMother.Bananas));
    }

    [Fact]
    public void Can_AddMultipleDifferentItems()
    {
      var cart = new ShoppingCartService();

      Assert.Throws<NotImplementedException>(() => cart.Add(ProductsObjectMother.Bananas, 1));
      Assert.Throws<NotImplementedException>(() => cart.Add(ProductsObjectMother.Butternut, 2));
    }

    [Fact]
    public void Can_UpdateAnItem()
    {
      var cart = new ShoppingCartService();

      Assert.Throws<NotImplementedException>(() => cart.Update(ProductsObjectMother.Apples, 3));
    }

    [Fact]
    public void Can_RemoveAnItem()
    {
      var cart = new ShoppingCartService();

      Assert.Throws<NotImplementedException>(() => cart.Remove(ProductsObjectMother.Bananas));
    }
  }
}
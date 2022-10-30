using Shopping.Cart.Domain.Entities;
using Shopping.Cart.Domain.Services;

namespace Shopping.Cart.Domain.Tests.Services
{
  [TestFixture]
  public class ShoppingCartServiceTests
  {
    [Test]
    public void CanCreateShoppingCart()
    {
      var cart = new ShoppingCartService();

      Assert.IsNotNull(cart);
    }

    [Test]
    public void Can_Add1Item()
    {
      var cart = new ShoppingCartService();

      Assert.Throws<NotImplementedException>(() => cart.Add(ProductsObjectMother.Bananas));
    }

    [Test]
    public void Can_AddMultipleOfTheSameItem()
    {
      var cart = new ShoppingCartService();

      Assert.Throws<NotImplementedException>(() => cart.Add(ProductsObjectMother.Bananas));
    }

    [Test]
    public void Can_AddMultipleDifferentItems()
    {
      var cart = new ShoppingCartService();

      Assert.Throws<NotImplementedException>(() => cart.Add(ProductsObjectMother.Bananas, 1));
      Assert.Throws<NotImplementedException>(() => cart.Add(ProductsObjectMother.Butternut, 2));
    }

    [Test]
    public void Can_UpdateAnItem()
    {
      var cart = new ShoppingCartService();

      Assert.Throws<NotImplementedException>(() => cart.Update(ProductsObjectMother.Bananas, 3));
    }

    [Test]
    public void Can_RemoveAnItem()
    {
      var cart = new ShoppingCartService();

      Assert.Throws<NotImplementedException>(() => cart.Remove(ProductsObjectMother.Bananas));
    }
  }
}
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

      Assert.Throws<NotImplementedException>(() => cart.Add());
    }

    [Test]
    public void Can_AddMultipleItems()
    {
      var cart = new ShoppingCartService();

      Assert.Throws<NotImplementedException>(() => cart.Add());
      Assert.Throws<NotImplementedException>(() => cart.Add());
    }

    [Test]
    public void Can_UpdateAnItem()
    {
      var cart = new ShoppingCartService();

      Assert.Throws<NotImplementedException>(() => cart.Update());
    }

    [Test]
    public void Can_RemoveAnItem()
    {
      var cart = new ShoppingCartService();

      Assert.Throws<NotImplementedException>(() => cart.Remove());
    }
  }
}
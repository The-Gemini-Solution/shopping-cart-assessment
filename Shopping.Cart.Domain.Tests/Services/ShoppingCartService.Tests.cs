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

      Assert.Throws<NotImplementedException>(() => cart.Add(ProductsObjectMother.Bananas, 2));
    }

    [Test]
    public void Can_AddMultipleDifferentItems()
    {
      var cart = new ShoppingCartService();

      Assert.Throws<NotImplementedException>(() => cart.Add(ProductsObjectMother.Bananas, 2));
      Assert.Throws<NotImplementedException>(() => cart.Add(ProductsObjectMother.Apples, 3));
    }

    [Test]
    public void Can_UpdateAnItem()
    {
      var cart = new ShoppingCartService();

      Assert.Throws<NotImplementedException>(() => cart.Update(ProductsObjectMother.Spinach, 4));
    }

    [Test]
    public void Can_RemoveAnItem()
    {
      var cart = new ShoppingCartService();

      Assert.Throws<NotImplementedException>(() => cart.Remove(ProductsObjectMother.Apples));
    }
  }
}
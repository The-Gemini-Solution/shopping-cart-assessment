using System;
using Shopping.Cart.Domain.Entities;

namespace Shopping.Cart.Domain.xTests
{
  public static class ProductsObjectMother
  {
    public static Guid BananaId = Guid.Parse("3e5f63a4-aa8a-4575-a99c-9832c86e5f6d");
    public static Guid AppleId = Guid.Parse("3f277c02-5b83-4668-bd96-b90c428cd9a9");
    public static Guid ButternutId = Guid.Parse("d917926f-54ab-4549-9f9c-4185cd3b571b");
    public static Guid SpinachId = Guid.Parse("d917926f-54ab-4549-9f9c-4185cd3b571b");

    private static Product CreateProduct(Guid barCode, string name, string description, Category category/*, ? price*/)
    {
      return new Product(barCode)
      {
        Name = name,
        Description = description,
        Category = category,
        // UnitPrice = price
      };
    }

    public static Product Bananas
    {
      get 
      {
        return ProductsObjectMother.CreateProduct(
          ProductsObjectMother.BananaId, 
          "Bananas", 
          "Bag of Bananas", 
          Category.FRUIT
        );
      }
    }

    public static Product Apples
    {
      get 
      {
        return ProductsObjectMother.CreateProduct(
          ProductsObjectMother.AppleId, 
          "Apples", 
          "Bag of Apples", 
          Category.FRUIT
        );
      }
    }

    public static Product Butternut
    {
      get 
      {
        return ProductsObjectMother.CreateProduct(
          ProductsObjectMother.ButternutId, 
          "Butternut", 
          "Bag of Butternut", 
          Category.VEGETABLES
        );
      }
    }

    public static Product Spinach
    {
      get 
      {
        return ProductsObjectMother.CreateProduct(
          ProductsObjectMother.SpinachId, 
          "Spinach", 
          "Bag of Spinach", 
          Category.VEGETABLES
        );
      }
    }
  }
}
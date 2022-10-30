namespace Shopping.Cart.Domain.Entities
{
  public enum Category
  {
    NONE,
    FRUIT,
    VEGETABLES
  }

  public class Product
  {
    public Guid BarCode { get; private set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Category Category { get; set; }
    // public int or decimal UnitPrice { get; set; }

    public Product(Guid barCode)
    {
      this.BarCode = barCode;
      this.Name = "";
      this.Description = "";
      this.Category = Category.NONE;
      // this.UnitPrice = ?; 0 or 0.0M
    }
  }
}
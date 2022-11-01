namespace Shopping.Cart.Data.Models
{
  public class Product
  {
    public string? BarCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public int UnitPrice { get; set; }

    public Product()
    {
      this.Name = "";
      this.Description = "";
      this.Category = "";
      this.UnitPrice = 0;
    }
  }
}
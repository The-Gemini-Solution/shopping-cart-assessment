namespace Shopping.Cart.API.Models
{
  public class ItemModel
  {
    public string? BarCode { get; set; }
    public int Quantity { get; set; }

    public ItemModel()
    {
      this.Quantity = 0;
    }
  }
}
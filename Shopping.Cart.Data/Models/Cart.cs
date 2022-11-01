namespace Shopping.Cart.Data.Models
{
  public class Cart
  {
    public string? Id { get; set; }
    public IList<Item> Items { get; set; }

    public Cart()
    {
      this.Items = new List<Item>();
    }
  }
}
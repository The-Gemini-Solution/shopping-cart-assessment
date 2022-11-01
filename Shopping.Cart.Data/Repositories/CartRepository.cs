using Dapper;
using Shopping.Cart.Data.Configuration;
using Shopping.Cart.Data.Models;

namespace Shopping.Cart.Data.Context.Repositories
{
  public interface ICartRepository
  {
    public void CreateTable();
    public Task Add(Models.Cart cart);
    public Task<Models.Cart> GetById(string Id);
    public Task<IEnumerable<string>> QueryAll();
  }

  public class CartRepository : Repository, ICartRepository
  {
    public CartRepository(IDBConfig dbConfig)
      : base(dbConfig)
    {
    }

    public void CreateTable()
    {
      var sql = "CREATE TABLE \"Carts\" (\"Id\" TEXT NOT NULL CONSTRAINT \"PK_ShoppingCarts\" PRIMARY KEY)";

      base.ExecuteCreateDDL("Carts", sql);
    }

    public async Task Add(Models.Cart cart)
    {
      using (var connection = base.CreateConnection())
      {
        var command = connection.CreateCommand();

        command.CommandText = "insert into Carts(Id) values($Id)";
        command.Parameters.AddWithValue("$Id", cart.Id);

        try
        {
          await connection.OpenAsync();
          command.ExecuteNonQuery();
        }
        finally
        {
          await connection.CloseAsync();
        }

      }
    }

    public async Task<Models.Cart> GetById(string Id)
    {
      using (var connection = base.CreateConnection())
      {
        var sql = 
        @"select Products.BarCode, Products.Name, Products.Description, Products.Category, Products.UnitPrice, Items.Quantity
        from Items
        inner join Products on Items.BarCode = Products.BarCode
        where Items.CartId = @CartId";
        var cart = new Models.Cart() { Id = Id };
        var reader = await connection.ExecuteReaderAsync(sql, new { CartId = Id });

        while (reader.Read())
        {
          cart.Items.Add(new Item() {
            Product = new Product()
            {
              BarCode = reader.GetString(0),
              Name = reader.GetString(1),
              Description = reader.GetString(2),
              Category = reader.GetString(3),
              UnitPrice = reader.GetInt32(4)
            },
            Quantity = reader.GetInt32(5)
          });
        }
        await reader.CloseAsync();

        return cart;
      }
    }

    public async Task<IEnumerable<string>> QueryAll()
    {
      using (var connection = base.CreateConnection())
      {
        try
        {
          await connection.OpenAsync();

          var result = new List<string>();
          var reader = await connection.ExecuteReaderAsync("select Id from Carts");

          while (reader.Read())
          {
            result.Add(reader.GetString(0));
          }
          await reader.CloseAsync();

          return result;
        }
        finally
        {
          await connection.CloseAsync();
        }
      }
    }
  }
}
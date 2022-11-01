using Dapper;
using Shopping.Cart.Data.Configuration;

namespace Shopping.Cart.Data.Context.Repositories
{
  public interface IItemsRepository
  {
    void CreateTable();
    Task Add(string barCode, string cartId, int quantity);
    Task Update(string barCode, string cartId, int quantity);
    Task Remove(string barCode, string cartId);
  }

  public class ItemsRepository : Repository, IItemsRepository
  {
    public ItemsRepository(IDBConfig dbConfig) 
      : base(dbConfig)
    {
    }

    public void CreateTable()
    {
      var sql = @"CREATE TABLE ""Items"" (
      ""BarCode"" TEXT NOT NULL,
      ""CartId"" TEXT NOT NULL,
      ""Quantity"" INTEGER NULL,
      PRIMARY KEY (""BarCode"", ""CartId"")
      )";
      base.ExecuteCreateDDL("Items", sql);
    }

    public async Task Add(string barCode, string cartId, int quantity)
    {
      using (var connection = base.CreateConnection())
      {
        var command = connection.CreateCommand();

        command.CommandText = "insert into Items(BarCode, CartId, Quantity) values($BarCode, $CartId, $Quantity)";
        command.Parameters.AddWithValue("$BarCode", barCode);
        command.Parameters.AddWithValue("$CartId", cartId);
        command.Parameters.AddWithValue("$Quantity", quantity);

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

    public async Task Update(string barCode, string cartId, int quantity)
    {
      using (var connection = base.CreateConnection())
      {
        var sql = "update Items set Quantity = @Quantity where BarCode = @BarCode and CartId = @CartId";

        await connection.ExecuteAsync(sql, new { Quantity = quantity, BarCode = barCode, CartId = cartId });
      }
    }

    public async Task Remove(string barCode, string cartId)
    {
      using (var connection = base.CreateConnection())
      {
        var sql = "delete from Items where BarCode = @BarCode and CartId = @CartId";

        await connection.ExecuteAsync(sql, new { BarCode = barCode, CartId = cartId });
      }
    }
  }
}
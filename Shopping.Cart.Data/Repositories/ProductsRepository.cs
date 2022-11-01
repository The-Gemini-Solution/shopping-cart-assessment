using System.Data;
using Dapper;
using Shopping.Cart.Data.Configuration;
using Shopping.Cart.Data.Models;

namespace Shopping.Cart.Data.Context.Repositories
{
  public interface IProductsRepository
  {
    void CreateTable();
    Task Add(Product product);
    Task<int> Count();
    Task<IEnumerable<Product>> QueryAll();
    Task<Product> GetById(string id);
  }

  public class ProductsRepository : Repository, IProductsRepository
  {
    public ProductsRepository(IDBConfig dbConfig)
      : base(dbConfig)
    {
    }

    public void CreateTable()
    {
      var sql = @"CREATE TABLE ""Products"" (
      ""BarCode"" TEXT NOT NULL CONSTRAINT ""PK_Products"" PRIMARY KEY,
      ""Name"" TEXT NOT NULL,
      ""Description"" TEXT NOT NULL,
      ""Category"" TEXT NOT NULL,
      ""UnitPrice"" INTEGER NOT NULL)";
      base.ExecuteCreateDDL("Products", sql);
    }

    public async Task Add(Product product)
    {
      using (var connection = base.CreateConnection())
      {
        try
        {
          var command = connection.CreateCommand();

          command.CommandText = @"insert into Products(BarCode, Name, Description, Category, UnitPrice)
        values($BarCode, $Name, $Description, $Category, $UnitPrice)";
          command.Parameters.AddWithValue("$BarCode", product.BarCode);
          command.Parameters.AddWithValue("$Name", product.Name);
          command.Parameters.AddWithValue("$Description", product.Description);
          command.Parameters.AddWithValue("$Category", product.Category);
          command.Parameters.AddWithValue("$UnitPrice", product.UnitPrice);
          await connection.OpenAsync();

          var result = await command.ExecuteNonQueryAsync();

          if (result == 0)
          {
            throw new Exception("Unable to insert product");
          }
        }
        finally
        {
          await connection.CloseAsync();
        }
      }
    }

    public async Task<int> Count()
    {
      using (var connection = base.CreateConnection())
      {
        return await connection.ExecuteScalarAsync<int>("select count(*) from Products");
      }
    }

    public async Task<IEnumerable<Product>> QueryAll()
    {
      using (var connection = base.CreateConnection())
      {
        try
        {
          await connection.OpenAsync();

          return await connection
            .QueryAsync<Product>("select BarCode, Name, Description, Category, UnitPrice from Products");
        }
        finally
        {
          await connection.CloseAsync();
        }
      }
    }

    public async Task<Product> GetById(string id)
    {
      using (var connection = base.CreateConnection())
      {
        try
        {
          await connection.OpenAsync();

          return await connection.ExecuteScalarAsync<Product>(
            "select BarCode, Name, Description, Category, UnitPrice from Products where Id = $Id",
            new { Id = id });
        }
        finally
        {
          await connection.CloseAsync();
        }
      }
    }
  }
}
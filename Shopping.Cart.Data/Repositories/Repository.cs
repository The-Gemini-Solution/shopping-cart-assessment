using Dapper;
using Microsoft.Data.Sqlite;
using Shopping.Cart.Data.Configuration;
using Shopping.Cart.Data.Models;

namespace Shopping.Cart.Data.Context.Repositories
{
  public abstract class Repository
  {
    protected IDBConfig dBConfig;
    public Repository(IDBConfig dbConfig)
    {
      this.dBConfig = dbConfig;
    }

    protected SqliteConnection CreateConnection()
    { 
      return new SqliteConnection(this.dBConfig.ConnectionString);
    }

    public void ExecuteCreateDDL(string name, string ddl)
    {
      using (var connection = this.CreateConnection())
      {
        var exists = connection.ExecuteScalar<int>($"select count(name) from sqlite_master WHERE type='table' AND name='{name}'") > 0;

        if (!exists) {
          try {
            connection.Execute(ddl);
          }
          catch (Exception ex) {
            Console.WriteLine($"Error executing ddl {ex.Message}");
          }
        }
      }
    }
  }
}
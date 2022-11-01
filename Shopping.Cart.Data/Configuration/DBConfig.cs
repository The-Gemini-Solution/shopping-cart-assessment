namespace Shopping.Cart.Data.Configuration
{
  public class DBConfig : IDBConfig
  {
    private string _connectionString;
    public string ConnectionString { get { return this._connectionString; } }
    public DBConfig(string connectionString)
    {
      this._connectionString = connectionString;
    }
  }
}
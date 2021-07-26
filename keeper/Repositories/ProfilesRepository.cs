using System.Data;
using Dapper;
using keeper.Models;

namespace keeper.Repositories
{
  public class ProfilesRepository
  {
    private readonly IDbConnection _db;
    public ProfilesRepository(IDbConnection db)
    {
      _db = db;
    }
    internal Profile GetProfile(string id)
        {
            string sql = @"
            SELECT * FROM accounts
            WHERE id = @id;";
            return _db.QueryFirstOrDefault<Account>(sql, new { id });

        }
  }
}
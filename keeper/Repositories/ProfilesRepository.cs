using System.Collections.Generic;
using System.Data;
using System.Linq;
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
    internal List<Keep> GetKeepsByProfileId(string id)
    {
      string sql = @"
      SELECT 
      k.*,
      a.*
      FROM keeps k
      JOIN accounts a ON a.id = k.creatorId
      WHERE k.creatorId = @id;";
      return _db.Query<Keep, Account, Keep>(sql, (k,a)=>
      {
        k.Creator = a;
        return k;
      }, new { id }, splitOn: "id").ToList();
    }
    internal List<Vault> GetVaultsByProfileId(string id)
    {
      string sql = @"
      SELECT
      v.*,
      a.*
      FROM vaults v
      JOIN accounts a ON a.id = v.creatorId
      WHERE v.creatorId = @id;";
      return _db.Query<Vault, Account, Vault>(sql, (v,a)=>
      {
        v.Creator = a;
        return v;
      }, new { id }, splitOn: "id").ToList();
    }
  }
}
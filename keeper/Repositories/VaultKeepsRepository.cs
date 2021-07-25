using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keeper.Models;

namespace keeper.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal List<Keep> GetKeepsByVaultId(int id)
    {
      string sql = @"
      SELECT * 
      FROM keeps k
      JOIN account a ON a.id = k.accountId
      WHERE vaultId = @id;";
      return _db.Query<Keep, Profile, Keep>(sql, (k,p)=>
      {
        k.Creator = p;
        return k;
      }, new { id }).ToList();
    }
  }
}
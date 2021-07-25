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
    internal VaultKeep getOne(int id)
    {
      string sql = @"
      SELECT * FROM vaultkeeps
      WHERE id = @id;";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });
    }
    internal List<Keep> GetKeepsByVaultId(int id)
    {
      string sql = @"
      SELECT * 
      FROM keeps k
      JOIN account a ON a.id = k.creatorId
      WHERE vaultId = @id;";
      return _db.Query<Keep, Profile, Keep>(sql, (k,p)=>
      {
        k.Creator = p;
        return k;
      }, new { id }).ToList();
    }
    internal List<Vault> GetVaultsByKeepId(int id)
    {
      string sql = @"
      SELECT * 
      FROM vaults v
      JOIN account a ON a.id = v.creatorId
      WHERE keepId = @id;";
      return _db.Query<Vault, Profile, Vault>(sql, (v,p)=>
      {
        v.Creator = p;
        return v;
      }, new { id }).ToList();
    }
    internal VaultKeep Create(VaultKeep vk)
    {
      string sql = @"
      INSERT INTO
        vaultkeeps(creatorId, vaultId, keepId)
      VALUES(@CreatorId, @VaultId, @KeepId)
      SELECT LAST_INSERT_ID();";
      vk.Id = _db.ExecuteScalar<int>(sql, vk);
      return vk;
    }
    internal void Delete(int id){
      string sql = @"
      DELETE FROM vaultkeeps
      WHERE id = @id;";
     _db.Execute(sql, new { id });
    }
  }
}
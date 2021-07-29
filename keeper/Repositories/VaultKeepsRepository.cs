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
      SELECT 
      vk.*
      FROM vaultkeeps vk
      WHERE vk.id = @id;";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });
    }
    internal List<KeepsViewModel> GetKeepsByVaultId(int id)
    {
      string sql = @"
      SELECT 
      k.*,
      vk.*,
      a.*
      FROM keeps k
      JOIN vaultkeeps vk on k.id = vk.keepId
      JOIN accounts a ON k.creatorId = a.id
      WHERE vk.vaultId = @id;";
      return _db.Query<KeepsViewModel, VaultKeep, Profile, KeepsViewModel>(sql, (k,vk,p)=>
      {
        k.Creator = p;
        k.VaultKeepId = vk.Id;
        return k;
      },new { id }, splitOn: "id").ToList();
    }

    internal VaultKeep Create(VaultKeep vk)
    {
      string sql = @"
      INSERT INTO
        vaultkeeps(creatorId, vaultId, keepId)
      VALUES(@CreatorId, @VaultId, @KeepId);
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
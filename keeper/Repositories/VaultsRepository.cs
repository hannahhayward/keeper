using System.Data;
using System.Linq;
using Dapper;
using keeper.Models;

namespace keeper.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;
    public VaultsRepository(IDbConnection db)
    {
      _db = db;
  }
  internal Vault GetById(int id)
  {
    string sql = @"
    SELECT
    v.*,
    a.*
    FROM vaults v
    JOIN accounts a ON a.id = v.creatorId
    WHERE v.id = @id;";
    return _db.Query<Vault, Profile, Vault>(sql, (v,p)=>
    {
      v.Creator = p;
      return v;
    }, new { id }).FirstOrDefault();
  }
  internal Vault Create(Vault vault)
  {
    string sql = @"
    INSERT INTO vaults
    (name,description,isPrivate,creatorId)
    VALUES (@Name, @Description, @IsPrivate, @CreatorId);
    SELECT LAST_INSERT_ID();";
    vault.Id = _db.ExecuteScalar<int>(sql, vault);
    return vault;
  }
  internal Vault Update(Vault vault)
  {
    string sql = @"
    UPDATE vaults
    SET
      name = @Name,
      description = @Description,
      isPrivate = @IsPrivate
    WHERE id = @Id;";
    _db.Execute(sql, vault);
    return vault;
  }
  internal void Delete(int id)
  {
    string sql = @"
    DELETE FROM vaults
    WHERE id = @Id;";
    _db.Execute(sql, new { id });
  }
  }
}
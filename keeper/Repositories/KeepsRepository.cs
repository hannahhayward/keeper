using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keeper.Models;

namespace keeper.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;
    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal Keep Create(Keep keep)
    {
      string sql = @"
      INSERT INTO keeps
      (name,description,img,creatorId)
      VALUES (@Name, @Description, @Img, @CreatorId);
      SELECT LAST_INSERT_ID();";
      keep.Id = _db.ExecuteScalar<int>(sql, keep);
      return keep;
    }
    internal List<Keep> GetAll()
    {
      string sql = @"
      SELECT
      k.*,
      a.*
      FROM keeps k
      JOIN accounts a ON k.creatorId = a.id;";
      return _db.Query<Keep, Account, Keep>(sql, (k,a)=>
      {
        k.Creator = a;
        return k;
      }, splitOn: "id").ToList();
    }
  }
}
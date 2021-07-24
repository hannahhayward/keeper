using System.Data;
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
      (name,description,img,views,keeps,shares,creatorId)
      VALUES (@Name, @Description, @Img, 0, 0, 0, @CreatorId);
      SELECT LAST_INSERT_ID();";
      keep.Id = _db.ExecuteScalar<int>(sql, keep);
      return keep;
    }
  }
}
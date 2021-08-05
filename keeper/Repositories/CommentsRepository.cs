using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keeper.Models;

namespace keeper.Repositories
{
  public class CommentsRepository
  {
    private readonly IDbConnection _db;
    public CommentsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal Comment Create(Comment comment)
    {
      string sql = @"
      INSERT INTO comments
      (body, keepId, creatorId)
      VALUES (@Body, @KeepId, @CreatorId);
      SELECT LAST_INSERT_ID();";
      comment.Id = _db.ExecuteScalar<int>(sql, comment);
      return comment;
    }
    internal Comment GetById(int id) 
    {
      string sql = @"
      SELECT 
      c.*,
      a.*
      FROM keeps k
      JOIN accounts a on c.creatorId = a.id
      Where k.id = @id;";
      return _db.Query<Comment, Profile, Comment>(sql, (c, p) =>
      {
        c.Creator = p;
        return c;
      }, new { id }).FirstOrDefault();
    }
    internal List<Comment> GetByKeepId(int id) 
    {
      string sql = @"
      SELECT 
      k.*,
      c.*,
      a.*
      FROM keeps k
      JOIN accounts a on c.creatorId = a.id
      Where k.id = @id;";
      return _db.Query<Comment, Profile, Comment>(sql, (c, p) =>
      {
        c.Creator = p;
        return c;
      }, new { id }).ToList();
    }
    internal Comment Update(Comment comment)
    {
      string sql = @"
      UPDATE comments
      SET 
      body = @Body
      WHERE id = @Id;";
      _db.Execute(sql, comment);
      return comment;
    }
    internal void Delete(int id)
    {
      string sql = @"
      DELETE FROM comments
      WHERE id = @Id;";
      _db.Execute(sql, new { id });
    }
  }
}
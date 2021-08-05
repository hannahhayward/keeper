using System;
using System.Collections.Generic;
using keeper.Models;
using keeper.Repositories;

namespace keeper.Services
{
  public class CommentsService
  {
    
    private readonly KeepsRepository _kr;
    private readonly CommentsRepository _cr;

    public CommentsService(KeepsRepository kr, CommentsRepository cr)
    {
      _kr = kr;
      _cr = cr;
    }

    public Comment Create(Comment comment, string userId)
    {
      Keep keep = _kr.GetById(comment.KeepId);
      if(userId == null)
      {
        throw new Exception("log in please");
      }
      return _cr.Create(comment);
    }
    public List<Comment> GetByKeepId(int id)
    {
      var comments = _cr.GetByKeepId(id);
      return comments;
    }
    public Comment GetById(int id, string userId)
    {
      var comment = _cr.GetById(id);
      if(comment != null && userId == comment.CreatorId)
      {
        return comment;
      }
      throw new Exception("cannot get this comment");
    }
    public Comment Update(Comment comment, int id, string userId)
    {
      Comment original = _cr.GetById(id);
      if(comment != null && original.CreatorId == userId)
      {
        return _cr.Update(comment);
      }
        throw new Exception("cannot edit this comment");
    }
    public void Delete(int id, string userId)
    {
      Comment comment = _cr.GetById(id);
      if(comment != null && comment.CreatorId == userId)
      {
        _cr.Delete(id);
      }
      throw new Exception("cannot delete this comment");
    }
  }
}
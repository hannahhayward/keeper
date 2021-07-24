using System;
using System.Collections.Generic;
using keeper.Models;
using keeper.Repositories;
using Microsoft.AspNetCore.Http;

namespace keeper.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _kr;
    public KeepsService(KeepsRepository kr)
    {
      _kr = kr;
    }
    public Keep Create(Keep keep)
    {
     return _kr.Create(keep);
    }
    public List<Keep> GetAll()
    {
      return _kr.GetAll();
    }
    public Keep GetById(int id)
    {
      var k = _kr.GetById(id);
      if(k ==null)
      {
        throw new Exception("cannot find a keep with that Id");
      }
      return k;
    }
    public Keep Update(Keep keep, string userId)
    {
      Keep original = _kr.GetById(keep.Id);
      if(keep == null)
      {
        throw new Exception("no keep found with that Id");
      }
      if(original.CreatorId == keep.CreatorId)
      {
      keep.Views = keep.Views > original.Views ? keep.Views : original.Views;
      keep.Shares = keep.Shares > original.Shares ? keep.Shares : original.Shares;
      keep.Keeps = keep.Keeps > original.Keeps ? keep.Keeps : original.Keeps;
      return _kr.Update(keep);      
      }
      throw new Exception("nice try buddy this isnt yours");
    }
    public void Delete(int id, string userId)
    {
      Keep keep = _kr.GetById(id);
      if(keep == null)
      {
        throw new Exception("no keep found with that Id"); 
      }
      if(keep.CreatorId != userId)
      {
        throw new Exception("nice try buddy that isn't yours");
      }
      _kr.Delete(id);
    }
  }
}
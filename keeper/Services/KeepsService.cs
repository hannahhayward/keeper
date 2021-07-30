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
    private readonly VaultKeepsRepository _vkr;

    public KeepsService(KeepsRepository kr, VaultKeepsRepository vkr)
    {
      _kr = kr;
      _vkr = vkr;
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
      k.Views += 1;
      _kr.Update(k);
      if(k ==null)
      {
        throw new Exception("cannot find a keep with that Id");
      }
      return k;
    }
    public Keep Update(Keep keep, string userId)
    {
      Keep original = _kr.GetById(keep.Id);
      if(original.Keeps != keep.Keeps)
      {
        return _kr.Update(keep);
      }
      if(keep == null)
      {
        throw new Exception("no keep found with that Id");
      }
      if(original.CreatorId != keep.CreatorId){
        throw new Exception("cannot edit something that is not yours");
      }
      return _kr.Update(keep);
      
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
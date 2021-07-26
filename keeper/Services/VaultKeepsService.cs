using System;
using keeper.Models;
using keeper.Repositories;

namespace keeper.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _vkr;
    
    public VaultKeepsService(VaultKeepsRepository vkr)
    {
      _vkr = vkr;
    }
    internal VaultKeep Create(VaultKeep vk)
    {
      return _vkr.Create(vk);
    }
    internal VaultKeep GetOne(int id)
    {
      return _vkr.getOne(id);
    }
    internal VaultKeep Delete(int id, string userId)
    {
      VaultKeep vk = GetOne(id);
      if(vk.CreatorId != userId)
      {
        throw new Exception("nice try buddy that isn't yours");
      }
      if(vk == null)
      {
        throw new Exception("cannot find vault keep with that id");
      }
      _vkr.Delete(id);
      return vk;
    }
}
}
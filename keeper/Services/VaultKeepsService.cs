using System;
using keeper.Models;
using keeper.Repositories;

namespace keeper.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _vkr;
    private readonly VaultsRepository _vr;
    public VaultKeepsService(VaultKeepsRepository vkr, VaultsRepository vr)
    {
      _vkr = vkr;
      _vr = vr;
    }

    internal VaultKeep Create(VaultKeep vk, string userId)
    {
      Vault vault = _vr.GetById(vk.VaultId);
      if(vault.CreatorId == userId){
      return _vkr.Create(vk);
      }
      if(vault.CreatorId != userId)
      {
      throw new Exception("this is not yours");
      }

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
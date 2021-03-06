using System;
using System.Collections.Generic;
using keeper.Models;
using keeper.Repositories;

namespace keeper.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _vr;
    private readonly VaultKeepsRepository _vkr;
    public VaultsService(VaultsRepository vr, VaultKeepsRepository vkr)
    {
      _vr = vr;
      _vkr = vkr;
    }

    public Vault GetById(int id, string userId)
    {
      var vault = _vr.GetById(id);
      if(vault == null)
      {
        throw new Exception("cannot find vault with that Id");
      }
      if(userId != vault.CreatorId){
      if(vault.IsPrivate != false)
      {
        throw new Exception("this vault is private");
      }
      }
      return vault;
    }
    public Vault Create(Vault vault)
    {
      return _vr.Create(vault);
    }
    public Vault Update(Vault vault, string userId, int id)
    {
      Vault original = _vr.GetById(id);
      if(vault == null){
        throw new Exception("cannot find vault with that Id");
      }
      if(original.CreatorId == userId)
      {
        vault.IsPrivate = vault.IsPrivate == original.IsPrivate ? vault.IsPrivate : original.IsPrivate;
        return _vr.Update(vault);
      }
      throw new Exception("nice try buddy this isnt yours");
    }
    internal List<KeepsViewModel> GetKeepsByVaultId(int id, string userId)
    {
      var vault = _vr.GetById(id);
      if(vault.IsPrivate != false && vault.CreatorId != userId)
      {
        throw new Exception("this vault is private");
      }
      var keeps = _vkr.GetKeepsByVaultId(id);
      return keeps;
    }
    public void Delete(int id, string userId)
    {
      Vault vault = _vr.GetById(id);
      if(vault == null)
      {
        throw new Exception("no vault found with that Id"); 
      }
      if(vault.CreatorId != userId)
      {
        throw new Exception("nice try buddy that isn't yours");
      }
      _vr.Delete(id);
    }
  }
}
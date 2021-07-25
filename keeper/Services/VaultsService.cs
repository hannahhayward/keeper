using System;
using keeper.Models;
using keeper.Repositories;

namespace keeper.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _vr;
    public VaultsService(VaultsRepository vr)
    {
      _vr = vr;
    }
    public Vault GetById(int id)
    {
      var vault = _vr.GetById(id);
      if(vault == null)
      {
        throw new Exception("cannot find vault with that Id");
      }
      return vault;
    }
    public Vault Create(Vault vault)
    {
      return _vr.Create(vault);
    }
    public Vault Update(Vault vault, string userId)
    {
      Vault original = _vr.GetById(vault.Id);
      if(vault == null){
        throw new Exception("cannot find vault with that Id");
      }
      if(original.CreatorId == vault.CreatorId)
      {
        vault.IsPrivate = vault.IsPrivate == original.IsPrivate ? vault.IsPrivate : original.IsPrivate;
        return _vr.Update(vault);
      }
      throw new Exception("nice try buddy this isnt yours");
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
using System;
using System.Collections.Generic;
using keeper.Models;
using keeper.Repositories;

namespace keeper.Services
{
  public class ProfilesService
  {
    private readonly ProfilesRepository _pr;
    public ProfilesService(ProfilesRepository pr)
    {
      _pr = pr;
    }
    internal Profile GetProfile(string id)
        {
            var p = _pr.GetProfile(id);
            if(p ==null)
                {
                throw new Exception("cannot find a profile with that Id");
                }
            return p;
        }
    internal List<Keep> GetKeepsByProfileId(string id)
    {
      var keeps = _pr.GetKeepsByProfileId(id);
      if(keeps == null)
      {
        throw new Exception("this user has no keeps");
      }
      return keeps;
    }
    internal List<Vault> GetVaultsByProfileId(string id, string userId)
    {
      List<Vault> vaults = _pr.GetVaultsByProfileId(id);
      List<Vault> publicvaults = new List<Vault>();
      if(vaults == null)
      {
        throw new Exception("this user has no vaults");
      }
        if(userId == null)
        {
          foreach(var vault in vaults)
        {
          if(vault.IsPrivate == false)
          {
            publicvaults.Add(vault);
          }
        }
        // if(userId == null)
        // {
        //   return publicvaults;
        // }
        return publicvaults;
        }
        return vaults;
    }
  }
}
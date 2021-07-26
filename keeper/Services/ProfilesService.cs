using System;
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
  }
}
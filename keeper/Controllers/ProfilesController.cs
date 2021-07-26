using System;
using System.Collections.Generic;
using keeper.Models;
using keeper.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keeper.Controllers
{

[ApiController]
[Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _ps;
    public ProfilesController(ProfilesService ps)
    {
      _ps = ps;
    }
    [HttpGet("{id}")]
    public ActionResult<Profile> GetProfile(string id)
      {
        try
          {
            Profile profile = _ps.GetProfile(id);
            return Ok(profile);
          }
            catch (System.Exception e)
          {
            return BadRequest(e.Message);
          }
        }
    [HttpGet("{id}/keeps")]
    public ActionResult<List<Keep>> GetKeepsByProfileId(string id)
    {
      try
      {
        List<Keep> keeps = _ps.GetKeepsByProfileId(id);
        return Ok(keeps);
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/vaults")]
    public ActionResult<List<Vault>> GetVaultsByProfileId(string id)
    {
      try
      {
        List<Vault> vaults = _ps.GetVaultsByProfileId(id);
        List<Vault> publicvaults = new List<Vault>();
        foreach(var vault in vaults)
        {
          if(vault.IsPrivate == false)
          {
            publicvaults.Add(vault);
          }
        }
            return publicvaults;
        // for (int i = 0; i < vaults.Count; i++)
        // {
        //     if(vaults[i].IsPrivate != false)
        //     {
        //       vaults.Remove(vaults[i]);
        //       return vaults;
        //     }
        //     return vaults;
        // }
        // return Ok(vaults);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
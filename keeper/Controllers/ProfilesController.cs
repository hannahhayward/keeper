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
    [Authorize]
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
    [Authorize]
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
    [Authorize]
    public ActionResult<List<Vault>> GetVaultsByProfileId(string id)
    {
      try
      {
        List<Vault> vaults = _ps.GetVaultsByProfileId(id);
        return Ok(vaults);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
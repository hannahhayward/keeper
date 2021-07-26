using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
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
    private readonly AccountService _accs;
    public ProfilesController(ProfilesService ps, AccountService accs)
    {
      _ps = ps;
      _accs = accs;
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
    public async Task<ActionResult<List<Vault>>> GetVaultsByProfileId(string id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        List<Vault> vaults = _ps.GetVaultsByProfileId(id, userInfo?.Id);
          return vaults;
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
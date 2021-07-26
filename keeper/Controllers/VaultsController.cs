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
  public class VaultsController : ControllerBase
  {
    private readonly VaultsService _vs;
    public VaultsController(VaultsService vs)
    {
      _vs = vs;
    }
    [HttpGet("{id}")]
    public ActionResult<Vault> GetById(int id)
    {
      try
      {
          Vault vault = _vs.GetById(id);
          return Ok(vault);
      }
      catch (System.Exception e)
      {
          
          return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Vault>> Create([FromBody] Vault vault)
    {
      try
      {
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          vault.CreatorId = userInfo.Id;
          Vault newVault = _vs.Create(vault);
          newVault.Creator = userInfo;
          return Ok(newVault);
      }
      catch (System.Exception e)
      {
          
          return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Vault>> Update(int id, [FromBody] Vault vault)
    {
      try
      {
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          vault.Id = id;
          vault.CreatorId = userInfo.Id;
          Vault newVault = _vs.Update(vault, userInfo.Id);
          newVault.Creator = userInfo;
          return Ok(newVault);
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/keeps")]
    public ActionResult<List<KeepsViewModel>> GetKeepsByVaultId(int id)
    {
      try
      {
          List<KeepsViewModel> keeps = _vs.GetKeepsByVaultId(id);
          return Ok(keeps);
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }
    
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult<Vault>> Delete(int id)
    {
      try
      {
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _vs.Delete(id, userInfo.Id);
        return Ok("Vault has been deleted");
      }
      catch (System.Exception e)
      {
          
          return BadRequest(e.Message);
      }
    }
  }
}
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
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vks;
    public VaultKeepsController(VaultKeepsService vks)
    {
      _vks = vks;
    }
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<VaultKeep>> Create([FromBody] VaultKeep vaultKeep)
    {
      try
      {
          return Ok(_vks.Create(vaultKeep));
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<VaultKeep> GetOne(int id)
    {
      try
      {
          VaultKeep vk = _vks.GetOne(id);
          return Ok(vk);
      }
      catch (System.Exception e)
      {
          
          return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult<VaultKeep>> Delete(int id)
    {
      try
      {
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          _vks.Delete(id, userInfo.Id);
          return Ok("vaultkeep has been deleted");
      }
      catch (System.Exception e)
      {
          
          return BadRequest(e.Message);
      }
    }
  }
}
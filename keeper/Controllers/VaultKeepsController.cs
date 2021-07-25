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
    public async Task<ActionResult<VaultKeep>> Create([FromBody] VaultKeep vaultKeep, [FromBody] Vault vault, [FromBody] Keep keep)
    {
      try
      {
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          vaultKeep.CreatorId = userInfo.Id;
          Vault vaultInfo = _
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }
  }
}
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using keeper.Models;
using keeper.Services;
using Microsoft.AspNetCore.Mvc;

namespace keeper.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class KeepController : ControllerBase
  {
    private readonly KeepsService _ks;
    public KeepController(KeepsService ks)
    {
      _ks = ks;
    }
    [HttpPost]
    public async Task<ActionResult<Keep>> Create([FromBody] Keep keep)
    {
      try
      {
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          keep.CreatorId = userInfo.Id;
          Keep newKeep = _ks.Create(keep);
          newKeep.Creator = userInfo;
          return Ok(newKeep);
      }
      catch (System.Exception e)
      {
          
          return BadRequest(e.Message);
      }
    }
  }
}
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
  public class KeepsController : ControllerBase
  {
    private readonly KeepsService _ks;
    public KeepsController(KeepsService ks)
    {
      _ks = ks;
    }
    [Authorize]
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
    [HttpGet]
    public ActionResult<List<Keep>> GetAll()
    {
      try
      {
          List<Keep> keeps = _ks.GetAll();
          return Ok(keeps);
      }
      catch (System.Exception e)
      {
          
          return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Keep> GetById(int id)
    {
      try
      {
          Keep keep = _ks.GetById(id);
          return Ok(keep);
      }
      catch (System.Exception e)
      {
          
          return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<Keep>> Update(int id, [FromBody] Keep keep)
    {
      try
      {
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          keep.Id = id;
          keep.CreatorId = userInfo?.Id;
          Keep newKeep = _ks.Update(keep, userInfo?.Id);
          newKeep.Creator = userInfo;
          return Ok(newKeep);
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult<Keep>> Delete(int id)
    {
      try
      {
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _ks.Delete(id, userInfo.Id);
        return Ok("keep has been deleted");
      }
      catch (System.Exception e)
      {
          
          return BadRequest(e.Message);
      }
    }
  }
}
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
  public class CommentsController : ControllerBase
  {
    private readonly CommentsService _cs;
    public CommentsController(CommentsService cs)
    {
      _cs = cs;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Comment>> GetById(int id)
    {
      try
      {
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          Comment comment = _cs.GetById(id, userInfo?.Id);
          return Ok(comment);
      }
      catch (System.Exception e)
      {
          
          return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Comment>> Create([FromBody] Comment comment)
    {
      try
      {
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          comment.CreatorId = userInfo.Id;
          Comment newComment = _cs.Create(comment, userInfo.Id);
          newComment.Creator = userInfo;
          return Ok(newComment);
      }
      catch (System.Exception e)
      {
          
          return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Comment> GetById(int id, string userId)
    {
      try
      {
          Comment c = _cs.GetById(id, userId);
          return Ok(c);
      }
      catch (System.Exception e)
      {
          
          return BadRequest(e.Message);
      }
    }
[Authorize]
[HttpPut("{id}")]
public async Task<ActionResult<Comment>> Update([FromBody] Comment comment, int id)
{
  try
  {
      Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
      Comment c = _cs.Update(comment,id, userInfo.Id);
      return Ok(c);
  }
  catch (System.Exception e)
  {
      
      return BadRequest(e.Message);
  }
}

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<Comment>> Delete(int id)
    {
      try
      {
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          _cs.Delete(id, userInfo.Id);
          return Ok("comment has been deleted");
    }
    catch (System.Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
}
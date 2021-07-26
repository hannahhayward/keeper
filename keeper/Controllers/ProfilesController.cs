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
  }
}
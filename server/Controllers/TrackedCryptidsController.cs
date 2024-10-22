namespace cryptid_book.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TrackedCryptidsController : ControllerBase
{
  public TrackedCryptidsController(TrackedCryptidsService trackedCryptidsService, Auth0Provider auth0Provider)
  {
    _trackedCryptidsService = trackedCryptidsService;
    _auth0Provider = auth0Provider;
  }
  private readonly TrackedCryptidsService _trackedCryptidsService;
  private readonly Auth0Provider _auth0Provider;

  [Authorize]
  [HttpPost]
  public async Task<ActionResult<TrackedCryptidProfile>> CreateTrackedCryptid([FromBody] TrackedCryptid trackedCryptidData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      trackedCryptidData.AccountId = userInfo.Id;
      TrackedCryptidProfile trackedCryptidProfile = _trackedCryptidsService.CreateTrackedCryptid(trackedCryptidData);
      return Ok(trackedCryptidProfile);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}

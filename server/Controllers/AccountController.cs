namespace cryptid_book.Controllers;


[Authorize]
[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  public AccountController(AccountService accountService, Auth0Provider auth0Provider, TrackedCryptidsService trackedCryptidsService)
  {
    _accountService = accountService;
    _auth0Provider = auth0Provider;
    _trackedCryptidsService = trackedCryptidsService;
  }
  private readonly AccountService _accountService;
  private readonly TrackedCryptidsService _trackedCryptidsService;
  private readonly Auth0Provider _auth0Provider;


  [HttpGet]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateAccount(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("trackedCryptids")]
  public async Task<ActionResult<List<TrackedCryptidCryptid>>> GetTrackedCryptidCryptidsByAccountId()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<TrackedCryptidCryptid> trackedCryptidCryptids = _trackedCryptidsService.GetTrackedCryptidCryptidsByAccountId(userInfo.Id);
      return Ok(trackedCryptidCryptids);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}

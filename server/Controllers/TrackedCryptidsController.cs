namespace cryptid_book.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TrackedCryptidsController
{
  public TrackedCryptidsController(TrackedCryptidsService trackedCryptidsService, Auth0Provider auth0Provider)
  {
    _trackedCryptidsService = trackedCryptidsService;
    _auth0Provider = auth0Provider;
  }
  private readonly TrackedCryptidsService _trackedCryptidsService;


  private readonly Auth0Provider _auth0Provider;
}

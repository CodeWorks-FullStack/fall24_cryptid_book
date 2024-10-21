namespace cryptid_book.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CryptidsController : ControllerBase
{
  public CryptidsController(CryptidsService cryptidsService, Auth0Provider auth0Provider)
  {
    _cryptidsService = cryptidsService;
    _auth0Provider = auth0Provider;
  }
  private readonly CryptidsService _cryptidsService;
  private readonly Auth0Provider _auth0Provider;

}

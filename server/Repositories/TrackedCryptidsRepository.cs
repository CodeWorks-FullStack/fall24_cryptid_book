


namespace cryptid_book.Repositories;

public class TrackedCryptidsRepository
{
  public TrackedCryptidsRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;

}
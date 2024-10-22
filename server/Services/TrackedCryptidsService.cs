namespace cryptid_book.Services;

public class TrackedCryptidsService
{
  public TrackedCryptidsService(TrackedCryptidsRepository repository)
  {
    _repository = repository;
  }
  private readonly TrackedCryptidsRepository _repository;

}

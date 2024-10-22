
namespace cryptid_book.Services;

public class TrackedCryptidsService
{
  public TrackedCryptidsService(TrackedCryptidsRepository repository)
  {
    _repository = repository;
  }
  private readonly TrackedCryptidsRepository _repository;

  internal TrackedCryptidProfile CreateTrackedCryptid(TrackedCryptid trackedCryptidData)
  {
    TrackedCryptidProfile trackedCryptidProfile = _repository.CreateTrackedCryptid(trackedCryptidData);
    return trackedCryptidProfile;
  }
}

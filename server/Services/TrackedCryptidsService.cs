


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

  internal List<TrackedCryptidProfile> GetAllTrackedCryptidProfilesByCryptidId(int cryptidId)
  {
    List<TrackedCryptidProfile> trackedCryptidProfiles = _repository.GetAllTrackedCryptidProfilesByCryptidId(cryptidId);
    return trackedCryptidProfiles;
  }

  internal List<TrackedCryptidCryptid> GetTrackedCryptidCryptidsByAccountId(string userId)
  {
    List<TrackedCryptidCryptid> trackedCryptidCryptids = _repository.GetTrackedCryptidCryptidsByAccountId(userId);
    return trackedCryptidCryptids;
  }
}

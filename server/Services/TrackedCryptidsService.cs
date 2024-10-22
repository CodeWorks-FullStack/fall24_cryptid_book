



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

  private TrackedCryptid GetTrackedCryptidById(int trackedCryptidId)
  {
    TrackedCryptid trackedCryptid = _repository.GetTrackedCryptidById(trackedCryptidId);
    if (trackedCryptid == null)
    {
      throw new Exception($"Invalid tracked cryptid id: {trackedCryptidId}");
    }
    return trackedCryptid;
  }

  internal void DeleteTrackedCryptid(int trackedCryptidId, string userId)
  {
    TrackedCryptid trackedCryptid = GetTrackedCryptidById(trackedCryptidId);

    if (trackedCryptid.AccountId != userId)
    {
      throw new Exception("NOT YOUR RELATIONSHIP TO MEDDLE WITH, AMIGO");
    }

    _repository.DeleteTrackedCryptid(trackedCryptidId);
  }
}

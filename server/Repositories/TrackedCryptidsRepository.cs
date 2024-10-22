



namespace cryptid_book.Repositories;

public class TrackedCryptidsRepository
{
  public TrackedCryptidsRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;

  internal TrackedCryptidProfile CreateTrackedCryptid(TrackedCryptid trackedCryptidData)
  {
    string sql = @"
    INSERT INTO
    trackedCryptids(accountId, cryptidId)
    VALUES(@AccountId, @CryptidId);

    SELECT
    trackedCryptids.*,
    accounts.*
    FROM trackedCryptids
    JOIN accounts ON accounts.id = trackedCryptids.accountId
    WHERE trackedCryptids.id = LAST_INSERT_ID();";

    TrackedCryptidProfile trackedCryptidProfile = _db.Query<TrackedCryptid, TrackedCryptidProfile, TrackedCryptidProfile>(sql,
    (trackedCryptid, profile) =>
    {
      profile.TrackedCryptidId = trackedCryptid.Id;
      return profile;
    }, trackedCryptidData).FirstOrDefault();
    return trackedCryptidProfile;
  }
}
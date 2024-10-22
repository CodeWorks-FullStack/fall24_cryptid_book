





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

  internal List<TrackedCryptidProfile> GetAllTrackedCryptidProfilesByCryptidId(int cryptidId)
  {
    string sql = @"
    SELECT
    trackedCryptids.*,
    accounts.*
    FROM
    trackedCryptids
    JOIN accounts ON accounts.id = trackedCryptids.accountId
    WHERE
    trackedCryptids.cryptidId = @cryptidId;";

    List<TrackedCryptidProfile> trackedCryptidProfiles = _db.Query<TrackedCryptid, TrackedCryptidProfile, TrackedCryptidProfile>(sql, (trackedCryptid, profile) =>
    {
      profile.TrackedCryptidId = trackedCryptid.Id;
      return profile;
    }, new { cryptidId }).ToList();
    return trackedCryptidProfiles;
  }

  internal List<TrackedCryptidCryptid> GetTrackedCryptidCryptidsByAccountId(string userId)
  {
    string sql = @"
    SELECT
    trackedCryptids.*,
    cryptids.*,
    accounts.*
    FROM
    trackedCryptids
    JOIN cryptids ON cryptids.id = trackedCryptids.cryptidId
    JOIN accounts ON cryptids.`discovererId` = accounts.id
    WHERE trackedCryptids.accountId = @userId;";

    List<TrackedCryptidCryptid> trackedCryptidCryptids = _db.Query<TrackedCryptid, TrackedCryptidCryptid, Profile, TrackedCryptidCryptid>(sql, (trackedCryptid, cryptid, profile) =>
    {
      cryptid.TrackedCryptidId = trackedCryptid.Id;
      cryptid.Discoverer = profile;
      return cryptid;
    }, new { userId }).ToList();

    return trackedCryptidCryptids;
  }
}
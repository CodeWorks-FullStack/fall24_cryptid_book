


namespace cryptid_book.Repositories;

public class CryptidsRepository
{
  public CryptidsRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;

  internal Cryptid CreateCryptid(Cryptid cryptidData)
  {
    string sql = @"
    INSERT INTO
    cryptids(name, threatLevel, size, origin, imgUrl, cryptidCode, discovererId)
    VALUES(@Name, @ThreatLevel, @Size, @Origin, @ImgUrl, @CryptidCode, @DiscovererId);

    SELECT
    cryptids.*,
    accounts.*
    FROM cryptids
    JOIN accounts ON accounts.id = cryptids.discovererId
    WHERE cryptids.id = LAST_INSERT_ID();";

    Cryptid cryptid = _db.Query<Cryptid, Profile, Cryptid>(sql, JoinDiscovererToCryptid, cryptidData).FirstOrDefault();
    return cryptid;
  }

  internal List<Cryptid> GetAllCryptids()
  {
    string sql = @"
    SELECT
    cryptids.*,
    accounts.*
    FROM cryptids
    JOIN accounts ON accounts.id = cryptids.discovererId;";

    List<Cryptid> cryptids = _db.Query<Cryptid, Profile, Cryptid>(sql, JoinDiscovererToCryptid).ToList();
    return cryptids;
  }
  internal Cryptid GetCryptidById(int cryptidId)
  {
    string sql = @"
    SELECT
    cryptids.*,
    accounts.*
    FROM cryptids
    JOIN accounts ON accounts.id = cryptids.discovererId
    WHERE cryptids.id = @cryptidId;";

    Cryptid cryptid = _db.Query<Cryptid, Profile, Cryptid>(sql, JoinDiscovererToCryptid, new { cryptidId }).FirstOrDefault();
    return cryptid;
  }

  private Cryptid JoinDiscovererToCryptid(Cryptid cryptid, Profile profile)
  {
    cryptid.Discoverer = profile;
    return cryptid;
  }

}


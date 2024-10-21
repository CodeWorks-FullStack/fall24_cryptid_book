
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

    SELECT * FROM cryptids WHERE id = LAST_INSERT_ID();";

    Cryptid cryptid = _db.Query<Cryptid>(sql, cryptidData).FirstOrDefault();
    return cryptid;
  }
}


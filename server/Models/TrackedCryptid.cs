namespace cryptid_book.Models;

public class TrackedCryptid : RepoItem<int>
{
  public int CryptidId { get; set; }
  public string AccountId { get; set; }
}

public class TrackedCryptidProfile : Profile
{
  public int TrackedCryptidId { get; set; }
}
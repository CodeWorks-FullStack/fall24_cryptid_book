namespace cryptid_book.Models;

public class TrackedCryptid : RepoItem<int>
{
  public int CryptidId { get; set; }
  public string AccountId { get; set; }
}
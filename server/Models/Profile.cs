namespace cryptid_book.Models;

public class Profile : RepoItem<string>
{
  public string Name { get; set; }
  public string Picture { get; set; }
}
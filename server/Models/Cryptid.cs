using System.ComponentModel.DataAnnotations;

namespace cryptid_book.Models;

public class Cryptid : RepoItem<int>
{
  public string Name { get; set; }
  [Range(0, 10)]
  public int ThreatLevel { get; set; }
  [MaxLength(3000)]
  public string ImgUrl { get; set; }
  public string Origin { get; set; }
  public string Size { get; set; }
  public string CryptidCode { get; set; } = Guid.NewGuid().ToString();
  public string DiscovererId { get; set; }
  public Profile Discoverer { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace cryptid_book.Models;

public class Cryptid
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string Name { get; set; }
  [Range(0, 10)]
  public int ThreatLevel { get; set; }
  [MaxLength(3000)]
  public string ImgUrl { get; set; }
  public string Origin { get; set; }
  public string Size { get; set; }
  public Guid CryptidCode { get; set; } = new Guid();
  public string DiscovererId { get; set; }
}
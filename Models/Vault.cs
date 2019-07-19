namespace Keepr.Models
{
  public class Vault
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string UserId { get; set; }
  }

  public class VaultKeeps
  {
    public int Id { get; set; }
    public string VaultId { get; set; }
    public string KeepId { get; set; }
    public string UserId { get; set; }

  }
}
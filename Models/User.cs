namespace CDNFM.Models;

public class User
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public string? Skillsets { get; set; }
    public string? Hobby { get; set; }
}

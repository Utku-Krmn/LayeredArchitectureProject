namespace LibraryCore;

public class User : BaseEntity
{
    public required string Name { get; set; }
    public required string Surname { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }
    public required string Password { get; set; }


}
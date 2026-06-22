namespace LibraryCore;

public class Author : BaseEntity
{
    public string? PlaceOfBirth { get; set; }
	public string? Name { get; set; }
	public string? Surname { get; set; }
	public int BirthYear { get; set; }
	public string? Biography { get; set; }

	
}


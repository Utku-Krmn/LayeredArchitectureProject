

namespace LibraryCore.DTOs
{
    public class AuthorCreateDto
    {
    public string? PlaceOfBirth { get; set; }
	public string? Name { get; set; }
	public string? Surname { get; set; }
	public int BirthYear { get; set; }
	public string? Biography { get; set; }
     
    }

    public class AuthorQueryDto
    {
    public int Id { get; set; }
    public DateTime RecordTime { get; set; }
    public string? PlaceOfBirth { get; set; }
	public string? Name { get; set; }
	public string? Surname { get; set; }
	public int BirthYear { get; set; }
	public string? Biography { get; set; }
     
    }

    public class AuthorUpdateDto
    {
     public int Id { get; set; }
    public string? PlaceOfBirth { get; set; }
	public string? Name { get; set; }
	public string? Surname { get; set; }
	public int BirthYear { get; set; }
	public string? Biography { get; set; }
     
    }
}
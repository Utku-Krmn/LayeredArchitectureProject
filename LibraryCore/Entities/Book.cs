namespace LibraryCore;

public class Book : BaseEntity
{
    public string? Title { get; set; }
    public int PublicationYear { get; set; }
    public int CategoryId { get; set; }
     public int CountOfPages { get; set; }
     public int AuthorId { get; set; }


}



namespace LibraryDataAccess.DTOs
{
    public class BookCreateDto
    {
       public string? Title { get; set; }
    public int PublicationYear { get; set; }
    public int CategoryId { get; set; }
     public int CountOfPages { get; set; }
     public int AuthorId { get; set; }
    }

    public class BookQueryDto
    {
        public string? Title { get; set; }
        public int PublicationYear { get; set; }
        public int CategoryId { get; set; }
        public int CountOfPages { get; set; }
        public int AuthorId { get; set; }
    }
}
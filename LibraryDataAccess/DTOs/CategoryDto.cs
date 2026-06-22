

namespace LibraryDataAccess.DTOs
{
    public class CategoryCreateDto
    {
        public string? Name { get; set; }
        public string ? Description { get; set; }
    }


    public class CategoryQueryDto
    {
        public int Id { get; set; }
        public DateTime RecordTime { get; set; }
        public string? Name { get; set; }
        public string ? Description { get; set; }
    }
}
namespace MvcOnion.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string BookName { get; set; }

        // Navigation
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
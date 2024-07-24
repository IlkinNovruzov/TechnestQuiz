namespace TechnestQuiz.Models
{
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public BookGenre BookGenre { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }

    public enum BookGenre
    {
        None = 0,
        Horror = 1,
        Fable = 2,
        Fiction = 3,
        Mystery = 4
    }

}

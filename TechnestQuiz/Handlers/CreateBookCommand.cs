using MediatR;
using TechnestQuiz.Models;

namespace TechnestQuiz.Handlers
{
    public class CreateBookCommand : IRequest<long>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public BookGenre BookGenre { get; set; }
    }

    public class CreateBookHandler : IRequestHandler<CreateBookCommand, long>
    {
        private readonly AppDbContext _context;

        public CreateBookHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<long> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Title = request.Title,
                Description = request.Description,
                BookGenre = request.BookGenre,
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync(cancellationToken);

            return book.Id;
        }
    }

}

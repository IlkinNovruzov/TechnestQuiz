using MediatR;
using TechnestQuiz.Models;

namespace TechnestQuiz.Handlers
{
    public class UpdateBookCommand : IRequest
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public BookGenre BookGenre { get; set; }
    }

    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly AppDbContext _context;

        public UpdateBookHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(request.Id);

            if (book == null)
            {
                throw new FileNotFoundException(nameof(Book));
            }

            book.Title = request.Title;
            book.Description = request.Description;
            book.BookGenre = request.BookGenre;
            book.Updated = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        Task IRequestHandler<UpdateBookCommand>.Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}

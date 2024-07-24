using MediatR;
using TechnestQuiz.Models;

namespace TechnestQuiz.Handlers
{
    public class DeleteBookCommand : IRequest
    {
        public long Id { get; set; }
    }

    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly AppDbContext _context;

        public DeleteBookHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(request.Id);

            if (book == null)
            {
                throw new FileNotFoundException(nameof(Book));
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        Task IRequestHandler<DeleteBookCommand>.Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}

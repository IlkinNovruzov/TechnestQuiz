using MediatR;
using TechnestQuiz.Models;

namespace TechnestQuiz.Handlers
{
    public class GetBookQuery : IRequest<Book>
    {
        public long Id { get; set; }
    }

    public class GetBookHandler : IRequestHandler<GetBookQuery, Book>
    {
        private readonly AppDbContext _context;

        public GetBookHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Book> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(request.Id);

            if (book == null)
            {
                throw new FileNotFoundException(nameof(Book));
            }

            return book;
        }
    }

}

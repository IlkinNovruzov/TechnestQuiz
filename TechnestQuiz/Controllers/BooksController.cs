using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnestQuiz.Handlers;
using TechnestQuiz.Models;

namespace TechnestQuiz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateBookCommand command)
        {
            var bookId = await _mediator.Send(command);
            return Ok(bookId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, UpdateBookCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _mediator.Send(new DeleteBookCommand { Id = id });
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(long id)
        {
            var book = await _mediator.Send(new GetBookQuery { Id = id });
            return Ok(book);
        }
    }

}

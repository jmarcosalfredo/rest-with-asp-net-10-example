using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rest_with_asp_net_10_example.Data.DTO;
using rest_with_asp_net_10_example.Model;
using rest_with_asp_net_10_example.Services;

namespace rest_with_asp_net_10_example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookServices _BookServices;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookServices BookServices, ILogger<BookController> logger)
        {
            _BookServices = BookServices;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Getting all Books");
            return Ok(_BookServices.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Getting Book by ID: {Id}", id);
            var Book = _BookServices.FindById(id);
            if (Book == null)
            {
                _logger.LogWarning("Book with ID: {Id} was not found", id);
                return NotFound();
            }
            return Ok(Book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] BookDTO book)
        {
            _logger.LogInformation("Creating new Book {firstName}", book.Title);
            var createdBook = _BookServices.Create(book);
            if (createdBook == null)
            {
                _logger.LogError("Failed to create Book {firstName}", book.Title);
                return BadRequest("Algo deu errado!");
            }
            return Ok(createdBook);
        }

        [HttpPut]
        public IActionResult Put([FromBody] BookDTO book)
        {
            _logger.LogInformation("Updating Book by ID: {Id}", book.Id);
            var updatedBook = _BookServices.Update(book);
            if (updatedBook == null)
            {
                _logger.LogError("Failed to update Book by ID: {Id}", book.Id);
                return BadRequest("Algo deu errado!");
            }
            _logger.LogDebug("Book updated successfully: {firstName}", book.Title);
            return Ok(updatedBook);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Deleting Book by ID: {Id}", id);
            _BookServices.Delete(id);
            _logger.LogDebug("Book deleted successfully: {Id}", id);
            return NoContent();
        }
    }
}

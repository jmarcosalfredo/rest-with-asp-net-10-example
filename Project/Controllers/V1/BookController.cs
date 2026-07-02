using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rest_with_asp_net_10_example.Data.DTO.V1;
using rest_with_asp_net_10_example.Services;

namespace rest_with_asp_net_10_example.Controllers.V1
{
    [Route("api/[controller]/v1")]
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
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(200, Type = typeof(List<BookDTO>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            _logger.LogInformation("Getting all Books");
            return Ok(_BookServices.FindAll());
        }

        [HttpGet("{id}")]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(200, Type = typeof(BookDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
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
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(200, Type = typeof(BookDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
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
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(200, Type = typeof(BookDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] BookDTO book)
        {
            _logger.LogInformation("Updating Book by ID: {Id}", book.Id);
            var updatedBook = _BookServices.Update(book);
            if (updatedBook == null)
            {
                _logger.LogError("Failed to update Book by ID: {Id}", book.Id);
                return BadRequest("Algo deu errado!");
            }
            Response.Headers.Append("X-API-Deprecated", "This endpoint is deprecated. Please use the new version of the API.");
            Response.Headers.Append("X-API-Deprecation-Date", "2026-12-01");
            _logger.LogDebug("Book updated successfully: {firstName}", book.Title);
            return Ok(updatedBook);
        }

        [HttpDelete("{id}")]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(204, Type = typeof(BookDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Deleting Book by ID: {Id}", id);
            _BookServices.Delete(id);
            _logger.LogDebug("Book deleted successfully: {Id}", id);
            return NoContent();
        }
    }
}

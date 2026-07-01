using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rest_with_asp_net_10_example.Data.DTO.V1;
using rest_with_asp_net_10_example.Model;
using rest_with_asp_net_10_example.Services;


namespace rest_with_asp_net_10_example.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]/v1")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonServices _personServices;
        private readonly ILogger<PersonController> _logger;

        public PersonController(IPersonServices personServices, ILogger<PersonController> logger)
        {
            _personServices = personServices;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Getting all persons");
            Response.Headers.Append("X-API-Deprecated", "This endpoint is deprecated. Please use the new version of the API.");
            Response.Headers.Append("X-API-Deprecation-Date", "2026-12-01");
            return Ok(_personServices.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Getting person by ID: {Id}", id);
            var person = _personServices.FindById(id);
            if (person == null)
            {
                _logger.LogWarning("Person with ID: {Id} was not found", id);
                return NotFound();
            }
            Response.Headers.Append("X-API-Deprecated", "This endpoint is deprecated. Please use the new version of the API.");
            Response.Headers.Append("X-API-Deprecation-Date", "2026-12-01");
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PersonDTO person)
        {
            _logger.LogInformation("Creating new person {firstName}", person.FirstName);
            var createdPerson = _personServices.Create(person);
            if (createdPerson == null)
            {
                _logger.LogError("Failed to create person {firstName}", person.FirstName);
                return BadRequest("Algo deu errado!");
            }
            Response.Headers.Append("X-API-Deprecated", "This endpoint is deprecated. Please use the new version of the API.");
            Response.Headers.Append("X-API-Deprecation-Date", "2026-12-01");
            return Ok(createdPerson);
        }

        [HttpPut]
        public IActionResult Put([FromBody] PersonDTO person)
        {
            _logger.LogInformation("Updating person by ID: {Id}", person.Id);
            var updatedPerson = _personServices.Update(person);
            if (updatedPerson == null)
            {
                _logger.LogError("Failed to update person by ID: {Id}", person.Id);
                return BadRequest("Algo deu errado!");
            }
            Response.Headers.Append("X-API-Deprecated", "This endpoint is deprecated. Please use the new version of the API.");
            Response.Headers.Append("X-API-Deprecation-Date", "2026-12-01");
            _logger.LogDebug("Person updated successfully: {firstName}", person.FirstName);
            return Ok(updatedPerson);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Deleting person by ID: {Id}", id);
            _personServices.Delete(id);
            _logger.LogDebug("Person deleted successfully: {Id}", id);
            return NoContent();
        }
    }
}

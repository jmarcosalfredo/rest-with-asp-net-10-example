using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rest_with_asp_net_10_example.Data.DTO.V2;
using rest_with_asp_net_10_example.Model;
using rest_with_asp_net_10_example.Services;


namespace rest_with_asp_net_10_example.Controllers.V2
{
    [ApiController]
    [Route("api/[controller]/v2")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonServicesV2 _personServices;
        private readonly ILogger<PersonController> _logger;

        public PersonController(IPersonServicesV2 personServices, ILogger<PersonController> logger)
        {
            _personServices = personServices;
            _logger = logger;
        }

        [HttpPost]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(200, Type = typeof(PersonDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] PersonDTO person)
        {
            _logger.LogInformation("Creating new person {firstName}", person.FirstName);
            var createdPerson = _personServices.Create(person);
            if (createdPerson == null)
            {
                _logger.LogError("Failed to create person {firstName}", person.FirstName);
                return BadRequest("Algo deu errado!");
            }
            return Ok(createdPerson);
        }

        [HttpPut]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(200, Type = typeof(PersonDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] PersonDTO person)
        {
            _logger.LogInformation("Updating person by ID: {Id}", person.Id);
            var updatedPerson = _personServices.Update(person);
            if (updatedPerson == null)
            {
                _logger.LogError("Failed to update person by ID: {Id}", person.Id);
                return BadRequest("Algo deu errado!");
            }
            _logger.LogDebug("Person updated successfully: {firstName}", person.FirstName);
            return Ok(updatedPerson);
        }
    }
}

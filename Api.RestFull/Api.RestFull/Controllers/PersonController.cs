using Api.RestFull.Model;
using Api.RestFull.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.RestFull.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PersonController : ControllerBase
    {
        private IPersonServices _personService;

        public PersonController(IPersonServices services)
        {
            _personService = services;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = _personService.FindById(id);
            if(person is null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person is null)
            {
                return BadRequest();
            }
            return new ObjectResult(_personService.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person is null)
            {
                return BadRequest();
            }
            return new ObjectResult(_personService.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_personService.Delete(id))
                return Ok(string.Format("Pessoa com o id {0}, foi deletada do banco de dados", id));
            return NoContent();
        }
    }
}
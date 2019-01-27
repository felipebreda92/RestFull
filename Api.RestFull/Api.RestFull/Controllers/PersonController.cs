using Api.RestFull.Model;
using Api.RestFull.Business;
using Microsoft.AspNetCore.Mvc;

namespace Api.RestFull.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PersonController : ControllerBase
    {
        private IPersonBusiness _personBusiness;

        public PersonController(IPersonBusiness services)
        {
            _personBusiness = services;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = _personBusiness.FindById(id);
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
            return new ObjectResult(_personBusiness.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person is null)
                return BadRequest();

            var updatedPerson = _personBusiness.Update(person);

            if (!(updatedPerson is null))
                return NoContent();

            return new OkObjectResult(person);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_personBusiness.Delete(id))
                return Ok(string.Format("Pessoa com o id {0}, foi deletada do banco de dados", id));
            return NoContent();
        }
    }
}
using Api.RestFull.Business;
using Microsoft.AspNetCore.Mvc;
using Api.RestFull.Data.Converter;
using Tapioca.HATEOAS;
using Microsoft.AspNetCore.Authorization;

namespace Api.RestFull.Controllers
{

    [Authorize("Bearer")]
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

        /// <summary>
        /// Metodo Get - Obtém todos os registros do banco de dados.
        /// </summary>
        /// <returns>List<Person></returns>
        
        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        /// <summary>
        /// Metodo Get - Obtém um único registro no banco de dados baseado no id informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(int id)
        {
            var person = _personBusiness.FindById(id);
            if(person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        /// <summary>
        /// Metodo Post - Insere os Registros no bando dados.
        /// </summary>
        /// <param name="Book"></param>
        /// <returns>Objeto inserido</returns>
        
        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] PersonVO person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            return new ObjectResult(_personBusiness.Create(person));
        }

        /// <summary>
        /// Metodo Put - Altera os registros no banco de dados de acordo com os dados informados.
        /// </summary>
        /// <param name="Book"></param>
        /// <returns>Objeto alterado</returns>
        
        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] PersonVO person)
        {
            if (person == null)
                return BadRequest();

            var updatedPerson = _personBusiness.Update(person);

            if (updatedPerson == null)
                return NoContent();

            return new OkObjectResult(person);
        }

        /// <summary>
        /// Metodo Delete - Deleta o registro do banco de dados de acordo com o id informado.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status de resposta</returns>
        
        [HttpDelete("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(int id)
        {
            if (_personBusiness.Delete(id))
                return Ok(string.Format("Pessoa com o id {0}, foi deletada do banco de dados", id));
            return NoContent();
        }
    }
}
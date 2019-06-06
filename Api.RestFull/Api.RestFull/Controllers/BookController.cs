using Api.RestFull.Business;
using Api.RestFull.Data.VO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tapioca.HATEOAS;

namespace Api.RestFull.Controllers
{
    [Authorize("Bearer")]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookBusiness _bookBusiness;

        public BookController(IBookBusiness bookBusiness)
        {
            _bookBusiness = bookBusiness;
        }

        /// <summary>
        /// Metodo Get - Obtém todos os registros do banco de dados.
        /// </summary>
        /// <returns>List<Book></returns>
        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());

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
            var Book = _bookBusiness.FindById(id);
            if (Book == null)
            {
                return NotFound();
            }

            return Ok(Book);
        }

        /// <summary>
        /// Metodo Post - Insere os Registros no bando dados.
        /// </summary>
        /// <param name="Book"></param>
        /// <returns>Objeto inserido</returns>
        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] BookVO Book)
        {
            if (Book == null)
            {
                return BadRequest();
            }
            return new ObjectResult(_bookBusiness.Create(Book));
        }

        /// <summary>
        /// Metodo Put - Altera os registros no banco de dados de acordo com os dados informados.
        /// </summary>
        /// <param name="Book"></param>
        /// <returns>Objeto alterado</returns>
        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] BookVO Book)
        {
            if (Book == null)
                return BadRequest();

            var updatedBook = _bookBusiness.Update(Book);

            if (updatedBook == null)
                return NoContent();

            return new OkObjectResult(Book);
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
            if (_bookBusiness.Delete(id))
                return Ok(string.Format("Pessoa com o id {0}, foi deletada do banco de dados", id));
            return NoContent();
        }
    }
}
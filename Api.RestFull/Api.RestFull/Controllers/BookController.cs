using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.RestFull.Business;
using Api.RestFull.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.RestFull.Controllers
{
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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Book = _bookBusiness.FindById(id);
            if (Book is null)
            {
                return NotFound();
            }

            return Ok(Book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book Book)
        {
            if (Book is null)
            {
                return BadRequest();
            }
            return new ObjectResult(_bookBusiness.Create(Book));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Book Book)
        {
            if (Book is null)
                return BadRequest();

            var updatedBook = _bookBusiness.Update(Book);

            if (!(updatedBook is null))
                return NoContent();

            return new OkObjectResult(Book);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_bookBusiness.Delete(id))
                return Ok(string.Format("Pessoa com o id {0}, foi deletada do banco de dados", id));
            return NoContent();
        }
    }
}
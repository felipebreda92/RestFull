using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.RestFull.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.RestFull.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        //private IBookBisness _bookBusiness;

        //public BookController(IBookBisness bookBusiness)
        //{
        //    _bookBusiness = bookBusiness;
        //}

        [HttpGet]
        public IActionResult Get()
        {
            //return Ok(_bookBusiness.FindAll());
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //var Book = _bookBusiness.FindById(id);
            //if (Book is null)
            //{
            //    return NotFound();
            //}

            //return Ok(Book);

            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book Book)
        {
            //if (Book is null)
            //{
            //    return BadRequest();
            //}
            //return new ObjectResult(_bookBusiness.Create(Book));

            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] Book Book)
        {
            //if (Book is null)
            //    return BadRequest();

            //var updatedBook = _bookBusiness.Update(Book);

            //if (!(updatedBook is null))
            //    return NoContent();

            //return new OkObjectResult(Book);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //if (_bookBusiness.Delete(id))
            //    return Ok(string.Format("Pessoa com o id {0}, foi deletada do banco de dados", id));
            //return NoContent();
            return Ok();
        }
    }
}
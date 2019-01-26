using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.RestFull.Model;
using Api.RestFull.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.RestFull.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpGet]
        public IActionResult Get(long id)
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
    }
}
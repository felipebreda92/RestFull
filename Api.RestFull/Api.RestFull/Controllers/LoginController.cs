using Api.RestFull.Business;
using Api.RestFull.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.RestFull.Controllers
{

    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class LoginController : ControllerBase
    {
        private ILoginBusiness _loginBusiness;

        public LoginController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        /// <summary>
        /// Metodo Post - Insere os Registros no bando dados.
        /// </summary>
        /// <param name="Book"></param>
        /// <returns>Objeto inserido</returns>
        
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            return _loginBusiness.FindByLogin(user);
        }
    }
}
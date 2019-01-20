using Api.RestFull.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace Api.RestFull.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if(NumberUtils.IsNumeric(firstNumber) && NumberUtils.IsNumeric(secondNumber))
            {
                var sum = NumberUtils.ConvertToDecimal(firstNumber) + NumberUtils.ConvertToDecimal(secondNumber);

                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Imput");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (NumberUtils.IsNumeric(firstNumber) && NumberUtils.IsNumeric(secondNumber))
            {
                var test = NumberUtils.ConvertToDecimal(secondNumber);
                var sum = NumberUtils.ConvertToDecimal(firstNumber) * NumberUtils.ConvertToDecimal(secondNumber);

                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Imput");
        }
    }
}
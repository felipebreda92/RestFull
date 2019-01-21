using Api.RestFull.Utils;
using Microsoft.AspNetCore.Mvc;
using System;


namespace Api.RestFull.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (NumberUtils.IsNumeric(firstNumber) && NumberUtils.IsNumeric(secondNumber))
            {
                var sum = NumberUtils.ConvertToDecimal(firstNumber) + NumberUtils.ConvertToDecimal(secondNumber);

                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Imput");
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (NumberUtils.IsNumeric(firstNumber) && NumberUtils.IsNumeric(secondNumber))
            {
                var substraction = NumberUtils.ConvertToDecimal(firstNumber) + NumberUtils.ConvertToDecimal(secondNumber);

                return Ok(substraction.ToString());
            }

            return BadRequest("Invalid Imput");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (NumberUtils.IsNumeric(firstNumber) && NumberUtils.IsNumeric(secondNumber))
            {
                var multiplication = NumberUtils.ConvertToDecimal(firstNumber) * NumberUtils.ConvertToDecimal(secondNumber);

                return Ok(multiplication.ToString());
            }

            return BadRequest("Invalid Imput");
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (NumberUtils.IsNumeric(firstNumber) && NumberUtils.IsNumeric(secondNumber))
            {
                var division = NumberUtils.ConvertToDecimal(firstNumber) / NumberUtils.ConvertToDecimal(secondNumber);

                return Ok(division.ToString());
            }

            return BadRequest("Invalid Imput");
        }

        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (NumberUtils.IsNumeric(firstNumber) && NumberUtils.IsNumeric(secondNumber))
            {
                var mean = (NumberUtils.ConvertToDecimal(firstNumber) + NumberUtils.ConvertToDecimal(secondNumber)) / 2;

                return Ok(mean.ToString());
            }

            return BadRequest("Invalid Imput");
        }

        [HttpGet("square-root/{number}")]
        public IActionResult SquareRoot(string number)
        {
            if (NumberUtils.IsNumeric(number))
            {
                var sqr = Math.Sqrt((double)NumberUtils.ConvertToDecimal(number));

                return Ok(sqr.ToString());
            }

            return BadRequest("Invalid Imput");
        }
    }
}
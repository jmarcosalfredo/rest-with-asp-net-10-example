using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace rest_with_asp_net_10_example.Controllers
{
    //[Route("[controller]")]
    //[ApiController]
    public class MathControllerV1 : ControllerBase
    {
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult GetSum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum);
            }
            return BadRequest("Insira somente numeros para obter o resultado da soma.");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult GetSub(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sub);
            }
            return BadRequest("Insira somente numeros para obter o resultado da subtracao.");
        }

        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult GetMult(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(mult);
            }
            return BadRequest("Insira somente numeros para obter o resultado da subtracao.");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult GetDiv(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(div);
            }
            return BadRequest("Insira somente numeros para obter o resultado da divisao.");
        }

        [HttpGet("med/{firstNumber}/{secondNumber}")]
        public IActionResult GetMed(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                var med = sum / 2;
                return Ok(med);
            }
            return BadRequest("Insira somente numeros para obter o resultado da media.");
        }

        [HttpGet("sqrt/{firstNumber}")]
        public IActionResult GetSqrt(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var sqrt = Math.Sqrt((double)ConvertToDecimal(firstNumber));
                return Ok(sqrt);
            }
            return BadRequest("Insira somente numeros para obter o resultado da media.");
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalvalue;

            if (decimal.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out decimalvalue)
            )
            {
                return decimalvalue;
            }
            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            decimal decimalvalue;
            bool isNumber = decimal.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out decimalvalue
            );

            return isNumber;
        }
    }
}

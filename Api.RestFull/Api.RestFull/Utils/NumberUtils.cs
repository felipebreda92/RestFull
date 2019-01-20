using System.Globalization;

namespace Api.RestFull.Utils
{
    public static class NumberUtils
    {

        public static bool IsNumeric(string valor) => double.TryParse(valor, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out double val);

        public static decimal ConvertToDecimal(string valor) => decimal.Parse(valor, NumberStyles.Any, NumberFormatInfo.InvariantInfo);
    }
}

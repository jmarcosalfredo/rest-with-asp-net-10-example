namespace rest_with_asp_net_10_example.Utils;

public class NumberHelper
{
    public static decimal ConvertToDecimal(string strNumber)
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

        public static bool IsNumeric(string strNumber)
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

namespace rest_with_asp_net_10_example.Services;

public class MathService
{
    public decimal Sum(decimal firstNumber, decimal secondNumber)
    {
        return firstNumber + secondNumber;
    }

    public decimal Sub(decimal firstNumber, decimal secondNumber)
    {
        return firstNumber - secondNumber;
    }

    public decimal Mult(decimal firstNumber, decimal secondNumber)
    {
        return firstNumber * secondNumber;
    }

    public decimal Div(decimal firstNumber, decimal secondNumber)
    {
        if (secondNumber == 0)
        {
            throw new DivideByZeroException("Divisão por zero não é permitida.");
        }

        return firstNumber / secondNumber;
    }

    public decimal Med(decimal firstNumber, decimal secondNumber)
    {
        var sum = firstNumber + secondNumber;
        var med = sum / 2;
        return med;
    }

    public decimal Sqrt(decimal number)
    {
        if (number < 0)
        {
            throw new ArgumentException("Não é possível calcular a raiz quadrada de um número negativo.");
        }

        return (decimal)Math.Sqrt((double)number);
    }
}

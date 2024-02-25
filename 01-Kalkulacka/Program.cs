using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Kalkulacka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadejte výraz (např. 33+25):");
            string input = Console.ReadLine();

            try
            {
                double result = EvaluateSimpleExpression(input);
                Console.WriteLine($"Výsledek je: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Došlo k chybě: {ex.Message}");
            }

            Console.WriteLine("Stiskněte libovolnou klávesu pro ukončení...");
            Console.ReadKey();
        }

        static double EvaluateSimpleExpression(string expression)
        {
            expression = expression.Replace(" ", string.Empty);

            int operatorIndex = -1;
            char[] operators = { '+', '-', '*', '/' };
            foreach (var op in operators)
            {
                operatorIndex = expression.IndexOf(op);
                if (operatorIndex > 0)
                {
                    break;
                }
            }

            if (operatorIndex == -1)
            {
                throw new ArgumentException("Neplatný výraz.");
            }

            char operatorChar = expression[operatorIndex];
            double num1 = Convert.ToDouble(expression.Substring(0, operatorIndex));
            double num2 = Convert.ToDouble(expression.Substring(operatorIndex + 1));

            switch (operatorChar)
            {
                case '+':
                    return num1 + num2;
                case '-':
                    return num1 - num2;
                case '*':
                    return num1 * num2;
                case '/':
                    if (num2 == 0)
                    {
                        throw new DivideByZeroException("Dělení nulou.");
                    }
                    return num1 / num2;
                default:
                    throw new ArgumentException("Neznámý operátor.");
            }
        }
    }
}

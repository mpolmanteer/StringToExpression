using System;

namespace StringToExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString;
            Console.WriteLine("Enter Expression!");
            inputString = Console.ReadLine();

            StringToExpressionConverter expressionParser = new StringToExpressionConverter();

            Console.WriteLine($"Your value {expressionParser.GetValue(inputString)}");
        }
    }
}

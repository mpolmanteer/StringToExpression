using System;
using System.Collections.Generic;
using System.Text;

namespace StringToExpression
{
    class StringToExpressionConverter
    {
        private Dictionary<string, Func<double,double,double>> Operators { get; set; }
        private ExpressionParser ExpressionParser { get; set; }
        public StringToExpressionConverter()
        {
            Operators = new Dictionary<string, Func<double, double, double>>
            {
                ["+"] = (a, b) => a + b,
                ["-"] = (a, b) => a - b,
                ["*"] = (a, b) => a * b,
                ["/"] = (a, b) => a / b
            };
        }

        public double GetValue(string expression) 
        {
            Stack<string> fullStack = new Stack<string>();

            string numberOne = "";
            string numberTwo = "";
            string popValue = "";
            double opValue = 0;

            foreach (char c in expression)
            {
                if (c == ')')
                {
                    if (numberOne != "")
                    {
                        numberTwo = numberOne;
                    }
                    else
                    {
                        numberTwo = fullStack.Pop();
                    }
                    

                    popValue = fullStack.Pop();


                    if (Operators.ContainsKey(popValue))
                    {
                        numberOne = fullStack.Pop();
                        opValue = Operators[popValue](Convert.ToDouble(numberOne), Convert.ToDouble(numberTwo));
                        fullStack.Pop();
                        fullStack.Push(opValue.ToString());
                    }
                    else if (popValue == "(")
                    {
                        fullStack.Push(numberOne);
                    }
                    else
                    {
                        fullStack.Pop();
                        fullStack.Push(numberOne);
                    }

                    numberOne = "";
                }
                else if (c == '(')
                {
                    fullStack.Push(c.ToString());
                }
                else if (Operators.ContainsKey(c.ToString()))
                {
                    if(numberOne != "") 
                    {
                        fullStack.Push(numberOne);
                        numberOne = "";
                    }

                    fullStack.Push(c.ToString());                 
                }
                else 
                {
                    numberOne += c.ToString();
                }
            }
          
            return Convert.ToDouble(fullStack.Pop());
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostfixMathExpressions
{
    class PostfixMain
    {
        static void Main(string[] args)
        {
            string input = "";

            input = GetExpression();
            while (!String.Equals(input, "q"))
            {
                try
                {
                    
                    Console.Out.Write("Result: ");
                    Console.Out.WriteLine(processExpression(input));
                    input = GetExpression();
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine(e.StackTrace);
                    break;
                }
            }

            Console.Out.WriteLine("======End of Processing======");
        }

        private static string GetExpression()
        {
            string toReturn = null;
            Console.Out.Write("Enter a postfix expression(enter 'q' to quit): ");
            toReturn = Console.In.ReadLine();
            return toReturn;
        }

        private static double processExpression(string expression)
        {
            Stack expressionStack = new Stack();
            string expPart1 = null;
            string expPart2 = null;
            string[] parts = expression.Split(' ');

            for (int i = 0; i < parts.Length; i++)
            {
                try
                {
                    Convert.ToDouble(parts[i]);
                    expressionStack.push(parts[i]);
                }catch(Exception e){
                    if (String.Equals(parts[i], "+"))
                    {
                        //Plus operation found, get the two top elements in stack an evaluate operation
                        if (expressionStack.top() != null)
                        {
                            expPart1 = expressionStack.pop();
                        }
                        else
                        {
                            throw new Exception("Not enough values to evaluate + operations (at " + i.ToString() + ")");
                        }
                        if (expressionStack.top() != null)
                        {
                            expPart2 = expressionStack.pop();
                        }
                        else
                        {
                            throw new Exception("Not enough values to evaluate + operations (at " + i.ToString() + ")");
                        }
                        expressionStack.push(operationPlus(expPart1, expPart2));
                    }
                    else if(String.Equals(parts[i], "-"))
                    {
                        //Minus operation found, get the two top elements in stack an evaluate opeartion
                        if (expressionStack.top() != null)
                        {
                            expPart1 = expressionStack.pop();
                        }
                        else
                        {
                            throw new Exception("Not enough values to evaluate - operations (at " + i.ToString() + ")");
                        }
                        if (expressionStack.top() != null)
                        {
                            expPart2 = expressionStack.pop();
                        }
                        else
                        {
                            throw new Exception("Not enough values to evaluate - operations (at " + i.ToString() + ")");
                        }
                        expressionStack.push(operationMinus(expPart1, expPart2));
                    }
                    else if (String.Equals(parts[i], "*"))
                    {
                        //Multiplication operation found, get the two top elements in stack an evaluate opeartion
                        if (expressionStack.top() != null)
                        {
                            expPart1 = expressionStack.pop();
                        }
                        else
                        {
                            throw new Exception("Not enough values to evaluate * operations (at " + i.ToString() + ")");
                        }
                        if (expressionStack.top() != null)
                        {
                            expPart2 = expressionStack.pop();
                        }
                        else
                        {
                            throw new Exception("Not enough values to evaluate * operations (at " + i.ToString() + ")");
                        }
                        expressionStack.push(operationMultiply(expPart1, expPart2));
                    }
                    else if (String.Equals(parts[i], "/"))
                    {
                        //Multiplication operation found, get the two top elements in stack an evaluate opeartion
                        if (expressionStack.top() != null)
                        {
                            expPart1 = expressionStack.pop();
                        }
                        else
                        {
                            throw new Exception("Not enough values to evaluate / operations (at " + i.ToString() + ")");
                        }
                        if (expressionStack.top() != null)
                        {
                            expPart2 = expressionStack.pop();
                        }
                        else
                        {
                            throw new Exception("Not enough values to evaluate / operations (at " + i.ToString() + ")");
                        }
                        expressionStack.push(operationDivide(expPart1, expPart2));
                    }
                    else
                    {
                        throw new Exception("Invalid operation or symbol");
                    }
                }
            }

            return Convert.ToDouble(expressionStack.pop());
        }

        private static string operationPlus(string part1, string part2)
        {
            double exprPart1 = Convert.ToDouble(part1);
            double exprPart2 = Convert.ToDouble(part2);
            double sum = exprPart2 + exprPart1;

            return sum.ToString();
        }

        private static string operationMinus(string part1, string part2)
        {
            double exprPart1 = Convert.ToDouble(part1);
            double exprPart2 = Convert.ToDouble(part2);
            double sum = exprPart2 - exprPart1;

            return sum.ToString();
        }

        private static string operationMultiply(string part1, string part2)
        {
            double exprPart1 = Convert.ToDouble(part1);
            double exprPart2 = Convert.ToDouble(part2);
            double sum = exprPart2 * exprPart1;

            return sum.ToString();
        }

        private static string operationDivide(string part1, string part2)
        {
            double exprPart1 = Convert.ToDouble(part1);
            double exprPart2 = Convert.ToDouble(part2);
            double sum = exprPart2 / exprPart1;

            return sum.ToString();
        }
    }

}

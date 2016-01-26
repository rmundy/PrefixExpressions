using System.Globalization;
using System.Linq.Expressions;

namespace PrefixExpression
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public sealed class Program
    {
        public static void Main(String[] args)
        {
            using (var reader = File.OpenText(args[0]))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (null == line)
                    {
                    }
                    else
                    {
                        var split = line.Split(new[]{' '}, StringSplitOptions.RemoveEmptyEntries);
                        var stack = new Stack<String>();
                        var operators = new List<String>{"+", "*", "/", "-"};
                        for (var i = split.Length-1; i >= 0; i--)
                        {
                            if(operators.Contains(split[i]))
                            {
                                var num1 = Convert.ToDouble(stack.Pop());
                                var num2 = Convert.ToDouble(stack.Pop());
                                if (split[i].Equals("*"))
                                {
                                    var result = num1 * num2;
                                    stack.Push(result.ToString(CultureInfo.InvariantCulture));
                                }
                                else if (split[i].Equals("/"))
                                {
                                    var result = num1 / num2;
                                    stack.Push(result.ToString(CultureInfo.InvariantCulture));
                                }
                                else if (split[i].Equals("+"))
                                {
                                    var result = num1 + num2;
                                    stack.Push(result.ToString(CultureInfo.InvariantCulture));
                                }
                                else if (split[i].Equals("-"))
                                {
                                    var result = num1 - num2;
                                    stack.Push(result.ToString(CultureInfo.InvariantCulture));
                                }
                            }
                            else
                            {
                                // Must be an operand
                                stack.Push(split[i]);
                            }
                        }

                        Console.WriteLine("{0}",stack.Pop());
                    }
                }
            }
        }
    }
}

namespace PrefixExpression
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public sealed class Program
    {
        public static void Main(string[] args)
        {
            using (var reader = File.OpenText(args[0]))
            {
                while (!reader.EndOfStream)
                {
                    String line = reader.ReadLine();
                    if (null == line)
                    {
                        continue;
                    }
                    else
                    {
                        var split = line.Split(' ');
                        var stack = new Stack<String>();
                        var operators = new List<String>{"+", "*", "/"};
                        for (int i = split.Length-1; i >= 0; i--)
                        {
                            if(operators.Contains(split[i]))
                            {
                                if(stack.Count() >= 2)
                                {
                                    var num1 = Convert.ToInt32(stack.Pop());
                                    var num2 = Convert.ToInt32(stack.Pop());
                                    if (split[i].Equals("*"))
                                    {
                                        var result = num1 * num2;
                                        stack.Push(result.ToString());
                                    }
                                    else if (split[i].Equals("/"))
                                    {
                                        var result = num1 / num2;
                                        stack.Push(result.ToString());
                                    }
                                    else if (split[i].Equals("+"))
                                    {
                                        var result = num1 + num2;
                                        stack.Push(result.ToString());
                                    }
                                }
                            }
                            else
                            {
                                // Must be an operand
                                stack.Push(split[i]);
                            }
                        }

                        Console.WriteLine(stack.Pop());
                    }
                }
            }
        }
    }
}

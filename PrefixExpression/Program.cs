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

                    }
                }
            }
        }
    }
}

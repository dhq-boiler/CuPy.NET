using System;
using Torch.ApiGenerator;

namespace CodeMinion.ApiGenerator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ICodeGenerator generator = new Cupy.ApiGenerator();
            var result = generator.Generate();

            Console.WriteLine(result);
            //Console.ReadKey();
        }
    }
}
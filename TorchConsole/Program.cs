using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorchSharp;

namespace TorchConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(torch.rand(new long[] { 2, 3 }).ToString());
        }
    }
}

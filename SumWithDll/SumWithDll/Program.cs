using System;
using System.Runtime.InteropServices;

namespace SumWithDll
{
    internal class Program
    {
        [DllImport("AddDll.dll")]
        public static extern int AddNumber(int lhs, int rhs);
        static void Main(string[] args)
        {
            var answer = AddNumber(100, 12);
            Console.WriteLine($"Return value from  => {answer}" );
        }
    }
}

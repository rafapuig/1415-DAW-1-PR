using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace InterfacesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerator e = new CountDown();

            while (e.MoveNext())
                Console.WriteLine(e.Current);

            Console.ReadKey();
        }
    }
}

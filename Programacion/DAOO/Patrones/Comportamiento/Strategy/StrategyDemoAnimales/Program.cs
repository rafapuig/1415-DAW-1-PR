using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemoAnimales
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal aBird = new Bird();
            Animal anElephant = new Elephant();

            aBird.PerformFly();
            anElephant.PerformFly();

            Animal dumbo = new Elephant();
            dumbo.SetStrategy(new Flying());
            dumbo.PerformFly();

            Console.ReadKey();
        }
    }
}

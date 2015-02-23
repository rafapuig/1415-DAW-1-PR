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
            dumbo.PerformFly();
            dumbo.SetFlyingStrategy(new ItFlys());
            dumbo.PerformFly();

            Console.ReadKey();
        }
    }
}

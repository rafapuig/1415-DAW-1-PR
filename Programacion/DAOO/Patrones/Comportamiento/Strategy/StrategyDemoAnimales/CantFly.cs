using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemoAnimales
{
    class CantFly : IFlyStrategy
    {
        public void Fly()
        {
            Console.WriteLine("No puedo volar");
        }
    }
}

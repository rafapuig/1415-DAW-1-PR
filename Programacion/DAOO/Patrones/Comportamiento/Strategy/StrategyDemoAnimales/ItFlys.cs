using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemoAnimales
{
    class ItFlys : IFlyingStrategy
    {
        public void Fly()
        {
            Console.WriteLine("Estoy volando.");
        }
    }
}

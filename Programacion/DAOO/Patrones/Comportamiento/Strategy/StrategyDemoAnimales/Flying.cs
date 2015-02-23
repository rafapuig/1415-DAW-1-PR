using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemoAnimales
{
    class Flying : IFlyStrategy
    {
        public void Fly()
        {
            Console.WriteLine("Estoy volando.");
        }
    }
}

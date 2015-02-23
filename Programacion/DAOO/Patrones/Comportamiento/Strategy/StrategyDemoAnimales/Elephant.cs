using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemoAnimales
{
    class Elephant : Animal
    {
        public Elephant()
        {
            SetFlyingStrategy(new CantFly());
        }

        // Y remplazarlo en las clases que no deben adquirir el nuevo comportamiento definido en la base
        public override void Fly()
        {
            Console.WriteLine("No puedo volar");
        }
    }
}

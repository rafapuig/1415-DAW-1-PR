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
            SetStrategy(new CantFly());
        }
    }
}

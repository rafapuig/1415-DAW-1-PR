using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemoAnimales
{
    class Bird : Animal
    {
        public Bird()
        {
            SetFlyingStrategy(new ItFlys());
        }

    }
}

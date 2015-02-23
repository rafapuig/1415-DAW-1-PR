using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemoAnimales
{
    class Animal
    {
        protected IFlyStrategy flyStrategy;

        public void SetStrategy(IFlyStrategy flyStrategy)
        {
            this.flyStrategy = flyStrategy;
        }

        public void PerformFly()
        {
            this.flyStrategy.Fly();
        }

        // No se hace asi, se utiliza la estrategia
        //public void Fly()
        //{
        //    Console.WriteLine("Volando");
        //}
    }
}

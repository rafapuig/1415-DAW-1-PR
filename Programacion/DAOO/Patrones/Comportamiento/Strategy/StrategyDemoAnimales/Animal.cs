using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDemoAnimales
{
    class Animal
    {
        protected IFlyingStrategy flyingStrategy;

        public void SetFlyingStrategy(IFlyingStrategy newFlyingStrategy)
        {
            this.flyingStrategy = newFlyingStrategy;
        }

        public void PerformFly()
        {
            this.flyingStrategy.Fly();
        }

        // No se puede añadir si el comportamiento no es valido para TODAS las subclases!!!
        // Tendria que estar remplazandolo en cada clase que no se ajuste a este comportamiento (muchas posibles)
        public virtual void Fly()
        {
            Console.WriteLine("Estoy Volando");
        }
    }
}

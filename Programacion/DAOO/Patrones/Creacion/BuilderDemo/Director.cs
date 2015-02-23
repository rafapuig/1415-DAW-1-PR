using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.DAOO.Patterns.Creational.Builder
{
    interface Director<T>
    { 
        void Construct(ComparerBuilder<T> builder);
    }
}

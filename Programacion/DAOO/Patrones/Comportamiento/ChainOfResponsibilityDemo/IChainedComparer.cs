using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.DAOO.Patterns.Behavioral.ChainOfResposibility
{
    public interface IChainedComparer<T> : IComparer<T>
    {
        IChainedComparer<T> setSuccesor(IChainedComparer<T> succesor);

    }
}

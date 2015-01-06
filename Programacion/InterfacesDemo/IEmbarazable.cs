using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesDemo
{
    interface IEmbarazable
    {
        bool Embarazada();
        
        void QuedarEmbarazada(IInseminador inseminador);

        object Parir(string nombre);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaDemo
{
    //public enum TipoAnimal { Perro, Gato, Periquito}
    class Animal
    {
        //private TipoAnimal tipo;
        //public Animal(TipoAnimal tipo)
        //{
        //    this.tipo = tipo;
        //}

        public virtual string EmitirSonido()
        {
            return string.Empty;
        }

        //public string EmitirSonido()
        //{
        //    if (this.tipo == TipoAnimal.Perro)
        //        return "Guau";
        //    if (this.tipo == TipoAnimal.Gato)
        //        return "Miau";
        //    if (this.tipo == TipoAnimal.Periquito)
        //        return "Pio Pio";

        //    return string.Empty;
        //}
    }
}

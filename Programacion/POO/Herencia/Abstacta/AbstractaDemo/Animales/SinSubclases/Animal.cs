using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Herencia.Animales.SinSubclases
{

    public enum TipoAnimal { Perro, Gato, Periquito}
    
    public class Animal
    {
        private TipoAnimal tipo;
        public Animal(TipoAnimal tipo)
        {
            this.tipo = tipo;
        }        

        //Emitir sonido, depende del tipo de animal
        //Este metodo requiere cambios cuando se añada un nuevo tipo de animal
        public string EmitirSonido()
        {
            if (this.tipo == TipoAnimal.Perro)
                return "Guau";
            if (this.tipo == TipoAnimal.Gato)
                return "Miau";
            if (this.tipo == TipoAnimal.Periquito)
                return "Pio Pio";

            return string.Empty;
        }
    }
}


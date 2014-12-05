using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosDemo
{
    class Persona
    {
        public string Nombre { get; set; }

        public Persona(string nombre)
        {
            this.Nombre = nombre;
        }

        private Perro mascota;
        public Perro Mascota 
        { 
            get { return this.mascota; }
            set
            {
                this.mascota = value;
                if (this.mascota != null)
                {
                    this.Mascota.Solitario += Mascota_Solitario;
                    this.Mascota.Hambriento += Mascota_Hambriento;
                    this.Mascota.Sediento += Mascota_Sediento;
                    this.Mascota.Durmiendo += Mascota_Durmiendo;
                }
            } 
        }

        void Mascota_Durmiendo(object sender, EventArgs e)
        {
            Console.WriteLine(this.Nombre + " acaricia a " + (sender as Perro).Nombre + " en la cabeza.");
        }

        public void Mascota_Sediento(object sender, EventArgs e)
        {
            Console.WriteLine(this.Nombre + " pone un cuenco con agua para " + (sender as Perro).Nombre + ".");
        }

        void Mascota_Hambriento(object sender, EventArgs e)
        {
            Console.WriteLine(this.Nombre + " da de comer a " + (sender as Perro).Nombre + ".");
        }

        void Mascota_Solitario(object sender, EventArgs e)
        {
            Console.WriteLine(this.Nombre + " juega con " + (sender as Perro).Nombre + " un rato.");
        }
    }
}

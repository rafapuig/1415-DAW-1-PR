using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Persona
    {
        //Campo de solo lectura
        public readonly DateTime Creacion; // = DateTime.Now;

        //Constructores
        public Persona(string nombre) 
        {
            //this.Creacion = DateTime.Now;
            this.Nombre = nombre;
        }

        public Persona(string nombre, string apellido)
            : this(nombre)
        {
            this.Apellido = apellido;
        }



        public static string CapitalizarIniciales(string texto)
        {
            string[] partes = texto.Split(' ');


            for (int i = 0; i < partes.Length; i++)
            {
                //StringBuilder sb = new StringBuilder(partes[i]);
                //sb[0] = Char.ToUpper(sb[0]);

                char[] letras = partes[i].ToCharArray();
                letras[0] = Char.ToUpper(letras[0]);
                partes[i] = new string(letras);
            }

            return String.Join(" ", partes);
        }

        string nombre;
        public string Nombre
        {
            get { return this.nombre; }
            set 
            { 
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("El nombre no es valido", "Nombre");
                
                this.nombre = CapitalizarIniciales(value); 
            }
        }

        public string Apellido { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public int Edad 
        { 
            get 
            {
                return DateTime.Now.Year - this.FechaNacimiento.Year;
            } 
        }

        private Persona conyuge;
        public Persona Conyuge
        {
            get { return this.conyuge; }
        }
        
        public bool Casado { get { return this.conyuge != null; } }
        
        public void Casarse(Persona prometido)
        {
            //Comprobar prometido existe
            if (prometido == null)
                throw new ArgumentNullException("prometido",
                    "No se ha proporicinado una referencia a la persona prometida");
            
            //Comprobar que no se casa consigo mismo
            if (this == prometido)
                throw new ArgumentException("Una persona no puede casarse consigo misma");

            //Comprobar que no esta casado con otra persona
            if (Casado)
                throw new InvalidOperationException("No se puede cassar estando casado");

            if (prometido.Casado)
                throw new ArgumentException("Una persona casada no puede casarse con esta persona", "prometido");

            this.conyuge = prometido;
            prometido.conyuge = this;
        }

        public void Divorciarse()
        {
            //if (this.Conyuge == null)
            if (Casado)
                throw new InvalidOperationException("No se puede divorciar alguien que no este previamente casado");

            this.conyuge.conyuge = null;
            this.conyuge = null;
        }


        //public void SetNombre(string queNombre)
        //{
        //    this.nombre = queNombre;
        //}

        //public string GetNombre()
        //{
        //    return this.nombre;
        //}
       

        public string Presentarse()
        {
            return "Hola, me llamo " + this.NombreCompleto;
        }

        public string NombreCompleto
        {
            get { return this.Nombre + " " + this.Apellido; }
        }

        //public string NombreCompleto()
        //{
        //    return this.Nombre + " " + this.Apellido;
        //}

        public string PresentarA(Persona otra)
        {
            if (otra == null)
                throw new ArgumentNullException("No se ha proporcionado una referencia a una persona", "otra");

            //Si se trata de mi mismo, me presento
            if (otra == this)
                return this.Presentarse();          

            return "Te presento a " + otra.NombreCompleto;
        }
    }
}

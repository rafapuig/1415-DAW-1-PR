using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public enum EstadoCivil { Soltero, Casado, Divorciado, Viudo }
    public enum Genero { Hombre, Mujer }

    public class Persona
    {
        public static Persona Adan { get; private set; }
        public static Persona Eva { get; private set; }

        static Persona()
        {
            Adan = new Persona(Genero.Hombre, "Adan");
            Eva = new Persona(Genero.Mujer, "Eva");
        }

        //private static int _Poblacion = 0;
        public static int Poblacion { get; private set; }

        //Campo de solo lectura
        public readonly DateTime Creacion; // = DateTime.Now;

        //Constructores
        private Persona(Genero genero, string nombre) 
        {
            Poblacion++;
            this.Creacion = DateTime.Now;
            this.Nombre = nombre;
            this.EstadoCivil = EstadoCivil.Soltero;
            this.Genero = genero;
            //this.Padre = Adan;
            //this.Madre = Eva;
        }

        private Persona(Genero genero, string nombre, string apellido)
            : this(genero, nombre)
        {
            this.Apellido = apellido;
        }

        public static Persona Create(Genero genero, string nombre, string apellido)
        {
            return new Persona(genero, nombre, apellido);
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


        //public void SetNombre(string queNombre)
        //{
        //    this.nombre = queNombre;
        //}

        //public string GetNombre()
        //{
        //    return this.nombre;
        //}
       

        public string Apellido { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public int Edad 
        { 
            get 
            {
                return DateTime.Now.Year - this.FechaNacimiento.Year +
                    DateTime.Now.DayOfYear < this.FechaNacimiento.DayOfYear ? -1 : 0;
            } 
        }

        public EstadoCivil EstadoCivil { get; private set; }


        private Persona conyuge;

        public Persona Conyuge
        {
            get { return this.conyuge; }
        }

        public bool Casado { get { return this.conyuge != null; } } // o this.EstadoCivil == EstadoCivil.Casado;
        
        public void Casarse(Persona prometido)
        {
            //Comprobar prometido existe
            if (prometido == null)
                throw new ArgumentNullException("prometido",
                    "No se ha proporcionado una referencia a la persona prometida");
            
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

            this.EstadoCivil = EstadoCivil.Casado;
            this.conyuge.EstadoCivil = this.EstadoCivil;
        }

        public void Divorciarse()
        {
            //if (this.Conyuge == null)
            if (!Casado)
                throw new InvalidOperationException("No se puede divorciar alguien que no este previamente casado");

            this.conyuge.EstadoCivil = EstadoCivil.Divorciado;
            this.EstadoCivil = EstadoCivil.Divorciado;

            this.conyuge.conyuge = null;
            this.conyuge = null;
        }


        public string NombreCompleto
        {
            get { return this.Nombre + " " + this.Apellido; }
        }
                
        //public string NombreCompleto()
        //{
        //    return this.Nombre + " " + this.Apellido;
        //}

        
        public string Presentarse()
        {
            return "Hola, me llamo " + this.NombreCompleto;
        }
        
        public string PresentarA(Persona otra)
        {
            if (otra == null)
                throw new ArgumentNullException("No se ha proporcionado una referencia a una persona", "otra");

            //Si se trata de mi mismo, me presento
            if (otra == this)
                return this.Presentarse();          

            return "Te presento a " + otra.NombreCompleto;
        }


        public Persona Padre { get; set; }
        public Persona Madre { get; set; }

        public readonly Genero Genero;
        //public Genero Genero { get; set; }

        public static bool SonHermanos(Persona p1, Persona p2)
        {
            if (p1 == null || p2 == null) return false;

            if (p1.Padre == p2.Padre) return true;
            if (p2.Madre == p2.Madre) return true;
            return false;
        }

        public bool EsHermano(Persona otra)
        {
            return SonHermanos(this, otra);
        }


        public bool Huerfano
        {
            get { return this.Padre == null || this.Madre == null; }
        }

        public static bool SonPrimos(Persona p1, Persona p2)
        {
            //if (p1 == null) return false;
            //if (p2 == null) return false;            

            if (SonHermanos(p1.Padre, p2.Padre)) return true;
            if (SonHermanos(p1.Padre, p2.Madre)) return true;

            if (SonHermanos(p1.Madre, p2.Padre)) return true;
            if (SonHermanos(p1.Madre, p2.Madre)) return true;
            
            return false;
        }

        public bool EsPrimo(Persona otra)
        {
            return SonPrimos(this, otra);
        }

        public static bool SonCuñados(Persona p1, Persona p2)
        {
            if (SonHermanos(p1.Conyuge, p2)) return true;
            if (SonHermanos(p1.Conyuge, p2.Conyuge)) return true;
            if (SonHermanos(p1, p2.Conyuge)) return true;
            return false;
        }

        public bool EsTio(Persona sobrino)
        {
            return this.EsHermano(sobrino.Padre) || this.EsHermano(sobrino.Madre);
        }

        public bool EsSobrino(Persona tio)
        {
            return tio.EsTio(this);
        }


        public Persona AbueloPaterno
        {
            get
            {
                if (this.Padre != null) return this.Padre.Padre;
                return null;
            }
        }
        
        public Persona AbuelaPaterna
        {
            get
            {
                if (this.Madre != null) return this.Padre.Madre;
                return null;
            }
        }

        public Persona AbueloMaterno
        {
            get
            {
                if (this.Padre != null) return this.Madre.Padre;
                return null;
            }
        }

        public Persona AbuelaMaterna
        {
            get
            {
                if (this.Madre != null) return this.Madre.Madre;
                return null;
            }
        }
        

        public override string ToString()
        {
            return this.NombreCompleto + " (" + this.Genero + ")";
        }
            

        //Propiedad indice
        public string this[int parte]
        {
            get { return this.NombreCompleto.Split()[parte]; }
            //set { this.Hijos[orden] = value; } //no aplicable en este ejemplo
        } 
     

    }
}

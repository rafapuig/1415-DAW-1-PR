using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.DAOO.Patterns.Behavioral.ChainOfResposibility
{
    public enum EstadoCivil { Soltero, Casado, Divorciado, Viudo }
    public enum Genero { Hombre, Mujer }
    public enum Vinculo { Materno, Paterno }
    public enum OrdenApellido { Primero, Segundo }

    public class Persona
    {
        public static Persona Adan { get; private set; }
        public static readonly Persona Eva; //Eva no puede asignarse salvo en el constructor de la clase (static)

        static Persona()
        {
            Adan = new Persona(Genero.Hombre, "Adan");
            Eva = new Persona(Genero.Mujer, "Eva");
        }

        //private static int _Poblacion = 0;
        public static int Poblacion { get; private set; }

        //Campo de solo lectura
        public readonly DateTime Creacion; // = DateTime.Now;

        public readonly Genero Genero;  //El genero no puede cambiar una vez construido el objeto Persona
        //public Genero Genero { get; set; }

        #region "Constructores de instancia"
        
        //Constructores
        private Persona(Genero genero, string nombre)
        {
            Poblacion++;

            this.Creacion = DateTime.Now;
            this.EstadoCivil = EstadoCivil.Soltero;
            this.Genero = genero;
            this.Nombre = nombre;

            //this.Padre = Adan;
            //this.Madre = Eva;
        }

        private Persona(Genero genero, string nombre, string apellido)
            : this(genero, nombre)  //Delegar en el construtor de personas con menos parametros
        {
            this.Apellido = apellido;
        }


        public Persona(Genero genero, string nombre, string apellido1, string apellido2)
            : this(genero, nombre, apellido1)
        {
            //this.apellidos[(int)OrdenApellido.Segundo] = apellido2;
            this[OrdenApellido.Segundo] = apellido2;
        }

        private static string ObtenerApellidoProgenitor(Persona progenitor)
        {
            //if (progenitor == null) return String.Empty;
            //return progenitor[OrdenApellido.Primero];

            return progenitor != null ?
                progenitor[OrdenApellido.Primero] //Los progenitores otorgan a sus descencientes su primer apellido
                : String.Empty;
        }

        //Por motivos pedagogicos se obtiene el primer apellido de los progenitores 
        //de distinta forma
        public Persona(Genero genero, string nombre, Persona padre, Persona madre)
            : this(genero, nombre,
            ObtenerApellidoProgenitor(padre),
            madre != null ? madre[OrdenApellido.Primero] : String.Empty)
        {
            this.Padre = padre;
            this.Madre = madre;
        }

        #endregion

        //Metodo de la clase que genera instancias objetos de tipo Persona (Fabrica)
        public static Persona Create(Genero genero, string nombre, string apellido)
        {
            return new Persona(genero, nombre, apellido);
        }

        #region "Nombre y apellidos"

        public static string CapitalizarIniciales(string texto)
        {
            //Comprobar que tenemos un texto no nulo antes de dividirlo en partes
            if (String.IsNullOrEmpty(texto)) return String.Empty;

            //Separar un texto en palabras
            string[] partes = texto.Split(' ');

            //Para cada palabra que compone el texto (ahora cono vector de palabras)...
            for (int i = 0; i < partes.Length; i++)
            {
                //StringBuilder sb = new StringBuilder(partes[i]);
                //sb[0] = Char.ToUpper(sb[0]);

                //Obtener las letras que de que se compone una palabra
                char[] letras = partes[i].ToCharArray();

                //Poner la primera letra en mayusculas
                letras[0] = Char.ToUpper(letras[0]);

                //Asignar la palabra a partir de la letras, ya con la primera en mayusculas
                partes[i] = new string(letras);
            }

            //Unir las palabras que componen el texto mediante espacios
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


        public bool EsTocayoDe(Persona otra)
        {
            if (otra == null) throw new ArgumentNullException("otra", "No se ha proporcionado una referencia a una persona");
            return this.Nombre == otra.Nombre;
        }
        
        //public void SetNombre(string queNombre)
        //{
        //    this.nombre = queNombre;
        //}

        //public string GetNombre()
        //{
        //    return this.nombre;
        //}
                

        public static readonly int TotalApellidos = 2;
        
        //No permitirmos que se cambie la referencia por otro array distinto al que le asignamos aqui
        private string[] apellidos = new string[TotalApellidos];
        
        //vamos a comentarlo porque no permitimos modificacion de los elementos del array
        //public string[] Apellidos
        //{
        //    get { return this.apellidos; }        
        //}

        //Propiedad indice devuelde un apellido u otro
        public string this[OrdenApellido parte]
        {
            get { return this.apellidos[(int)parte]; }
            private set
            {
                this.apellidos[(int)parte] = CapitalizarIniciales(value);
            }            
        }

        public string Apellido 
        {
            get { return this[OrdenApellido.Primero]; }
            set { this[OrdenApellido.Primero] = value; }
        }

        public string SegundoApellido
        {
            get { return this[OrdenApellido.Segundo]; }
            set { this[OrdenApellido.Segundo] = value; }
        }

        //Propiedad Nombre Completo (solo lectura), se obtiene a partir de otras propiedades del objeto
        public string NombreCompleto
        {
            get
            {
                StringBuilder sb = new StringBuilder(this.nombre);
                foreach (string apellido in this.apellidos)
                {
                    if (!String.IsNullOrEmpty(apellido))
                        sb.AppendFormat(" {0}", apellido);
                }
                return sb.ToString();
            }
        }

        //public string NombreCompleto()
        //{
        //    return this.Nombre + " " + this.Apellido;
        //}

#endregion
                
        #region "Saludos y presentaciones"

        public string Presentarse()
        {
            return this.Nombre + ":" + "Hola, me llamo " + this.NombreCompleto;
        }

        public string SaludarA(Persona otra)
        {
            return this.Nombre + ": " + "Hola " + otra.Nombre + "! ¿Como estas?";
        }

        public string PresentarA(Persona otra)
        {
            if (otra == null)
                throw new ArgumentNullException("No se ha proporcionado una referencia a una persona", "otra");

            //Si se trata de mi mismo, me presento
            if (otra == this)
                return this.Presentarse();

            return this.Nombre + ":" + "Te presento a " + otra.NombreCompleto;
        }

        #endregion

        
        public DateTime FechaNacimiento { get; set; }

        public int Edad 
        { 
            get 
            {
                return DateTime.Now.Year - this.FechaNacimiento.Year +
                    DateTime.Now.DayOfYear < this.FechaNacimiento.DayOfYear ? -1 : 0;
            } 
        }
        

        #region "Estado Civil, Casarse, Divorciarse ..."

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
                throw new InvalidOperationException("No se puede casar estando casado");

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

        #endregion


        #region "Padre, Madre y Horfandad"

        private Persona padre;
        public Persona Padre
        {
            get { return this.padre; }
            set
            {
                //Comprobar que el padre es un hombre
                if (value != null && value.Genero != Genero.Hombre)
                    throw new ArgumentException("El padre debe ser un hombre");
                
                this.padre = value;
            }
        }

        private Persona madre;
        public Persona Madre
        {
            get { return this.madre; }
            set
            {
                //Comprobar que la madre es una mujer
                if (value != null && value.Genero != Genero.Mujer)
                    throw new ArgumentException("La madre debe ser una mujer");

                this.madre = value;
            }
        }
         

        public bool HuerfanoTotal
        {
            get { return this.Padre == null && this.Madre == null; }
        }

        public bool Huerfano(Vinculo vinculo)
        {
            switch (vinculo)
            {
                case Vinculo.Materno:
                    return this.Madre == null;
                    
                case Vinculo.Paterno:
                    return this.Padre == null;
            }
            return false;
        }

        #endregion


        #region "Parentescos"

        public static bool SonHermanos(Persona p1, Persona p2)
        {
            if (p1 == null || p2 == null) return false;

            if (p1.Padre == p2.Padre && p1.Padre != null) return true;
            if (p2.Madre == p2.Madre && p1.Madre != null) return true;
            return false;
        }

        public bool EsHermano(Persona otra)
        {
            return SonHermanos(this, otra);
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
            if (sobrino == null) return false;
            return this.EsHermano(sobrino.Padre) || this.EsHermano(sobrino.Madre);
        }

        public bool EsSobrino(Persona tio)
        {
            if (tio == null) return false;
            return tio.EsTio(this);
        }

        #endregion


        #region "Abuelos"

        public Persona AbueloPaterno
        {
            get
            {
                return Abuelo(Vinculo.Paterno);                
            }
        }
        
        public Persona AbuelaPaterna
        {
            get
            {                
                return Abuelo(Vinculo.Paterno, Genero.Mujer);
            }
        }

        public Persona AbueloMaterno
        {
            get
            {
                if (this.Madre != null) return this.Madre.Padre;
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

        public Persona Abuelo(Vinculo vinculo)
        {
            switch (vinculo)
            {
                case Vinculo.Materno:
                    if (this.Madre != null) return this.Madre.Padre;
                    break;
                case Vinculo.Paterno:
                    if (this.Padre != null) return this.Madre.Padre;
                    break;                
            }
            return null;
        }

        public Persona Abuela(Vinculo vinculo)
        {
            //Delegamos en el metodo Abuelo, pasando el vinculo y como genero mujer
            return Abuelo(vinculo, Genero.Mujer);
        }

        public Persona Abuelo(Vinculo vinculo, Genero genero)
        {
            Persona prognitor = null;

            switch (vinculo)
            {
                case Vinculo.Materno:
                    prognitor = this.Madre;
                    break;
                case Vinculo.Paterno:
                    prognitor = this.Padre;
                    break;               
            }

            if (prognitor != null)
            {
                switch (genero)
                {
                    case Genero.Hombre: return prognitor.Padre;
                    case Genero.Mujer: return prognitor.Madre;
                }
            }

            return null;
        }

        #endregion


        //Reemplazar la representacion textual del objeto
        public override string ToString()
        {
            return this.NombreCompleto + " (" + this.Genero + ") [" + this.FechaNacimiento + "] " + this.EstadoCivil; ;
        }

    }
}

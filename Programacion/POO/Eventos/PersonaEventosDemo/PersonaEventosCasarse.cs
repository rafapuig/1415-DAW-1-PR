using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.POO.Eventos
{
    partial class Persona
    {
        public event EventHandler RecienCasado;
        protected virtual void OnRecienCasado(EventArgs e)
        {
            if (RecienCasado != null) RecienCasado(this, e);
        }
        
        public Persona Conyuge
        {
            get { return this.conyuge; }
            private set
            {
                this.conyuge = value;
                if (value != null) OnRecienCasado(EventArgs.Empty);                             
            }
        }

        
        public event EventHandler<CasandoseEventArgs> Casandose;

        protected virtual bool OnCasandose(CasandoseEventArgs e)
        {
            if (this.Casandose != null)
            {
                //Invocar la lista de controladores mientras ningun cancele el matrimonio
                foreach (EventHandler<CasandoseEventArgs> handler in Casandose.GetInvocationList())
                {
                    handler.Invoke(this, e);
                    if (e.AnularMatrimonio == true) return true;
                }

                //Ahora invocar la lista de controladores para el evento pero con el novio / novia
                CasandoseEventArgs novioEventArgs = new CasandoseEventArgs(this);

                foreach (EventHandler<CasandoseEventArgs> handler in e.Novio.Casandose.GetInvocationList())
                {
                    handler.Invoke(e.Novio, novioEventArgs);
                    e.AnularMatrimonio = novioEventArgs.AnularMatrimonio;
                    if (novioEventArgs.AnularMatrimonio == true) return true;
                }
            }
            return e.AnularMatrimonio;
        }

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

            if (this.Casandose != null || prometido.Casandose != null)
            {
                //Provocamos el evento para dar la oportunidad al codigo cliente de anular el matrimonio
                CasandoseEventArgs cea = new CasandoseEventArgs(prometido);
                this.OnCasandose(cea); //Lanzar el evento Casandose

                //Si se anulan el matrimonio por salir del metodo
                if (cea.AnularMatrimonio) return;
            }

            //CasandoseEventArgs prometidocea = new CasandoseEventArgs(this);
            //prometido.OnCasandose(prometidocea); //El prometido tambien lanza el evento

            ////Si anulan el matrimonio por la otra parte, salir del metodo
            //if (prometidocea.AnularMatrimonio) return;

            this.Conyuge = prometido;
            prometido.Conyuge = this;

            this.EstadoCivil = EstadoCivil.Casado;
            this.conyuge.EstadoCivil = this.EstadoCivil;

            //Ya lo hace la propiedad Conyuge por eso esta comentado
            //this.OnRecienCasado(EventArgs.Empty);
            //this.conyuge.OnRecienCasado(EventArgs.Empty);

        }

    }


    public class CasandoseEventArgs : System.EventArgs
    {
        public readonly Persona Novio;
        public bool AnularMatrimonio;

        public CasandoseEventArgs(Persona novio)
        {
            this.Novio = novio;
        }

    }

}

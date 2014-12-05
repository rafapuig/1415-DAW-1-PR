using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace EventosDemo
{
    class Perro
    {
        public event EventHandler Solitario;
        public event EventHandler Hambriento;
        public event EventHandler Sediento;
        public event EventHandler Durmiendo;

        private Thread vida;

        public string Nombre { get; private set; }

        public Perro(string nombre)
        {
            this.Nombre = nombre;
            vida = new Thread(this.Vivir);
            vida.Start();
        }

        protected void OnSolitario(EventArgs e)
        {
            if (this.Solitario != null) Solitario(this, e);
        }

        protected void OnHambriento(EventArgs e)
        {
            if (this.Hambriento != null) Hambriento(this, e);
        }

        protected void OnSediento(EventArgs e)
        {
            if (this.Sediento != null) Sediento(this, e);
        }

        protected void OnDurmiendo(EventArgs e)
        {
            if (this.Durmiendo != null) Durmiendo(this, e);
        }

        static Random alea = new Random(0);

        private void Vivir()
        {
            while (true)
            {
                switch (alea.Next(4))
                {
                    case 0: 
                        OnSolitario(EventArgs.Empty);
                        break;
                    case 1:
                        OnHambriento(EventArgs.Empty);
                        break;
                    case 2:
                        OnSediento(EventArgs.Empty);
                        break;
                    case 3:
                        OnDurmiendo(EventArgs.Empty);
                        break;
                }
                Thread.Sleep(1000);
            }
        }
    }
}

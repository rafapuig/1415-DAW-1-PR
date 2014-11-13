using System;
using System.Threading;

namespace Programacion.TiposCompuestos.Ejemplos
{
    enum Duracion
    {
        Redonda = Blanca * 2,
        Blanca = 1600,
        Negra = Blanca /2,
        Corchea = Negra / 2,
        Semicorchea = Corchea / 2
    }

    enum Tono
    {
        Silencio = 0,
        SolGrave = 196,
        La =220,
        LaSostenido = 233,
        Si = 247,
        Do = 262,
        DoSostenido = 277,
        Re = 294,
        ReSostenido = 311,
        Mi=330,
        Fa=349,
        Sol=392,
        SolSoltenido=415
    }

    struct Nota
    {
        Tono tono;
        Duracion duracion;

        public Nota(Tono frecuencia, Duracion tiempo)
        {
            tono = frecuencia;
            duracion = tiempo;
        }

        public Tono Tono { get { return this.tono; } }
        public Duracion Duracion { get { return duracion; } }
    }

    
    static class ConsoleBeepDemo
    {
        static void Main()
        {
            Nota[] Mary = {
                                new Nota(Tono.Si, Duracion.Corchea),
                                new Nota(Tono.La, Duracion.Corchea),
                                new Nota(Tono.SolGrave, Duracion.Corchea),
                                new Nota(Tono.La, Duracion.Corchea),
                                new Nota(Tono.Si, Duracion.Corchea),
                                new Nota(Tono.Si, Duracion.Corchea),
                                new Nota(Tono.Si, Duracion.Negra),
                                new Nota(Tono.La, Duracion.Corchea),
                                new Nota(Tono.La, Duracion.Corchea),
                                new Nota(Tono.La, Duracion.Negra),
                                new Nota(Tono.Si, Duracion.Corchea),
                                new Nota(Tono.Re, Duracion.Corchea),
                                new Nota(Tono.Re, Duracion.Negra)
                          };
   
            Play(Mary);
        }


        static void Play(Nota[] melodia)
        {
            foreach (Nota n in melodia)
            {
                if (n.Tono == Tono.Silencio)
                    Thread.Sleep((int)n.Duracion);
                else
                    Console.Beep((int)n.Tono, (int)n.Duracion);
            }
        }

    }
}

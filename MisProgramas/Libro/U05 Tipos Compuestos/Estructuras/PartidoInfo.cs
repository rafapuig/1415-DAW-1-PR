using System;

namespace Programacion.TiposCompuestos.Estructuras
{
    [Flags]
    enum Demarcaciones
    {
        Portero = 0,
        LateralDerecho = 0x1,
        LateralIzquierdo = 0x2,
        Lateral = LateralDerecho | LateralIzquierdo,
        DefensaCentral = 0x4,
        Defensa = DefensaCentral | Lateral,
        MediaPunta = 0x8,
        MedioCentro = 0x10,
        CentroCampista = MediaPunta | MedioCentro,
        DelanteroCentro = 0x20,
        ExtremoDerecho = 0x40,
        ExtremoIzquierdo = 0x80,
        Extremo = ExtremoDerecho | ExtremoIzquierdo,
        Delantero = Extremo | DelanteroCentro,
    }

    enum Demarcacion
    {
        Portero,
        Defensa,
        Centrocampista,
        Delantero
    }

    struct Jugador
    {
        public int Dorsal;
        public string Nombre;
        public Demarcacion Puesto;
    }

    static class PartidoInfo
    {
        static void Main()
        {
            EjemploInicializacion1();
            EjemploInicializacion2();

            Console.ReadKey();
        }

        static void ProbarJugador()
        {
            Jugador j;

            j.Nombre = "Pepe";
            j.Puesto = Demarcacion.Defensa;
            j.Dorsal = 6;

            Jugador j2;
            j2.Nombre = "Manolo";
            j2.Dorsal = 14;
            j2.Puesto = Demarcacion.Portero;

            if (j.Puesto == j2.Puesto) { }
            j2.Dorsal = j.Dorsal;
        }


        static void MostrarEquipo(Jugador[] equipo)
        {
            Console.WriteLine("{0,6}  {1,-30}{2,-20}", "Dorsal", "Nombre", "Demarcacion");
            Console.WriteLine(new string('-', 58));
            foreach (Jugador j in equipo)
            {
                Console.Write("{0,6}  ", j.Dorsal);
                Console.Write("{0,-30}", j.Nombre);
                Console.Write("{0,-20}", j.Puesto);
                Console.WriteLine();
            }
        }

        static void EjemploInicializacion2()
        {
            Jugador[] local = new Jugador[] { 
                new Jugador {Nombre="Benzema", Dorsal=9, Puesto=Demarcacion.Delantero},
                new Jugador {Nombre="James Rodriguez", Dorsal=10, Puesto=Demarcacion.Centrocampista},
                new Jugador {Nombre="Sergio Ramos", Dorsal=4, Puesto=Demarcacion.Defensa}
            };

            MostrarEquipo(local);

        }

        private static void EjemploInicializacion1()
        {
            Jugador[] local = new Jugador[11];
            Jugador[] equipovisitante = new Jugador[11];

            local[0].Nombre = "Iker Casillas";
            local[0].Puesto = Demarcacion.Portero;
            local[0].Dorsal = 1;

            local[1].Nombre = "Cristiano Ronaldo";
            local[1].Puesto = Demarcacion.Delantero;
            local[1].Dorsal = 7;

            MostrarEquipo(local);
        }
    }
}

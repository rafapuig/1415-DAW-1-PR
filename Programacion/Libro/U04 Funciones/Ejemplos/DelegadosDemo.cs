using System;

namespace Programacion.TiposCompuestos.Ejemplos
{
    delegate int EstrategiaAtaque(string nombreObjeto, int poder);

    class DelegadosDemo
    {
        static void Main()
        {          
            EstrategiaAtaque estrategia = AtacarConEspada;
 
           int vida = 100;
           ProcesarAtaque(5, ref vida, "X", estrategia);
           Console.WriteLine("Vida = {0}", vida);

           estrategia = AtacarConCuchillo;
           ProcesarAtaque(7, ref vida, "otro", estrategia);
           Console.WriteLine("Vida = {0}", vida);

        }

        static void ProcesarAtaque(int poder, ref int vida, string arma, EstrategiaAtaque ataque)
        {
            Console.WriteLine("Efectuando el ataque");
            int daño = ataque(arma, poder);
            vida = vida - daño;
        }

        static int AtacarConCuchillo(string texto, int poder)
        {
            Console.WriteLine("Atacando con cuchillo" + texto);
            return poder;
        }

        static int AtacarConEspada(string texto, int poder)
        {
            Console.WriteLine("Atacando con la espada " + texto);
            return poder * 4;
        }

    }
}

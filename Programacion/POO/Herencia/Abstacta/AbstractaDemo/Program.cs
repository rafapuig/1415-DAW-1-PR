using SinSubclases = Programacion.POO.Herencia.Animales.SinSubclases;
using Hide = Programacion.POO.Herencia.Animales.Subclases.Hide;
using Virtual = Programacion.POO.Herencia.Animales.Subclases.Virtual;
using Abstracta = Programacion.POO.Herencia.Animales.Abstracta;

namespace AbstractaDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            SinSubclases.Programa.Main();
            Hide.Programa.Main();
            Virtual.Programa.Main();
            Abstracta.Programa.Main();
        }
    }
}

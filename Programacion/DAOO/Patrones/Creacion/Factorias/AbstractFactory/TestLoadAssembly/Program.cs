using System;
using System.Diagnostics;
using System.Reflection;
using System.Linq;

namespace TestLoadAssembly
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly a = Assembly.Load("Barajas.Modelos.Heraclio");
            Assembly b = Assembly.Load("Barajas.Modelos.Heraclio");
            Console.WriteLine(a == b);

            

            Stopwatch w = new Stopwatch();
            w.Start();

            int veces = 0;

            for (int n = 0; n < 100; n++)
            {
                Assembly.Load("Barajas.Modelos.Heraclio");
            }

            //veces = AppDomain.CurrentDomain.GetAssemblies().Where(asm => asm.FullName == "Barajas.Modelos.Heraclio").Count();

            w.Stop();

            Console.WriteLine("Tiempo: {0}", w.Elapsed);

            veces = AppDomain.CurrentDomain.GetAssemblies().Count(asm => asm.FullName.StartsWith("Barajas.Modelos.Heraclio"));

            Array.ForEach(AppDomain.CurrentDomain.GetAssemblies(), asm => { Console.WriteLine(asm.FullName); });

            Console.WriteLine("Veces: {0}", veces);
            Console.ReadKey();

        }
    }
}

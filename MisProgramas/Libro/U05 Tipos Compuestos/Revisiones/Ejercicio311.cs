using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.Iniciacion.Actividades
{
    static class Ejercicio311
    {
        static void Main()
        {            
            int num = 234;
            string sNum = num.ToString();

            for (int i = 0; i < sNum.Length; i++)
                Console.Write("{0}{1}", sNum[i], i < sNum.Length - 1 ? "-" : "\n");
        }
    
    } 
    
}

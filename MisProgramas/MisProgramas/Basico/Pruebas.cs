using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisProgramas.Basico
{
    class Pruebas
    {
        static void Main()
        {
            //Arco para la media hora: 270 grados
            Console.WriteLine("Arco para la media hora: {0}",MinutosAGrados(30));

            //Arco para los 60 minutos: 90 grados
            Console.WriteLine("Arco para los 60 minutos: {0}", MinutosAGrados(60));

            //Arco para los 10 miinutos
            Console.WriteLine("Arco para los 10 minutos: {0}", MinutosAGrados(10));

            //Arcos para los 50 minutos
            Console.WriteLine("Arco para los 50 minutos: {0}", MinutosAGrados(50));


            Console.WriteLine("Arco para las 3 horas: {0}", HorasAGrados(3));
            Console.WriteLine("Arco para las 6 horas: {0}", HorasAGrados(6));
            Console.WriteLine("Arco para las 8 horas: {0}", HorasAGrados(8));
            Console.WriteLine("Arco para las 12 horas: {0}", HorasAGrados(12));
            Console.WriteLine("Arco para las 18 horas: {0}", HorasAGrados(18));

            Console.WriteLine("Arco para las 18:30 horas: {0}", HorasAGrados(18,30));
            Console.WriteLine("Arco para las 18:59 horas: {0}", HorasAGrados(18, 59));            

            Console.ReadKey();
        }

        static double SegundosAGrados(int segundos)
        {
            const int segundosMinuto = 60;
            const int gradosCirunferencia = 360;

            //const double arcoPorSegundo = (double)gradosCirunferencia / segundos;

            segundos = segundos % segundosMinuto;

            //Calculo de arco que describem n segundos
            double arco = segundos * segundosMinuto;

            const double origen = 90;
            double grado = origen - arco;

            return grado;
        }
                
        static double MinutosAGrados(int minutos)
        {
            const int minutosHora = 60;
            const int gradosCircunferencia = 360;
            //Cada minuto son 6 grados, en 360 grados caben los 60 minutos de una hora si cada minuto son 6 grados
            const double arcoPorMinuto = (double)gradosCircunferencia / minutosHora;

            //Cada 60 minutos el minutero se pone a 0
            minutos %= minutosHora;           

            //Cada minuto son 6 grados
            double arco = minutos * arcoPorMinuto; //* 90 / 15; // * 360/60
            
            //Positivo contra agujas del reloj 
            //Negativo a favor de las agujas del reloj
            double grados = 90 - arco;

            //Si sumamos una vuelta entera nos quedamos donde estabamos
            grados = (grados + gradosCircunferencia) % gradosCircunferencia;
            return grados;
        }

        static double HorasAGrados(int horas, int minutos=0)
        {
            //Cada hora es la doceava parte de la circunferencia de 360 grados 
            const double arcoPorHora = 360 / 12;

            //Cada minuto que pasa destro de una hora, que proporcion del arco de una hora respresenta
            const double arcoPorMinuto = arcoPorHora / 60;
           
            //Las 12 horas vuelven a ser las 0, las 24 tambien
            horas %= 12;
                       
            double arco = horas * arcoPorHora;
            double grados = 90 - arco;
            grados = (grados + 360) % 360;

            grados -= minutos * arcoPorMinuto;

            return grados;
        }
    }
}

using System;
class RelojAnalogico
{
    const double GradosCircunferencia = 360; //Numero total de grados que tiene la circunferencia
    const int Segundos1Minuto = 60; //Numero de segundos en un minuto
    const int Minutos1Hora = 60;    //Numero de minutos en una hora
    const int HorasEsfera = 12; //Numero total de horas en una esfera de un reloj analogico
    const double Grados1Segundo = GradosCircunferencia / Segundos1Minuto;
    const double Grados1Minuto = GradosCircunferencia / Minutos1Hora;
    const double Origen = 90;   //La hora 0:00:00 esta en 90 grados respecto del origen

    static void Main()
    {
        ConsoleKeyInfo key;
        do
        {
            Console.Write("Dame el numero de segundos: ");
            string entrada = Console.ReadLine();
            int seg;
            bool esUnEntero = int.TryParse(entrada, out seg);

            if (esUnEntero)
            {
                double grados = RelojAnalogico.ConvertirSegundosAGrados(seg);

                Console.WriteLine("El segundero tiene {0} de inclinacion para {1} segundos",
                    grados,
                    seg);
            }
            else
                Console.WriteLine("{0} no es un numero", entrada);

            Console.WriteLine("Desea finalizar (s/n)?");
            key = Console.ReadKey();
            
        } while (key.KeyChar != 's');
    }

    
    static double ConertirMinutosAGrados(int minutos)
    {
        minutos = minutos % Minutos1Hora;
        double arco = minutos * Grados1Minuto;
        return ConvertirArcoEnGrados(arco);
    }

    static double ConvertirSegundosAGrados(int segundos) 
    {
        segundos %= Segundos1Minuto;
        double arco = segundos * Grados1Segundo;
        return ConvertirArcoEnGrados(arco);
    }

    private static double ConvertirArcoEnGrados(double arco)
    {
        double grados = Origen - arco;  //Positivo avanza en sentido antihorario y negativo avanza en sentido horario
        grados = (grados + GradosCircunferencia) % GradosCircunferencia;    //Damos una vuelta completa para hacerlo positivo
        return grados;
    }
}
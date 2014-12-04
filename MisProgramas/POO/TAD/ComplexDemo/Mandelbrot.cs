using System;
using System.Numerics;


namespace ComplexDemo
{
    class Mandelbrot
    {
        /* Cada posicion en la imagen de Maldelbrot corresponde al numero imaginario N = x + y i
       * x: parte real
       * y: parte imaginaria
       * i es la raiz cuadrada de -1
       * (x,y) son las coordenadas de la posicion en la imagen
       * Para cada posicion se calcula el argumento de N
       * raiz cuadrada de : x * x + y * y
       * Si el resultado es >= 2 en esa posicion el valor es u 0
       * Si es menor que 2 hacemos que N = N*N-N donde N = (x*x - y*y - x) + (2*x*y-y) i
       * volveos a comprobar
       * si >=2 entonces resultado 1 sino seguimos
       */
        static void Main(string[] args)
        {
            
            double realCoord, imagCoord;    //parte real y parte imaginaria del numero imaginario N

            //double realTemp, imagTemp, realTemp2, arg;
            int iterations;

            //Para cada fila            

                for (imagCoord = 1.2; imagCoord >= -1.2; imagCoord -= 0.05)     //Cuantas veces se repetira el bucle?
                {
                    //Para cada columna desde -0,6 hasta 1.77                 
                    for (realCoord = -0.6; realCoord <= 1.77; realCoord += 0.03)    //Cuantas veces se repetira el bucle?
                    {
                        iterations = 0;
                        Complex N = new Complex(realCoord, imagCoord);

                        //realTemp = realCoord;
                        //imagTemp = imagCoord;                        
                        Complex tempN = N;
                        
                        //arg = (realCoord * realCoord) + (imagCoord * imagCoord);                       
                        
                        //while ((arg < 4) && (iterations < 40))
                        while ((tempN.Magnitude * tempN.Magnitude < 4) && (iterations < 40))
                        {
                            //realTemp2 = (realTemp * realTemp) - (imagTemp * imagTemp) - realCoord;
                            //imagTemp = (2 * realTemp * imagTemp) - imagCoord;
                            //realTemp = realTemp2;
                            //arg = (realTemp * realTemp) + (imagTemp * imagTemp);
                            tempN = tempN * tempN - N;                            
                            iterations += 1;
                        }

                        switch (iterations % 4)
                        {
                            case 0:
                                Console.Write(".");
                                break;
                            case 1:
                                Console.Write("o");
                                break;
                            case 2:
                                Console.Write("O");
                                break;
                            case 3:
                                Console.Write("@");
                                break;
                        }
                    }

                    Console.Write("\n");
                }
            Console.ReadKey();
        }
    }
}

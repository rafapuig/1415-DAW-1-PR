using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion.TiposCompuestos.Matrices
{
    class MatricesDemo
    {
        static void Main()
        {
            double[,] A = new[,] {
                                    {1.0,3.0},
                                    {2.0,5.0},
                                    {4.0,8.0}
                                 };

            double[,] B = new[,] {
                                    {1.0,5.0},
                                    {2.0,3.0},                                 
                                 };

            MostrarMatriz(A.Multiplicar(B).Trasponer());
            MostrarMatriz(B.Trasponer().Multiplicar(A.Trasponer()));

            Console.ReadKey();
        }

        static void MostrarMatriz(double[,] m)
        {
            Console.WriteLine(Matrix.ToString(m)); //No se puede usar sintaxis de metodos de extension por existir metodo inst
        }
    }

    static class Matrix
    {

        public static string ToString(double[,] m)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < m.GetLength(0); i++)
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    sb.AppendFormat("{0,4}{1}", m[i, j], (j == m.GetLength(1) - 1) ? "\n" : " ");
                }

            return sb.ToString();
        }

        static double[,] Sumar(this double[,] a, double[,] b)
        {
            //Precondiciones, las dimensiones de las matrices tienen que ser iguales
            for (int i = 0; i < a.Rank; i++)
            {
                if (a.GetLength(i) != b.GetLength(i))
                    throw new ArgumentException("No se pueden sumar las matrices proporcionadas, las dimensiones no son compatibles.");
            }

            int rows = a.GetLength(0);
            int cols = a.GetLength(1);

            double[,] res = new double[rows, cols];

            for (int i = 0; i < rows; i++)
                for (int j = 0; i < cols; j++)
                    res[i, j] = a[i, j] + b[i, j];

            return res;
        }

        public static double[,] Multiplicar(this double[,] a, double[,] b)
        {
            //Precondiciones, a[filas,n] y b[n,cols]

            if (a.GetLength(1) != b.GetLength(0))
                throw new ArgumentException("No se pueden multiplicar las matrices proporcionadas, las dimensiones no son compatibles.");


            int rows = a.GetLength(0);
            int cols = b.GetLength(1);

            // Tamaño columas a = filas b
            int n = a.GetLength(1);

            double[,] res = new double[rows, cols];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    for (int k = 0; k < n; k++)
                        res[i, j] += a[i, k] * b[k, j];

            return res;
        }

        public static double[,] Trasponer(this double[,] a)
        {
            int rows = a.GetLength(1);
            int cols = a.GetLength(0);
            double[,] res = new double[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    res[i, j] = a[j, i];
            
            return res;
        }

    }
}

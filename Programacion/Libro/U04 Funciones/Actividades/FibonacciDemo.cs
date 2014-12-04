using System;
using System.Collections.Generic;

static class FibonacciDemo
{
    static void Main()
    {
        Console.Title = "Fibonacci Demo";
        Console.WriteLine("Introduce el numero n");

        int n = Int32.Parse(System.Console.ReadLine());       

        for (int i = 0; i <= n; i++)
        {
            ulong fib = Fibonacci2(i);
            Console.WriteLine("Fibonacci({0}) = {1}", i, fib);
        }

        foreach (ulong i in FibonacciIterator(n))
        {
            Console.Write("{0} ", i);
        }

        Console.ReadKey();
    }

    //Version iterativa 
    static ulong FibonacciIterativo(int n)
    {
        int i = 2;
        ulong previo = 1;
        ulong actual = 1;
        while(i<=n)
        {
            ulong siguiente = previo + actual;
            previo = actual;
            actual = siguiente;
            i++;
        }

        return actual;
    }

    static IEnumerable<ulong> FibonacciIterator(int n)
    {
        int i = 0;
        ulong previo = 1;
        ulong actual = 1;
        while (i <= n)
        {
            yield return previo;
            
            ulong siguiente = previo + actual;
            previo = actual;
            actual = siguiente;
            i++;
        }        
    }

    static IEnumerable<ulong> FibonacciIterator2(int n)
    {
        for (ulong i = 0, previo = 1, actual = 1; (int)i <= n; i++)
        {
            yield return previo;
            ulong siguiente = previo + actual;
            previo = actual;
            actual = siguiente;
        }
    }
        
    



    //Version recursiva ienficiente
    static int Fibonacci(int n)
    {
        if (n == 0 || n == 1) return 1;
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }


    //Version Recursiva Eficiente
    static ulong Fibonacci2(int n)
    {
        return Fibonacci(0ul, 1ul, n);
    }

    static ulong Fibonacci(ulong previo, ulong actual, int n)
    {        
        if (n == 0) return actual;
        return Fibonacci(actual, previo + actual, n - 1);
    }
}
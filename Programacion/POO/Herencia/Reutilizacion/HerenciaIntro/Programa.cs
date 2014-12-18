using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaDemo
{
    class Programa
    {
        static void Main()
        {
            TestEmpleadoPorDelegacion();
            TestEmpleadoHeredaDePersona();
        }

        static void TestEmpleadoPorDelegacion()
        {
            Delegacion.Empleado emp = new Delegacion.Empleado();
            emp.Nombre = "Rafa";
            emp.Apellido = "Puig";
            emp.Salario = 1000;

            //Persona p = emp;// No es posible hacer esto con delegacion
        }

        static void TestEmpleadoHeredaDePersona()
        {
            Herencia.Empleado emp = new Herencia.Empleado();
            emp.Nombre = "Rafa";
            emp.Apellido = "Puig";
            emp.Salario = 1000;

            Persona p = emp; // Es posible hacer esto con herencia
            //p.Salario = 1200; //No se puede hacer con una refencia tipo Persona
        }       

    }
}

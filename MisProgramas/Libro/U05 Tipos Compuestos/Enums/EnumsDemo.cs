using System;

namespace Programacion.TiposCompuestos.Enums
{
    enum Sexo { Hombre, Mujer }

  
    [Flags]
    enum Botones
    {
        Ninguno = 0,
        Izquierdo = 0x1,
        Derecho = 0x2,
        //Todos = Izquierdo | Derecho
    }

    class EnumsDemo
    {
        static void Main()
        {
            EnumFlags();
        }

        static void EnumFlags()
        {
            Botones botones = Botones.Ninguno;
            Console.WriteLine(botones);
            botones = botones | Botones.Izquierdo;
            Console.WriteLine(botones);
            botones = botones | Botones.Derecho;
            Console.WriteLine(botones);

            //if (botones == Botones.Todos)
            //{
                
            //}

            if (botones == (Botones.Derecho | Botones.Izquierdo))
            {

            }

            if( Botones.Derecho == (botones & Botones.Derecho))
            {

            }

            if(Botones.Izquierdo==(botones& Botones.Izquierdo))
            {

            }

            Console.ReadKey();

        }
        static void SinEnums()
        {
            string sexo;

            sexo = "Hombre";
            //sexo = "Homber";

            if (sexo == "Hombre")            
                Console.WriteLine("Cromosomas XY");          
            else if(sexo == "Mujer")
                Console.WriteLine("Cromosomas XX");

            Console.WriteLine("El sexo es {0}", sexo);
        }

        static void ConEnums()
        {
            Sexo sexoPersona1 = Sexo.Hombre;

            if (sexoPersona1 == Sexo.Hombre)
                Console.WriteLine("Es un hombre, cromosomas XY");
            else
                Console.WriteLine("Es una mujer, cromosomas XX");

            Console.WriteLine("El sexo de la persona 1 es {0}", sexoPersona1);            
        }

        static void Enums1()
        {
            Sexo sexo = Sexo.Mujer;

            switch (sexo)
            {
                case Sexo.Hombre:
                    Console.WriteLine("Es un hombre");
                    break;
                case Sexo.Mujer:
                    Console.WriteLine("Es una mujer");
                    break;
            }            
        }           
    }
}

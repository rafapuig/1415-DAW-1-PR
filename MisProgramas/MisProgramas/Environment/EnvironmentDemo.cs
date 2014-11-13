using System;

namespace MisProgramas.Environment
{
    class EnvironmentDemo
    {
        static void Main()
        {
            Console.Title = "Demostracion de la clase System.Environment de .NET";
            //Console.BufferWidth = 30;
            Console.WindowWidth = Console.LargestWindowWidth - 15;

            Console.WriteLine(System.Environment.CommandLine);

            Console.WriteLine(System.Environment.CurrentDirectory);

            Console.WriteLine("Es un sistema de 64bits: " + System.Environment.Is64BitOperatingSystem);
            Console.WriteLine("Nombre NetBIOS del equipo: " + System.Environment.MachineName);
            Console.WriteLine("Directorio del sistema: " + System.Environment.SystemDirectory);

            string myVideosPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyVideos);
            Console.WriteLine(myVideosPath);

            string userProfilePath = System.Environment.GetFolderPath(
                                                            System.Environment.SpecialFolder.UserProfile,
                                                            System.Environment.SpecialFolderOption.None);

            Console.WriteLine(userProfilePath);

            //System.Environment.SetEnvironmentVariable("ZZZRAFAZZZ", "KK");
            //System.Environment.SetEnvironmentVariable("ZZZRAFAZZZ", string.Empty);




            //foreach(System.Collections.DictionaryEntry entry in System.Environment.GetEnvironmentVariables())
            //{
            //    Console.WriteLine("{0,-35} - {1}", entry.Key, entry.Value);

            //}

            System.Environment.GetEnvironmentVariable("windir");
            Console.ReadKey();
        }
    }
}

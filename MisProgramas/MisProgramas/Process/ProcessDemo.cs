using System;

namespace MisProgramas.Process
{
    class ProcessDemo
    {
        static void Main()
        {
            //System.Diagnostics.Process.Start("notepad.exe", "output.txt");

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c ipconfig /all",
                RedirectStandardOutput = true,
                UseShellExecute = false
            };

            System.Diagnostics.Process p = System.Diagnostics.Process.Start(psi);
            string result = p.StandardOutput.ReadToEnd();
            Console.WriteLine(result);

            System.IO.TextWriter writer = System.IO.File.CreateText("ipconfig.txt");
            writer.Write(result);
            writer.Close();

            System.Diagnostics.Process.Start("notepad.exe", "ipconfig.txt");

            Console.ReadKey();
        }
    }
}

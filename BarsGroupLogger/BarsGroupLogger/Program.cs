using System;

namespace BarsGroupLogger
{
    public class Program
    {
        static void Main(string[] args)
        {
            string logDir = @"E:\Projects\GitHub\BarsGroupLogger\logs\";

            LocalFileLogger<int> logInt = new LocalFileLogger<int>(logDir);
            LocalFileLogger<string> logString = new LocalFileLogger<string>(logDir);

            int x = 0;
            x =+ 10;
            logInt.LogInfo($"Added {x};");

            int y = 0;
            y =- 1;
            logInt.LogWarning($"Warning of {y}. It shouldn't be negative!;");

            int z = 1;
            string z1 = "Error";
            try
            {
                z = Convert.ToInt32(z1);
            }
            catch (Exception ex)
            {
                logInt.LogError($"Error of {z}!;", ex);
            }

            string a = "Hello World!";
            Console.WriteLine(a);
            logString.LogInfo($"Printed {a};");

            string b = "Привет Мир!";
            Console.WriteLine(b);
            logString.LogWarning($"Warning of {b}. Encoding isnt fully supported!;");

            char c1 = 'c';
            string c2 = "123";
            try
            {
                c1 = c2[4];
            }
            catch (Exception ex)
            {
                logString.LogError($"Error of {c2}!;", ex);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarsGroupLogger
{
    internal class LocalFileLogger<T> : ILogger
    {
        private string dir;
        public string GenericTypeName { get; set; } = typeof(T).Name;
        public LocalFileLogger(string dir)
        {
            this.dir = dir;
        }
        public void Print(string log)
        {
            StreamWriter sw = new StreamWriter(dir + "log.txt", true);
            sw.WriteLine(log);
            sw.Close();
        }

        public void LogInfo(string message)
        {
            Print($"[Info]: [{GenericTypeName}] : {message}");
        }
        public void LogWarning(string message)
        {
            Print($"[Warning]: [{GenericTypeName}] : {message}");
        }
        public void LogError(string message, Exception ex)
        {
            Print($"[Error]: [{GenericTypeName}] : {message}. {ex.Message}");
        }
    }
}

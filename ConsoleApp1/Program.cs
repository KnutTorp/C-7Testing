using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// C#7 by making it static we can use WriteLine() in stead of Console.WriteLine()
using static System.Console; 

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var runner = new Runner();
            runner.Run();
            runner.Run2();
        }
    }

    public class Runner
    {
        public void Run()
        {
            int hour;
            int minutes;
            int seconds;
            GetTime(out hour, out minutes, out seconds);
            WriteLine($"{hour}:{minutes}:{seconds}");
           
        }

        public void Run2()
        {
            //C#7 inline declaration of output variables
            GetTime(out var hour, out var minutes, out var seconds);
            WriteLine($"{hour}:{minutes}:{seconds}");
        }
        public void GetTime(out int hour, out int minutes, out int seconds)
        {
            hour = 1;
            minutes = 20;
            seconds = 46;
        }
    }
}

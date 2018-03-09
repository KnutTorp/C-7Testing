﻿using System;
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
            //runner.Run();
            //runner.Run2();
            //runner.PrintSum(10);
            //runner.PrintSum2(10);
            //runner.PrintSum2("10");
            runner.Run3();
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

        public void PrintSum(object o)
        {
            // constant pattern matching
            if (o is null) return;     
            // type pattern matching (int)
            if (!(o is int i)) return;

            int sum = 0;
            for (int j = 0; j <= i; j++)
            {
                sum += j;
            }
            WriteLine($"The sum of 1 to {i} is {sum}");
        }

        public void PrintSum2(object o)
        {
            if (o is int i || o is string s && int.TryParse(s, out i))
            {
                int sum = 0;
                for (int j = 0; j <= i; j++)
                {
                    sum += j;
                }
                WriteLine($"The sum of 1 to {i} is {sum}");
            }
        }

        public void Run3()
        {
            Employee theEmployee = new VicePresident
            {
                Salary = 160,
                Years = 7
            };
            //(theEmployee as Manager).NumberOfManaged = 3;
            (theEmployee as VicePresident).StockShares = 6000;
            (theEmployee as VicePresident).NumberOfManaged = 200;


            switch (theEmployee)
            {
                // conditional case statement
                case VicePresident vp when (vp.StockShares < 5000):
                    WriteLine($"Junior vice president with {vp.StockShares} shares");
                    break;
                case VicePresident vp when (vp.StockShares >= 5000):
                    WriteLine($"Senior vp with {vp.StockShares} shares");
                    break;
                case Manager m:
                    WriteLine($"Manager with {m.NumberOfManaged} reporting.");
                    break;
                case Employee e:
                    WriteLine($"Employee with salary:{e.Salary}");
                    break;
            }
        }
        public class Employee
        {
            public int Salary { get; set; }
            public int Years { get; set; }
        }
        public class Manager : Employee
        {
            public int NumberOfManaged { get; set; }
        }

        public class VicePresident : Manager
        {
            public int StockShares { get; set; }
        }
    }
}

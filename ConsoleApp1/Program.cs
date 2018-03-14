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
            //runner.MultipleOutputVariables();
            //runner.InlineDeclarationsOfOutputVariables();
            //runner.PrintSum(10);
            //runner.PrintSum2(10);
            //runner.PrintSum2("10");
            //runner.SwitchWithCondition();
            //runner.TupleTesting();
            runner.LocalFunctions();
        }
    }

    public class Runner
    {
        public void MultipleOutputVariables()
        {
            int hour;
            int minutes;
            int seconds;
            GetTime(out hour, out minutes, out seconds);
            WriteLine($"{hour}:{minutes}:{seconds}");
           
        }

        public void InlineDeclarationsOfOutputVariables()
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

        public void SwitchWithCondition()
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

        public void TupleTesting()
        {
            var time = GetTime();
            WriteLine($"The time is: {time.Item1}.{time.Item2}.{time.Item3}");

            var time2 = GetTime2();
            WriteLine($"The time is: {time2.hour}.{time2.minute}.{time2.seconds}");
            // deconstructed variable
            var (hour, minute, seconds) = GetTime2();
            WriteLine($"The time is: {hour}.{minute}.{seconds}");

            // Dictionary with a tuple as the key
            var tupleDictionary = new Dictionary<(int, int), string>
            {
                {(100, 20), "Your room is #20 on the 100th floor"},
                {(50, 10), "Your room is on the 50th floor, room #10"}
            };
            WriteLine(tupleDictionary[(50,10)]);


        }

        public (int, int, int) GetTime()
        {
            return (1, 30, 40); // Tuple literal
        }

        public (int hour, int minute, int seconds) GetTime2()
        {
            return (1, 30, 40); // Tuple literal
        }

        public void LocalFunctions()
        {
            // write the 7th number of the fibonacci sequence
            WriteLine(Fibonacci(7));
        }

        public int Fibonacci(int x)
        {
            if(x<0) throw new ArgumentException("Must be at least 0", nameof(x));
            return Fib(x).current;
           
            //Local function - recursive with output tuple
            (int current, int previous) Fib(int i)
            {
                if (i == 0) return(1, 0);
                var (current, previous) = Fib(i - 1);
                return (current + previous, current);
            }
        }
    }
}

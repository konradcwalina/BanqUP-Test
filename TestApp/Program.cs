using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TestApp.Abstract;
using TestApp.Enums;
using TestApp.Extensions;
using TestApp.Service;

namespace TestApp
{
    class Program
    {
        static Operators operators = new Operators();

        static void Main(string[] args)
        {
            string expression = "12+13/45*40";

            if (args != null && args.Any() && string.IsNullOrEmpty(args[0]))
            {
                expression = args[0];
            }

            Console.WriteLine(new CalculatorService().Calculate(expression));
        }

    }

}

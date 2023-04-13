using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace CalculatorApp
{
    class Program
    {
        static List<string> history = new List<string>();

        static double Add(double num1, double num2)
        {
            return num1 + num2;
        }

        static double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }

        static double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        static double Divide(double num1, double num2)
        {
            try
            {
                return num1 / num2;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error! Cannot divide by zero.");
                return 0;
            }
        }

        static double Power(double num1, double num2)
        {
            return Math.Pow(num1, num2);
        }

        static double Sqrt(double num)
        {
            return Math.Sqrt(num);
        }

        static double Log(double num)
        {
            return Math.Log10(num);
        }

        static double Percentage(double num, double percent)
        {
            return num * (percent / 100);
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please select operation:");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Subtract");
                Console.WriteLine("3. Multiply");
                Console.WriteLine("4. Divide");
                Console.WriteLine("5. Power");
                Console.WriteLine("6. Square Root");
                Console.WriteLine("7. Logarithm");
                Console.WriteLine("8. Percentage");
                Console.WriteLine("9. Delete last operation");
                Console.WriteLine("10. Show history");

                string choice = Console.ReadLine();

                if (choice == "9")
                {
                    if (history.Count > 0)
                    {
                        history.RemoveAt(history.Count - 1);
                        Console.WriteLine("Last operation deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Error! No operation available to delete.");
                    }
                    continue;
                }

                if (choice == "10")
                {
                    if (history.Count > 0)
                    {
                        Console.WriteLine("Calculation History:");
                        foreach (string op in history)
                        {
                            Console.WriteLine(op);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No calculation history found.");
                    }
                    continue;
                }

                Console.Write("Enter first number: ");
                double num1 = double.Parse(Console.ReadLine());

                double num2 = 0;

                if (choice != "6" && choice != "7")
                {
                    Console.Write("Enter second number: ");
                    num2 = double.Parse(Console.ReadLine());
                }

                double result = 0;
                string opStr = "";

                switch (choice)
                {
                    case "1":
                        result = Add(num1, num2);
                        opStr = num1 + " + " + num2;
                        break;
                    case "2":
                        result = Subtract(num1, num2);
                        opStr = num1 + " - " + num2;
                        break;
                    case "3":
                        result = Multiply(num1, num2);
                        opStr = num1 + " * " + num2;
                        break;
                    case "4":
                        result = Divide(num1, num2);
                        opStr = num1 + " / " + num2;
                        break;
                    case "5":
                        Console.Write("Enter power: ");
                        num2 = double.Parse(Console.ReadLine());
                        result = Power(num1, num2);
                        opStr = num1 + "^" + num2;
                        break;
                    case "6":
                        result = Sqrt(num1);
                        opStr = "sqrt(" + num1 + ")";
                        break;
                    case "7":
                        result = Log(num1);
                        opStr = "log(" + num1 + ")";
                        break;
                    case "8":
                        Console.Write("Enter percentage: ");
                        double percent = double.Parse(Console.ReadLine());
                        result = Percentage(num1, percent);
                        opStr = percent + "% of " + num1;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        continue;
                }

                Console.WriteLine(opStr + " = " + result);
                history.Add(opStr + " = " + result);
            }
        }
    }
}

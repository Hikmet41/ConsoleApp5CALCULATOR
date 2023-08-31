using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculator");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Mult");
            Console.WriteLine("3. Div");
            Console.WriteLine("4. Subst");

            selectedOperation = 1;

            Menu();

            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(intercept: true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        moveSelection(-1);
                        break;

                    case ConsoleKey.DownArrow:
                        moveSelection(1);
                        break;

                    case ConsoleKey.Enter:
                        if (Calculation())
                        {
                            Menu();
                        }
                        break;
                }
            } while (keyInfo.Key != ConsoleKey.Escape);
        }

   
        static int selectedOperation;

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Calculator");
            for (int i = 1; i <= 4; i++)
            {
                if (i == selectedOperation)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine($"{i}. {GetOperationName(i)}");

                Console.ResetColor();
            }
        }
        static void moveSelection(int direction)
        {
            if (direction == -1) 
            {
                
                selectedOperation = selectedOperation == 1 ? 4 : selectedOperation - 1;
            }
            else if (direction == 1) 
            {
               
                selectedOperation = selectedOperation == 4 ? 1 : selectedOperation + 1;
            }


            Menu();
        }

        static string GetOperationName(int operation)
        {
            switch (operation)
            {
                case 1:
                    return "Add";
                case 2:
                    return "Mult";
                case 3:
                    return "Div";
                case 4:
                    return "Subst";
                default:
                    return "";
            }
        }

        static bool Calculation()
        {
            Console.Clear();
            Console.Write("Birinci ededi daxil edin: ");
            double num1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("İkinci ededi daxil edin: ");
            double num2 = Convert.ToDouble(Console.ReadLine())
            double result = 0;
            string Symb = "";

            switch (selectedOperation)
            {
                case 1:
                    result = num1 + num2;
                    Symb = "+";
                    break;

                case 2:
                    result = num1 * num2;
                    Symb = "*";
                    break;

                case 3:
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        Symb = "/";
                    }
                    else
                    {
                        Console.WriteLine("0-a bolme erroru!");
                        return false;
                    }
                    break;

                case 4:
                    result = num1 - num2;
                    Symb = "-";
                    break;
            }

            Console.WriteLine($"Netice: {num1} {Symb} {num2} = {result}");
            Console.WriteLine("\nCixmaq esc-e basin, menuya qayitmaq ucun enter-a basin.");
            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }

            return true;
        }
    }
}
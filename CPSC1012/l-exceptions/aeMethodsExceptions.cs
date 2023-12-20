using System;

namespace MethodsExceptions
{
    
    #region
    public class App5
    {
        static void DisplayMenu()
        {
            //Console.Clear();
            Console.WriteLine("Math Quiz");
            Console.WriteLine("**********\n");
            Console.WriteLine("a) \tAddition Question");
            Console.WriteLine("s) \tSubtraction Question");
            Console.WriteLine("m) \tMultiplication Question");
            Console.WriteLine("d) \tDivision Question");
            Console.WriteLine("q) \tQuit");
        }
        static double Add(double a, double b)
        {
            return a + b;
        }
        static double Subtract(double a, double b)
        {
            return a - b;
        }
        static double Multiply(double a, double b)
        {
            return a * b;
        }
        static double Divide(double a, double b)
        {
            return a / b;
        }
        static char GetChoice()
        {
            Console.Write("Please enter a choice: ");
            char c = Char.ToLower(Char.Parse(Console.ReadLine()));
            switch (c)
            {
                case 'a':
                case 's':
                case 'm':
                case 'd':
                case 'q':
                    return c;

                default:
                    Console.WriteLine("Invalid Option.");
                    //Recursion
                    return GetChoice();
            }
        }
        static double DoThatMath(char c)
        {
            double a, b;
            Console.Write("Enter Number 1: ");
            a = double.Parse(Console.ReadLine());
            Console.Write("Enter Number 2: ");
            b = double.Parse(Console.ReadLine());
            if (c == 'a') return Add(a, b);
            if (c == 's') return Subtract(a, b);
            if (c == 'm') return Multiply(a, b);
            else return Divide(a, b);
        }
        public void App(string demoName)
        {
            Console.WriteLine($"{demoName} started");
            bool running = true;
            while (running)
            {
                DisplayMenu();
                char c = GetChoice();
                if (c == 'q')
                    running = false;
                else
                {
                    Console.WriteLine("Result is: " + DoThatMath(c));
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                }
            }
            Console.WriteLine("Goodbye!");
            Console.WriteLine($"{demoName} ended");
            Console.WriteLine("");
        }
    }
    #endregion
    #region
    public class App6
    {
        private int GetNumber(string prompt, int low, int high)
        {
            bool invalidInput = true;
            int num = 0;
            while (invalidInput)
            {
                Console.WriteLine($"{prompt} between {low} and {high}: ");
                num = int.Parse(Console.ReadLine());
                if (num >= low && num <= high)
                    invalidInput = false;
                else
                    Console.WriteLine("Error: Invalid Input.");
            }
            return num;
        }
        private char GetCharacter(string msg)
        {
            bool validInput = false;
            char c = 'c';
            while (!validInput)
            {
                Console.Write(msg);
                c = char.Parse(Console.ReadLine());
                validInput = true;
            }
            return c;
        }
        private void DrawBox(int rows, char drawChar)
        {
            for (int i = 1; i <= rows; i++)
            {
                DrawRow(rows, drawChar);
                Console.Write($"\n");
            }
        }
        private void DrawRow(int rows, char drawChar)
        {
            for(int i =1; i <= rows; i++)
            {
                Console.Write($"{drawChar}");
            }
        }
        public void App(string demoName)
        {
            Console.WriteLine($"{demoName} started");
            int num = GetNumber("Enter the number of rows", 1, 10);
            char c = GetCharacter("Enter a character to print: ");
            DrawBox(num, c);
            Console.WriteLine($"{demoName} ended");
            Console.WriteLine("");
        }
    }
    #endregion
    #region
    public class App7
    {
        private int GetNumber(string prompt, int low, int high)
        {
            bool invalidInput = true;
            int num = 0;
            while (invalidInput)
            {
                Console.WriteLine($"{prompt} between {low} and {high}: ");
                num = int.Parse(Console.ReadLine());
                if (num >= low && num <= high)
                    invalidInput = false;
                else
                    Console.WriteLine("Error: Invalid Input.");
            }
            return num;
        }
        private char GetCharacter(string msg)
        {
            bool validInput = false;
            char c = 'c';
            while (!validInput)
            {
                Console.Write(msg);
                c = char.Parse(Console.ReadLine());
                validInput = true;
            }
            return c;
        }
        private void DrawTriangle(int rows)
        {
            char c = '*';
            DrawTriangle(rows, c);
        }
        private void DrawTriangle(int rows, char drawChar)
        {
            for (int i = 1; i <= rows; i++)
                DrawRow(i, drawChar);
        }
        private void DrawRow(int len, char c)
        {
            for (int i = 0; i < len; i++)
                Console.Write(c);
            Console.Write("\n");
        }
        public void App(string demoName)
        {
            Console.WriteLine($"{demoName} started");
            int num = GetNumber("Enter the number of rows", 1, 10);
            char c = GetCharacter("Enter a character to print: ");
            Console.WriteLine("\nDefault");
            DrawTriangle(num);
            Console.WriteLine("\nCustom");
            DrawTriangle(num, c);
            Console.WriteLine($"{demoName} ended");
            Console.WriteLine("");
        }
    }
    #endregion
    #region
    public class App8
    {
        private int GetInt1(String msg)
        {
            bool inValidInput = true;
            int num = 0;
            while (inValidInput)
            {
                Console.Write(msg);
                num = int.Parse(Console.ReadLine());
                if (num > 0)
                    inValidInput = false;
                else
                    Console.WriteLine("Invalid. Must be bigger than zero.");
            }
            return num;
        }
        
        private int GetInt2(String msg)
        {
            bool inValidInput = true;
            int num = 0;
            while (inValidInput)
            {
                try
                {
                    Console.Write(msg);
                    num = int.Parse(Console.ReadLine());
                    if (num < 0)
                        throw new Exception("Must be bigger than zero.");
                    inValidInput = false; 
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Invalid: {ex.Message}");
                }
            }
            return num;
        }
        
        public void App(string demoName)
        {
            Console.WriteLine($"{demoName} started");
            int myInt1 = GetInt1($"GetInt1: Enter a + integer value: ");
            Console.WriteLine($"Congrats, you entered {myInt1}");
            int myInt2 = GetInt2($"GetInt2: Enter a + integer value: ");
            Console.WriteLine($"Congrats, you entered {myInt2}");
            Console.WriteLine($"{demoName} ended");
            Console.WriteLine("");
        }
    }
    #endregion
    #region
    public class App9
    {
        private string MyMethod(string name)
        {
            try
            {
                if(name == "robbin")
                    throw new ArgumentNullException($"Bad Name: {name}");
                if(name == "robbinl")
                    throw new FormatException($"Bad Name: {name}");
                if(name == "robbinlaw")
                    throw new FieldAccessException($"Bad Name: {name}");
                return $"MyMethod try: Good Name: {name}";
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"ArgumentNullException: {ex.Message}");
                return "ArgumentNullException";
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"FormatException: {ex.Message}");
                throw;
                //return "FormatException";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                //throw;
                //return "CatchAllException";
            }
            finally
            {
                Console.WriteLine("The finally runs exception or not");
                //can only have one finally per try
                //cannot have a return in finally
                //return "finally";
            }
            Console.WriteLine("This code will run if the catch does not have a return");
            Console.WriteLine("This code will also run if the try is successful and does not have a return");
            return "funny thing";  
        }
        public void App(string demoName)
        {
            try
            {
                Console.WriteLine($"{demoName} started");
                Console.Write($"Enter your name: ");
                string myName = Console.ReadLine();
                string returnedString = MyMethod(myName);
                Console.WriteLine($"App try: returned string: {returnedString}");
                Console.WriteLine($"{demoName} ended");
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in {demoName}: {ex.Message}");
            }
        }
    }
    #endregion
    #region
    public class App10
    {
        private double getNumber(string prompt, double low, double high)
        {
            double num = 0.0;
            bool invalidInput = true;
            while (invalidInput)
            {
                try
                {
                    Console.WriteLine($"{prompt} between {low:n1} and {high:n1}: ");
                    num = double.Parse(Console.ReadLine());
                    if (num < low || num > high)
                    {
                        throw new Exception("Invalid Input");
                    }
                    invalidInput = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
            return num;
        }
        private double circleArea(double radius)
        {
            double result = Math.PI * radius * radius;
            return result;
            // return (Math.PI * radius * radius);
        }
        private double circleCircumference(double radius)
        {
            return (2 * Math.PI * radius);
        }
        public void App(string demoName)
        {
            try
            {
                Console.WriteLine($"{demoName} started");
                double radius = getNumber("Enter Circle Radius", 2.0, 6.0);
                double areaCalc = circleArea(radius);
                Console.WriteLine($"The Circle Area is: {areaCalc:n2}");
                Console.WriteLine($"The Circle Area is: {circleArea(radius):n2}");
                Console.WriteLine($"The Circle Circumference is: {circleCircumference(radius):n2}");
                Console.WriteLine($"{demoName} ended");
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in {demoName}: {ex.Message}");
            }
        }
    }
    #endregion
    #region
    public class App11
    {
        public void App(string demoName)
        {
            try
            {
                Console.WriteLine($"{demoName} started");
                
                Console.WriteLine($"{demoName} ended");
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in {demoName}: {ex.Message}");
            }
        }
    }
    #endregion
    #region
    public class App12
    {
        public void App(string demoName)
        {
            try
            {
                Console.WriteLine($"{demoName} started");
                
                Console.WriteLine($"{demoName} ended");
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in {demoName}: {ex.Message}");
            }
        }
    }
    #endregion
}
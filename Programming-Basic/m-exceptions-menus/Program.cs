// Exceptions Demos

// 1-Try Catch Simple Demo
//Demo1();
// 2-Try Catch Finally
//Demo2();
// 3-Try Catch Circle Area and Circumference
//Demo3();
// 4-Try Simple Double Menu
Demo4();

void Demo1()
{
  int myInt1 = GetInt1($"GetInt1: Enter a integer value > : ", 4);
  Console.WriteLine($"Congrats, you entered {myInt1}");
  int myInt2 = GetInt2($"GetInt2: Enter a integer value > : ", 6);
  Console.WriteLine($"Congrats, you entered {myInt2}");

  int GetInt1(String msg, int min)
  {
    bool inValidInput = true;
    int num = 0;
    while (inValidInput)
    {
      Console.WriteLine(msg + min);
      num = int.Parse(Console.ReadLine());
      if (num > min)
        inValidInput = false;
      else
        Console.WriteLine($"Invalid. Must be > {min}.");
    }
    return num;
  }

  int GetInt2(String msg, int min)
  {
    bool inValidInput = true;
    int num = 0;
    while (inValidInput)
    {
      try
      {
        Console.WriteLine(msg + min);
        num = int.Parse(Console.ReadLine());
        if (num < min)
          throw new Exception($"Invalid. Must be > {min}.");
        inValidInput = false;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
    return num;
  }
}

void Demo2()
{
  try
  {
    Console.Write($"Enter your name: ");
    string myName = Console.ReadLine();
    string returnedString = MyMethod(myName);
    Console.WriteLine($"App try: returned string: {returnedString}");
  }
  catch (Exception example)
  {
    Console.WriteLine($"Exception {example.Message}");
  }

  string MyMethod(string name)
  {
    try
    {
      if (name == "robbin")
        throw new ArgumentNullException($"Bad Name: {name}");
      if (name == "robbinl")
        throw new FormatException($"Bad Name: {name}");
      if (name == "robbinlaw")
        throw new FieldAccessException($"Bad Name: {name}");
      //return $"MyMethod try: Good Name: {name}";
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
}

void Demo3()
{
  try
  {
    double radius = GetDoubleBetweenMinMax("Enter Circle Radius", 2.0, 6.0);
    double areaCalc = CircleArea(radius);
    Console.WriteLine($"The Circle Area is: {areaCalc:n2}");
    Console.WriteLine($"The Circle Area is: {CircleArea(radius):n2}");
    Console.WriteLine($"The Circle Circumference is: {CircleCircumference(radius):n2}");
  }
  catch (Exception ex)
  {
    Console.WriteLine($"Exception: {ex.Message}");
  }

  double GetDoubleBetweenMinMax(String msg, double min, double max)
  {
    bool inValidInput = true;
    double num = 0.0;
    while (inValidInput)
    {
      try
      {
        Console.Write($"{msg} between {min:n1} and {max:n1} inclusive: ");
        num = double.Parse(Console.ReadLine());
        if (num < min || num > max)
          throw new Exception($"Must be between {min:n1} and {max:n1}");
        inValidInput = false;
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Invalid: {ex.Message}");
      }
    }
    return num;
  }
  
  double CircleArea(double radius)
  {
    double result = Math.PI * radius * radius;
    return result;
    // return (Math.PI * radius * radius);
  }

  double CircleCircumference(double radius)
  {
    return (2 * Math.PI * radius);
  }
}

void Demo4()
{
  bool goAgain = true;
  while (goAgain)
  {
    try
    {
      DisplayMainMenu();
      string mainMenuChoice = Prompt("\nEnter a Main Menu Choice: ");
      if (mainMenuChoice == "P")
        Console.WriteLine("Hi There");
      if (mainMenuChoice == "D")
        Console.WriteLine("Hey This is Fun");
      if (mainMenuChoice == "Q")
      {
        goAgain = false;
        throw new Exception("Bye, hope to see you again.");
      }
      if (mainMenuChoice == "S")
      {
        while (true)
        {
          DisplaySecondaryMenu();
          string secondaryMenuChoice = Prompt("\nEnter a Secondary Menu Choice: ");
          if (secondaryMenuChoice == "A")
            AddNumbersAndPrint(2, 3);
          if (secondaryMenuChoice == "M")
            MultiplyNumbersAndPrint(5, 4);
          if (secondaryMenuChoice == "R")
            throw new Exception("Returning to Main Menu");
        }
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine($"{ex.Message}");
    }
  }

  void DisplayMainMenu()
  {
    Console.WriteLine("\nMain Menu");
    Console.WriteLine("P) Print: Hi There");
    Console.WriteLine("D) Display: Hey This is Fun");
    Console.WriteLine("S) Secondary Menu");
    Console.WriteLine("Q) Quit");
  }

  void DisplaySecondaryMenu()
  {
    Console.WriteLine("\nSecondary Menu");
    Console.WriteLine("A) Add 2 and 3 and print");
    Console.WriteLine("M) Multiply 5 and 4 and print");
    Console.WriteLine("R) Return to Main Menu");
  }

  string Prompt(string prompt)
  {
    string response = "";
    Console.Write(prompt);
    response = Console.ReadLine();
    return response.ToUpper();
  }

  void AddNumbersAndPrint(int num1, int num2)
  {
    Console.WriteLine($"The addition of {num1} and {num2} result: {num1 + num2}");
    //throw new Exception("BAD");
  }

  void MultiplyNumbersAndPrint(int num1, int num2)
  {
    Console.WriteLine($"The multiplication of {num1} and {num2} result: {num1 * num2}");
  }

}


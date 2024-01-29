// Exceptions Demos

// 1-Try Catch Simple Demo
Demo1();
// 2-Try Catch Finally
//Demo2();
// 3-Try Catch Circle Area and Circumference
//Demo3();

void Demo1()
{
  int myInt1 = GetInt1($"GetInt1: Enter a + integer value: ");
  Console.WriteLine($"Congrats, you entered {myInt1}");
  int myInt2 = GetInt2($"GetInt2: Enter a + integer value: ");
  Console.WriteLine($"Congrats, you entered {myInt2}");

  int GetInt1(String msg)
  {
    bool inValidInput = true;
    int num = 0;
    while (inValidInput)
    {
      Console.Write(msg);
      num = int.Parse(Console.ReadLine()!);
      if (num > 0)
        inValidInput = false;
      else
        Console.WriteLine("Invalid. Must be bigger than zero.");
    }
    return num;
  }

  int GetInt2(String msg)
  {
    bool inValidInput = true;
    int num = 0;
    while (inValidInput)
    {
      try
      {
        Console.Write(msg);
        num = int.Parse(Console.ReadLine()!);
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
}

void Demo2()
{
  try
  {
    Console.Write($"Enter your name: ");
    string myName = Console.ReadLine()!;
    string returnedString = MyMethod(myName);
    Console.WriteLine($"App try: returned string: {returnedString}");
  }
  catch (Exception ex)
  {
    Console.WriteLine($"Exception {ex.Message}");
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
}

void Demo3()
{
  try
  {
    double radius = getNumber("Enter Circle Radius", 2.0, 6.0);
    double areaCalc = circleArea(radius);
    Console.WriteLine($"The Circle Area is: {areaCalc:n2}");
    Console.WriteLine($"The Circle Area is: {circleArea(radius):n2}");
    Console.WriteLine($"The Circle Circumference is: {circleCircumference(radius):n2}");
  }
  catch (Exception ex)
  {
    Console.WriteLine($"Exception: {ex.Message}");
  }

  double getNumber(string prompt, double low, double high)
  {
    double num = 0.0;
    bool invalidInput = true;
    while (invalidInput)
    {
      try
      {
        Console.WriteLine($"{prompt} between {low:n1} and {high:n1}: ");
        num = double.Parse(Console.ReadLine()!);
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
  double circleArea(double radius)
  {
    double result = Math.PI * radius * radius;
    return result;
    // return (Math.PI * radius * radius);
  }
  double circleCircumference(double radius)
  {
    return (2 * Math.PI * radius);
  }
}
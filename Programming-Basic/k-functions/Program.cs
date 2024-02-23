// Functions Demos

// 1-Simple Demo
Demo1();
// 2-Simple Input Validation
//Demo2();
// 3-Circle Area and Circumference
//Demo3();
// 4-Equation of a Line
//Demo4();

void Demo1()
{
  int x;
  String s;
  printHello();
  printIt("fun", 2);
  x = add(2, 3);
  s = x.ToString();
  printIt(s, x);

  // simplest function with no parameters and no return
  void printHello()
  {
    Console.WriteLine($"Hello");
  }
  // intermediate function with input parameters but no return
  void printIt(String myString, int myInt)
  {
    Console.WriteLine($"Hey my string is: {myString}, and my int is {myInt.ToString()}");
  }
  // most complicated function with input parameters and a return value
  int add(int n1, int n2)
  {
    int mySum = n1 + n2;
    return mySum;
    //return n1 + n2;
  }
}

void Demo2()
{
  double windowWidth = getValue("Enter width of window in feet", 2.0, 6.0);
  Console.WriteLine($"Window Width: {windowWidth:n1} feet");
  double age = getValue("Enter your age in years", 0, 70);
  Console.WriteLine($"Your Age is: {age} years");
  int num = getNum("Enter a integer number", 0, 1000);
  Console.WriteLine($"The entered number is: {num}");
  int num1 = getNum1("Enter a integer number", 0, 1000);
  Console.WriteLine($"The entered number is: {num1}");
  int num2 = getNum2("Enter a integer number", 0, 1000);
  Console.WriteLine($"The entered number is: {num2}");

  double getValue(
    string prompt, // prompt for the user 
    double low,    // lowest allowed value
    double high    // highest allowed value
    )
  {
    double result;
    do
    {
      Console.WriteLine($"{prompt} between {low:n9} and {high:n1}:");
      string resultString = Console.ReadLine();
      result = double.Parse(resultString);
    } while ((result < low) || (result > high));
    return result;
  }

  int getNum(string prompt, int low, int high)
  {
    int num = low - 1;
    while ((num < low) || (num > high))
    {
      Console.WriteLine($"{prompt} between {low} and {high}:");
      string resultString = Console.ReadLine();
      num = int.Parse(resultString);
    }
    return num;
  }

  int getNum1(string prompt, int low, int high)
  {
    int num = low - 1;
    bool invalidInput = true;
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

  int getNum2(string prompt, int low, int high)
  {
    int num = low - 1;
    bool inValidInput = true;
    while (inValidInput)
    {
      Console.WriteLine($"{prompt} between {low} and {high}:");
      string resultString = Console.ReadLine();
      num = int.Parse(resultString);
      if ((num < low) || (num > high))
        Console.WriteLine($"Error: Invalid Input.");
      else
        inValidInput = false;
    }
    return num;
  }
}

void Demo3()
{
  double radius = getNumber("Enter Circle Radius", 2.0, 6.0);
  double areaCalc = circleArea(radius);
  Console.WriteLine($"The Circle Area is: {areaCalc:n2}");
  Console.WriteLine($"The Circle Area is: {circleArea(radius):n2}");
  Console.WriteLine($"The Circle Circumference is: {circleCircumference(radius):n2}");

  double getNumber(string prompt, double low, double high)
  {
    double num = 0;
    bool invalidInput = true;
    while (invalidInput)
    {
      Console.WriteLine($"{prompt} between {low:n1} and {high:n1}: ");
      num = double.Parse(Console.ReadLine());
      if (num >= low && num <= high)
        invalidInput = false;
      else
        Console.WriteLine("Error: Invalid Input.");
    }
    return num;
  }

  double circleArea(double radius)
  {
    return (Math.PI * radius * radius);
  }

  double circleCircumference(double radius)
  {
    return (2 * Math.PI * radius);
  }
}

void Demo4()
{
  int x1, x2, y1, y2;
  double slope, intercept;
  Console.WriteLine("please enter the X coordinate of the first point: ");
  x1 = int.Parse(Console.ReadLine());
  Console.WriteLine("please enter the X coordinate of the second point: ");
  x2 = int.Parse(Console.ReadLine());
  Console.WriteLine("please enter the Y coordinate of the first point: ");
  y1 = int.Parse(Console.ReadLine());
  Console.WriteLine("please enter the Y coordinate of the second point: ");
  y2 = int.Parse(Console.ReadLine());
  slope = compute_slope(x1, y1, x2, y2);
  intercept = compute_intercept(x1, y1, slope);
  Console.WriteLine($"The slope is {slope}, and the intercept is {intercept}");

  double compute_slope(int x1, int y1, int x2, int y2)
  {
    double slope;
    slope = (y2 - y1) / (x2 - x1);
    return slope;
    //return (y2 - y1) / (x2 - x1);
  }

  /* Calculates the Y intercept of the line. */
  double compute_intercept(int x1, int y1, double slope)
  {
    double intercept;
    intercept = y1 - slope * x1;
    return intercept;
    //return y1 - slope * x1;
  }
}


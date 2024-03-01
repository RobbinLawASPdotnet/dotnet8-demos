// Arrays Demos

// Demo-1-Arrays-Simple-Stormy
// Demo-2-Arrays with methods ave, min, max, sort

bool goAgain = true;
while (goAgain)
{
  try
  {
    DisplayMainMenu();
    string mainMenuChoice = Prompt("\nEnter a Main Menu Choice: ");
    if (mainMenuChoice == "D")
      Demo1();
    if (mainMenuChoice == "E")
      Demo2();
    if (mainMenuChoice == "Q")
    {
      goAgain = false;
      throw new Exception("Bye, hope to see you again soon.");
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
  Console.WriteLine("D) Run Demo1 - Arrays Intro and Storm Category");
  Console.WriteLine("E) Run Demo2 - Arrays with methods ave, min, max, sort");
  Console.WriteLine("Q) Quit");
}

string Prompt(string prompt)
{
  string response = "";
  Console.Write(prompt);
  response = Console.ReadLine();
  return response.ToUpper();
}

void Demo1()
{
  try
  {
    Console.WriteLine($"\nDemo1 - Arrays Intro and Storm Category");
    // char myChar = 'a';
    char[] myCharArray = ['c', 'd', 'e'];
    int[] myIntArray = [1, 2, 4, 7];
    int myDoubleArraySize = 2;
    double[] myDoubleArray = new double[myDoubleArraySize];
    myDoubleArray[0] = 55.3;
    myDoubleArray[1] = 88.3;
    for(int i = 0; i < myDoubleArray.Length; i++)
    {
      Console.WriteLine($"index: {i}; value: {myDoubleArray[i]}");
    }
    string[] stormStrength =
    [
      "No Hurricane. It's just windy yo.",
      "HURRICANE --- Category 1",
      "HURRICANE --- Category 2",
      "HURRICANE --- Category 3",
      "HURRICANE --- Category 4",
      "HURRICANE --- Category 5"
    ];
    int speed = GetPositiveInt("Enter Wind speed in mph as a + int: ");
    int stormLevel = 0;
    if (speed >= 74 && speed <= 95)
      stormLevel = 1;
    else if (speed >= 96 && speed <= 110)
      stormLevel = 2;
    else if (speed >= 111 && speed <= 130)
      stormLevel = 3;
    else if (speed >= 131 && speed <= 155)
      stormLevel = 4;
    else if (speed > 155)
      stormLevel = 5;
    string stormString = stormStrength[stormLevel];
    Console.WriteLine($"STORM LEVEL: {stormString}");
  }
  catch (Exception ex)
  {
    Console.WriteLine($"Exception in demo1: {ex.Message}");
  }
}

void Demo2()
{
  try
  {
    Console.WriteLine($"\nDemo2 - Arrays with methods ave, min, max, sort");
    int minSize = 0;
    int maxSize = 5;
    int size = GetIntBetweenMinMax($"Enter the number of items as an int between {minSize} and {maxSize}: ", minSize, maxSize);
    double[] numbers = new double[size];
    GetArrayItems(numbers);
    DisplayArrayItems(numbers, "Entered Numbers:");
    double avg = AverageValueOfArrayItems(numbers);
    Console.WriteLine($"The average value is: {avg}");
    double min = MinValueOfArrayItems(numbers);
    double max = MaxValueOfArrayItems(numbers);
    Console.WriteLine($"min: {min} max: {max}");
    // Sort array in ascending order.
    Array.Sort(numbers);
    DisplayArrayItems(numbers, "Sorted Ascending:");
    // reverse array to sort in descending order.
    Array.Reverse(numbers);
    DisplayArrayItems(numbers, "Sorted Descending");
  }
  catch (Exception ex)
  {
    Console.WriteLine($"Exception in demo2: {ex.Message}");
  }

  void GetArrayItems(double[] arr)
  {
    for (int i = 0; i < arr.Length; i++)
      arr[i] = GetDouble($"Enter next number as a double: ");
  }

  double AverageValueOfArrayItems(double[] arr)
  {
    double sum = 0;
    for (int i = 0; i < arr.Length; i++)
      sum += arr[i];
    return sum / arr.Length;
  }

  double MinValueOfArrayItems(double[] arr)
  {
    double min = arr[0];
      for (int i = 0; i < arr.Length; i++)
      {
        if (arr[i] < min)
          min = arr[i];
      }
      return min;
  }

  double MaxValueOfArrayItems(double[] arr)
  {
    double max = arr[0];
      for (int i = 0; i < arr.Length; i++)
      {
        if (arr[i] > max)
          max = arr[i];
      }
      return max;
  }

  void DisplayArrayItems(double[] arr, string msg)
  {
    Console.WriteLine(msg);
    for (int i = 0; i < arr.Length; i++)
      Console.Write($"{arr[i]} ");
    Console.WriteLine();
  }
}

// Functions used by all demos
string GetString(String msg)
{
  bool inValidInput = true;
  string str = "";
  while (inValidInput)
  {
    try
    {
      Console.Write(msg);
      str = Console.ReadLine();
      inValidInput = false; 
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Invalid: {ex.Message}");
    }
  }
  return str;
}

int GetPositiveInt(String msg)
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

int GetIntBetweenMinMax(String msg, int min, int max)
{
  bool inValidInput = true;
  int num = 0;
  while (inValidInput)
  {
    try
    {
      Console.Write($"{msg} between {min} and {max}: ");
      num = int.Parse(Console.ReadLine());
      if (num < min || num > max)
        throw new Exception($"Must be between {min} and {max}");
      inValidInput = false; 
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Invalid: {ex.Message}");
    }
  }
  return num;
}

double GetDouble(String msg)
{
  bool inValidInput = true;
  double num = 0;
  while (inValidInput)
  {
    try
    {
      Console.Write(msg);
      num = double.Parse(Console.ReadLine());
      inValidInput = false; 
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Invalid: {ex.Message}");
    }
  }
  return num;
}
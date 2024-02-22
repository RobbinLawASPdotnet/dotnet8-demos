// Arrays Demos

// Demo-1-Arrays-Simple-Stormy
Demo1();
// Demo-2-Arrays with methods ave, min, max, sort
//Demo2();
// Demo-3-Arrays vs Lists
//Demo3();


void Demo1()
{
  try
  {
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
    int minSize = 0;
    int maxSize = 100;
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

void Demo3()
{
  try
  {
    WithArrays();
    WithLists();
  }
  catch (Exception ex)
  {
    Console.WriteLine($"Exception in demo3: {ex.Message}");
  }

  void WithArrays()
  {
    Console.WriteLine("*** Using traditional arrays where size must be statically set at declaration ***");
    int studentCount = GetIntBetweenMinMax("How many students in your class? ", 0, 100);
    string[] studentNames = new string[studentCount];
    int[] studentGrades = new int[studentCount];
    for (int i = 0; i < studentCount; i++)
    {
      studentNames[i] = GetString("Student Name: ");
      studentGrades[i] = GetIntBetweenMinMax("Student Grade: ", 0, 100);
    }
    for (int i = 0; i < studentCount; i++)
    {
      Console.WriteLine($"Name: {studentNames[i]}, Grade: {studentGrades[i]}");
    }
  }

	void WithLists()
  {
    Console.WriteLine("*** Using dynamic arrays called lists where size is not set at declaration ***");
    List<string> studentNames = new List<string>();
    List<int> studentGrades = new List<int>();
    var adding = true;
    while(adding)
    {
      studentNames.Add(GetString("Student Name: "));
      studentGrades.Add(GetIntBetweenMinMax("Student Grade: ", 0, 100));
      if (GetString("Add another? y/n: ") == "n")
        adding = false;
    }
    for (int i = 0; i < studentNames.Count; i++)
    {
      Console.WriteLine($"Name: {studentNames[i]}, Grade: {studentGrades[i]}");
    }
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
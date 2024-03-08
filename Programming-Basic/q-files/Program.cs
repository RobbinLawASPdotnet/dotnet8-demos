
// Files Demos

// Demo-1-Writing to a file with arrays
//Demo1();
// Demo-2-Reading from a file with arrays
Demo2();
// Demo-3-Write and Read csv files with parallel arrays
//Demo3();

void Demo1()
{
  try
  {
    const string csvFileName = "Data.dat";
    int arraySize = 10;
    string[] csvLines = new string[arraySize];
    csvLines[0] = "first,line,of,array,csv";
    csvLines[1] = "second,line,of,array,csv";
    csvLines[9] = "hi";
    File.WriteAllLines(csvFileName, csvLines);
    Console.WriteLine($"Data successfully written to file at: {Path.GetFullPath(csvFileName)}");
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
    const string csvFileName = "Data.dat";
    string[] csvFileInput = File.ReadAllLines(csvFileName);
    for(int i = 0; i < csvFileInput.Length; i++)
    {
      Console.WriteLine($"lineIndex: {i}; line: {csvFileInput[i]}");
      string[] items = csvFileInput[i].Split(',');
      for(int j = 0; j < items.Length; j++)
      {
        Console.WriteLine($"itemIndex: {j}; item: {items[j]}");
      }
      Console.WriteLine();
    }
  }
  catch (Exception ex)
  {
    Console.WriteLine($"Exception in demo2: {ex.Message}");
  }
}

void Demo3()
{
  try
  {
    int studentCount = GetIntBetweenMinMax("How many students in your class as an int", 0, 100);
    string[] studentNames = new string[studentCount];
    int[] studentGrades = new int[studentCount];
    LoadArraysAndStoreInCSVFile(studentNames, studentGrades, studentCount);
    ReadInCSVFileAndDisplay(studentNames, studentGrades, studentCount);
  }
  catch (Exception ex)
  {
    Console.WriteLine($"Exception in demo3: {ex.Message}");
  }

  const string csvFileName = "StudentData.dat";
	void LoadArraysAndStoreInCSVFile(string[] studentNames, int[] studentGrades, int size)
  {
    //Load the arrays with valid values.
    for (int i = 0; i < size; i++)
    {
      studentNames[i] = GetString("Student Name: ");
      studentGrades[i] = GetIntBetweenMinMax("Student Grade as an int", 0, 100);
    }
    //Create one array using the csv (comma separated values) 
    //info from the two parallel arrays.
    string[] csvLines1 = new string[size];
    for (int i = 0; i < size; i++)
    {
      csvLines1[i] = $"{studentNames[i]},{studentGrades[i].ToString()}";
    }
    //Write the one array to a csv file line by line (each line is an element in the array).
    File.WriteAllLines(csvFileName, csvLines1);
  }

	void ReadInCSVFileAndDisplay(string[] studentNames, int[] studentGrades, int size)
  {
    //Read each line of the file into the elements of one array.
    string[] csvFileInput = File.ReadAllLines(csvFileName);
    //Traverse the elements of the array and for each split the string
    //using the delimiter character as the split point.
    for(int i = 0; i < csvFileInput.Length; i++)
    {
      string[] items = csvFileInput[i].Split(',');
      studentNames[i] = items[0];
      studentGrades[i] = int.Parse(items[1]);
    }
    //Print the studentName and studentGrades info to the terminal.
    for (int i = 0; i < size; i++)
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
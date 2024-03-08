
// TODO: declare a constant to represent the max size of the values
// and dates arrays. The arrays must be large enough to store
// values for an entire month.
int physicalSize = 31;
int logicalSize = 0;

// TODO: create a double array named 'values', use the max size constant you declared
// above to specify the physical size of the array.
double[] values = new double[physicalSize];

// TODO: create a string array named 'dates', use the max size constant you declared
// above to specify the physical size of the array.
string[] dates = new string[physicalSize];

string fileName = "";

bool goAgain = true;
  while (goAgain)
  {
    try
    {
      DisplayMainMenu();
      string mainMenuChoice = Prompt("\nEnter a Main Menu Choice: ").ToUpper();
      if (mainMenuChoice == "L")
        logicalSize = LoadFileValuesToMemory(fileName, dates, values);
      if (mainMenuChoice == "S")
        SaveMemoryValuesToFile(fileName, dates, values, logicalSize);
      if (mainMenuChoice == "D")
        DisplayMemoryValues(dates, values, logicalSize);
      if (mainMenuChoice == "A")
        logicalSize = AddMemoryValues(dates, values, logicalSize);
      if (mainMenuChoice == "E")
        EditMemoryValues(dates, values, logicalSize);
      if (mainMenuChoice == "Q")
      {
        goAgain = false;
        throw new Exception("Bye, hope to see you again.");
      }
      if (mainMenuChoice == "R")
      {
        while (true)
        {
          if (logicalSize == 0)
					  throw new Exception("No entries loaded. Please load a file into memory");
          DisplayAnalysisMenu();
          string analysisMenuChoice = Prompt("\nEnter an Analysis Menu Choice: ").ToUpper();
          if (analysisMenuChoice == "A")
            FindAverageOfValuesInMemory(values, logicalSize);
          if (analysisMenuChoice == "H")
            FindHighestValueInMemory(values, logicalSize);
          if (analysisMenuChoice == "L")
            FindLowestValueInMemory(values, logicalSize);
          if (analysisMenuChoice == "G")
            GraphValuesInMemory(dates, values, logicalSize);
          if (analysisMenuChoice == "R")
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
	Console.WriteLine("L) Load Values from File to Memory");
	Console.WriteLine("S) Save Values from Memory to File");
	Console.WriteLine("D) Display Values in Memory");
	Console.WriteLine("A) Add Value in Memory");
	Console.WriteLine("E) Edit Value in Memory");
	Console.WriteLine("R) Analysis Menu");
	Console.WriteLine("Q) Quit");
}

void DisplayAnalysisMenu()
{
	Console.WriteLine("\nAnalysis Menu");
	Console.WriteLine("A) Find Average of Values in Memory");
	Console.WriteLine("H) Find Highest Value in Memory");
	Console.WriteLine("L) Find Lowest Value in Memory");
	Console.WriteLine("G) Graph Values in Memory");
	Console.WriteLine("R) Return to Main Menu");
}

string Prompt(string prompt)
{
  string response = "";
  Console.Write(prompt);
  response = Console.ReadLine();
  return response;
}

string GetFileName()
{
	string fileName = "";
	do
	{
		fileName = Prompt("Enter file name including .csv or .txt: ");
	} while (string.IsNullOrWhiteSpace(fileName));
	return fileName;
}

int LoadFileValuesToMemory(string filename, string[] dates, double[] values)
{
	string fileName = GetFileName();
	int logicalSize = 0;
	string filePath = $"./data/{fileName}";
	if (!File.Exists(filePath))
		throw new Exception($"The file {fileName} does not exist.");
	string[] csvFileInput = File.ReadAllLines(filePath);
	for(int i = 0; i < csvFileInput.Length; i++)
	{
		Console.WriteLine($"lineIndex: {i}; line: {csvFileInput[i]}");
		string[] items = csvFileInput[i].Split(',');
		for(int j = 0; j < items.Length; j++)
		{
			Console.WriteLine($"itemIndex: {j}; item: {items[j]}");
		}
		if(i != 0)
		{
		dates[logicalSize] = items[0];
    values[logicalSize] = double.Parse(items[1]);
    logicalSize++;
		}
	}
  Console.WriteLine($"Load complete. {fileName} has {logicalSize} data entries");
	return logicalSize;
}

void DisplayMemoryValues(string[] dates, double[] values, int logicalSize)
{
	if(logicalSize == 0)
		throw new Exception($"No Entries loaded. Please load a file to memory or add a value in memory");
	Console.Clear();
	Console.WriteLine($"\nCurrent Loaded Entries:  {logicalSize}\n");
	Console.WriteLine("{0,-15} {1,10:}\n", "Date", "Value");
	for (int i = 0; i < logicalSize; i++)
	{
		Console.WriteLine("{0,-15} {1,10:}", dates[i], values[i]);
	}
}

double FindHighestValueInMemory(double[] values, int logicalSize)
{
	Console.WriteLine("Not Implemented Yet");
	return 0;
	//TODO: Replace this code with yours to implement this function.
}

double FindLowestValueInMemory(double[] values, int logicalSize)
{
	Console.WriteLine("Not Implemented Yet");
	return 0;
	//TODO: Replace this code with yours to implement this function.
}

void FindAverageOfValuesInMemory(double[] values, int logicalSize)
{
	Console.WriteLine("Not Implemented Yet");
	//TODO: Replace this code with yours to implement this function.
}

void SaveMemoryValuesToFile(string filename, string[] dates, double[] values, int logicalSize)
{
	Console.WriteLine("Not Implemented Yet");
	//TODO: Replace this code with yours to implement this function.
}

int AddMemoryValues(string[] dates, double[] values, int logicalSize)
{
	Console.WriteLine("Not Implemented Yet");
	return 0;
	//TODO: Replace this code with yours to implement this function.
}

void EditMemoryValues(string[] dates, double[] values, int logicalSize)
{
	Console.WriteLine("Not Implemented Yet");
	//TODO: Replace this code with yours to implement this function.
}

void GraphValuesInMemory(string[] dates, double[] values, int logicalSize)
{
	Console.WriteLine("Not Implemented Yet");
	//TODO: Replace this code with yours to implement this function.
}
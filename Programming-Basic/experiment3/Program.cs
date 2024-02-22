
int physicalSize = 31;
int logicalSize = 0;

string[] dates = new string[physicalSize];
double[] values = new double[physicalSize];
string fileName = "";

while (true)
{
	try
	{
		if (string.IsNullOrWhiteSpace(fileName))
			fileName = GetFileName();
		DisplayMainMenu();
		string mainMenuChoice = Prompt("\nEnter a Main Menu Choice: ").ToUpper();
		if (mainMenuChoice == "L")
			logicalSize = LoadLogFile(fileName, dates, values);
		if (mainMenuChoice == "S")
			SaveLogFile(fileName, dates, values, logicalSize);
		if (mainMenuChoice == "D")
			DisplayLogEntries(dates, values, logicalSize);
		if (mainMenuChoice == "A")
			logicalSize = EnterLogEntries(dates, values, logicalSize);
		if (mainMenuChoice == "E")
			EditLogEntries(dates, values, logicalSize);
		if (mainMenuChoice == "Q")
			System.Environment.Exit(0);
		if (mainMenuChoice == "R")
		{
			while (true)
			{
				if (logicalSize == 0)
					throw new Exception("No entries loaded.");
				DisplayAnalysisMenu();
				string analysisMenuChoice = Prompt("\nEnter an Analysis Menu Choice: ").ToUpper();
				if (analysisMenuChoice == "A")
					FindMeanAverage(values, logicalSize);
				if (analysisMenuChoice == "H")
					FindHighestValue(values, logicalSize);
				if (analysisMenuChoice == "L")
					FindLowestValue(values, logicalSize);
				if (analysisMenuChoice == "M")
					FindMedian(values, logicalSize);
				if (analysisMenuChoice == "C")
					DisplayChart(dates, values, logicalSize);
				if (analysisMenuChoice == "R")
					throw new Exception("Returning to Main Menu");
			}
		}
	}
	catch (Exception ex)
	{
		Console.WriteLine($"Exception: {ex.Message}");
	}
}

string GetFileName()
{
	string fileName = "";
	do
	{
		fileName = Prompt("\nEnter the working file name: ");
	} while (string.IsNullOrWhiteSpace(fileName));
	Console.WriteLine($"Working file: {fileName}");
	return fileName;
}

void DisplayMainMenu()
{
	Console.WriteLine("\nMain Menu");
	Console.WriteLine("L) Load File");
	Console.WriteLine("S) Save File");
	Console.WriteLine("D) Display Entries");
	Console.WriteLine("A) Add Entry");
	Console.WriteLine("E) Edit Entry");
	Console.WriteLine("R) Analysis Menu");
	Console.WriteLine("Q) Quit");
}

void DisplayAnalysisMenu()
{
	Console.WriteLine("\nAnalysis Menu");
	Console.WriteLine("A) Mean Average");
	Console.WriteLine("H) Highest Entry");
	Console.WriteLine("L) Lowest Entry");
	Console.WriteLine("M) Median");
	Console.WriteLine("C) Chart Entries");
	Console.WriteLine("R) Return to Main Menu");
}

string Prompt(string prompt)
{
	string response = "";
	Console.Write(prompt);
	response = Console.ReadLine();
	return response;
}

double PromptDouble(string prompt)
{
	string response = "";
	double phValue = 0;
	bool valid = false;
	do
	{
		Console.Write(prompt);
		response = Console.ReadLine();
		if (double.TryParse(response, out phValue))
			valid = true;
		else
			Console.WriteLine($"{response} is not a valid. Try again.");
	} while (!valid);
	return phValue;
}

int LoadLogFile(string filename, string[] dates, double[] values)
{
	int logicalSize = 0;
	string line = "";
	StreamReader reader;
	string filePath = $"./data/{filename}";
	if (!File.Exists(filePath))
		throw new Exception($"The file {filename} does not exist.");
	if (File.Exists(filePath))
	{
		reader = new StreamReader(filePath);
		line = reader.ReadLine();
		while (!reader.EndOfStream)
		{
			line = reader.ReadLine();
			string[] recordData = line.Split(',');
			dates[logicalSize] = recordData[0];
			values[logicalSize] = double.Parse(recordData[1]);
			logicalSize++;
		}
		reader.Close();
		Console.WriteLine($"\n\tLoad complete. Working file {fileName} has {logicalSize} entries");
	}
	return logicalSize;
}

void SaveLogFile(string filename, string[] dates, double[] values, int logicalSize)
{
	StreamWriter writer;
	string filePath = $"./data/{filename}";
	if (logicalSize > 1)
	{
		Array.Sort(dates, values, 0, logicalSize);
	}
	writer = new StreamWriter(filePath);
	writer.WriteLine("Dates,values");
	for (int i = 0; i < logicalSize; i++)
	{
		writer.WriteLine($"{dates[i]},{values[i]}");
	}
	writer.Close();
	Console.WriteLine($"\n\tSave complete.  Working file {fileName} with {logicalSize} entries.\n");
}

void DisplayLogEntries(string[] dates, double[] values, int logicalSize)
{
	if(logicalSize == 0)
		throw new Exception($"No Entries loaded.");
	Console.Clear();
	Console.WriteLine($"\nCurrent Loaded Entries:  {logicalSize}\n");
	Console.WriteLine("{0,-15} {1,10:}\n", "Date", "Value");
	for (int i = 0; i < logicalSize; i++)
	{
		Console.WriteLine("{0,-15} {1,10:}", dates[i], values[i]);
	}
}

int EnterLogEntries(string[] dates, double[] values, int logicalSize)
{
	bool valid = false;
	DateTime entryDate = DateTime.Today;
	double value = 0.0;
	string continueEntry = "N";
	string dateString = "";
	do
	{
		continueEntry = Prompt("\tMake a value entry? (Y or N)");
		if (continueEntry.ToUpper().Equals("Y"))
		{
			do
			{
				dateString = Prompt("\tEnter journal entry date: format mm-dd-yyyy (eg 11-23-2023):\t");
				if (DateTime.TryParse(dateString, out entryDate))
				{
					valid = true;
				}
				else
				{
					Console.WriteLine($"\n\t>{dateString}< is not a valid date. Try again.\n ");
				}
			} while (!valid);
			valid = false;
			do
			{
				value = PromptDouble($"\tEnter the value for {dateString}:\t");
				if (value >= 0 && value <= 14)
				{
					valid = true;
				}
				else
				{
					Console.WriteLine($"\n\t>{value}< is not a valid value (0-14). Try again.\n ");
				}
			} while (!valid);
			bool found = false;
			for (int i = 0; i < logicalSize; i++)
			{
				if (dates[i].Equals(dateString))
				{
					found = true;
				}
			}
			if (!found)
			{
				dates[logicalSize] = entryDate.ToString("MM-dd-yyyy");
				values[logicalSize] = value;
				logicalSize++;
			}
			else
			{
				Console.WriteLine($"\n\t>{dateString}< is already on journal. Edit entry instead.\n ");
			}
		}
		else
		{
			if (!continueEntry.ToUpper().Equals("N"))
			{
				Console.WriteLine("\tInvalid entry. Try again");
			}
		}
	} while (!continueEntry.ToUpper().Equals("N"));
	Console.WriteLine($"\nWorking file has {logicalSize} entries.");
	Console.WriteLine($"You must save the working file to retain the data.\n");
	return logicalSize;
}

void EditLogEntries(string[] dates, double[] values, int logicalSize)
{
	Array.Sort(dates, values, 0, logicalSize);
	bool editDone = false;
	string editYesNo = "N";
	bool validAnswer = false;
	string editDateString = "";
	DateTime editDate = DateTime.Today;
	bool found = false;
	int editIndex = 0;
	bool valid = false;
	double value = 0;
	if(logicalSize == 0)
		throw new Exception($"No Entries loaded.");
	while (!editDone)
	{
		Console.WriteLine("Current journal entries. Choose entry to edit by date:\n");
		DisplayLogEntries(dates, values, logicalSize);
		do
		{
			editYesNo = Prompt("\nEdit an entry (Y or N):\t");
			if (editYesNo.ToUpper().Equals("Y") || editYesNo.ToUpper().Equals("N"))
				validAnswer = true;
			else
				Console.WriteLine("Please respond with Y or N. Try again:\n");
		} while (!validAnswer);
		if (editYesNo.ToUpper().Equals("Y"))
		{
			editDateString = Prompt("\nEnter log entry date (mm-dd-yyyy):\t");
			if (DateTime.TryParse(editDateString, out editDate))
			{
				found = false;
				for (int i = 0; i < logicalSize || !found; i++)
				{
					if (dates[i].Equals(editDateString.Trim()))
					{
						editIndex = i;
						found = true;
					}
				}
				if (found)
				{
					valid = false;
					do
					{
						value = PromptDouble($"\tEnter the new ph value for entry:\t");
						if (value >= 0 && value <= 14)
							valid = true;
						else
							Console.WriteLine($"\n\t>{value}< is not a valid value (0-14). Try again.\n ");
					} while (!valid);
					values[editIndex] = value;
					Console.WriteLine($"\n\t>Entry updated.\n ");
				}
				else
					Console.WriteLine("Entry date does not exist. Try again:\n");
			}
			else
				Console.WriteLine("Entry not a valid date. Try again:\n");
		}
		else
			editDone = true;
	}
}

double FindHighestValue(double[] values, int logicalSize)
{
	double highest = 0;
	if (logicalSize == 0)
		throw new Exception("No entries in the active current journal.");
	if (logicalSize == 1)
		highest = values[0];
	else
	{
		highest = values[0];
		for (int i = 1; i < logicalSize; i++)
		{
			if (values[i] > highest)
				highest = values[i];
		}
	}
	Console.WriteLine($"\n\tThe highest value is {highest}.\n");
	return highest;
}

double FindLowestValue(double[] values, int logicalSize)
{
	double lowest = 0;
	if (logicalSize == 0)
		throw new Exception("No entries in the active current journal.");
	if (logicalSize == 1)
		lowest = values[0];
	else
	{
		lowest = values[0];
		for (int i = 1; i < logicalSize; i++)
		{
			if (values[i] < lowest)
			{
				lowest = values[i];
			}
		}
	}
	Console.WriteLine($"\n\tThe lowest value is {lowest}.\n");
	return lowest;
}

void FindMeanAverage(double[] values, int logicalSize)
{
	double total = 0;
	double average = 0;
	if (logicalSize == 0)
		throw new Exception("No entries in the active current journal.");
	if (logicalSize == 1)
	{
		total = values[0];
	}
	else
	{
		for (int i = 0; i < logicalSize; i++)
		{
			total += values[i];
		}
	}
	average = total / (double)logicalSize;
	Console.WriteLine($"\n\tThe average is {average}.\n");
}

void FindMedian(double[] values, int logicalSize)
{
	double median = 0;
	if (logicalSize == 0)
		throw new Exception("No entries loaded.");
	if (logicalSize == 1)
	{
		median = values[0];
	}
	else
	{
		// Need to maintain original order so make a copy of the array
		// and work with the copy
		double[] medianCopy = new double[logicalSize];

		for (int i = 0; i < logicalSize; i++)
		{
			medianCopy[i] = values[i];
		}
		Array.Sort(medianCopy);
		if (logicalSize % 2 == 0)
		{
			// Average two middle values
			double middle1phValue = medianCopy[(logicalSize / 2) - 1];
			double middle2phValue = medianCopy[(logicalSize / 2)];
			median = (middle1phValue + middle2phValue) / 2.0;
		}
		else
		{
			// Odd number of entries, take middle value
			median = medianCopy[(logicalSize / 2)];
		}
	}
	Console.WriteLine($"\n\tThe median is {median}.\n");
}

void DisplayChart(string[] dates, double[] values, int logicalSize)
{
	Console.WriteLine($"LogicalSize: {logicalSize}");
	// Create a 2 D array to represent the chart
	double valuesHighest = FindHighestValue(values, logicalSize);
	double valuesLowest = FindLowestValue(values, logicalSize);
	int valueSpread = 1;
	if (logicalSize == 0)
		throw new Exception("No entries loaded.");
	if (logicalSize == 1 || valuesHighest == valuesLowest)
		// Only one row of values
		valueSpread = 1;
	else
		// Minimum 2 rows of values
		valueSpread = (int)((valuesHighest - valuesLowest) * 10.0) + 1;
	// Create 2D array
	int rows = valueSpread + 4;
	string[,] chartDisplay = new string[rows, 32];
	//set Chart to blank spaces
	for (int row = 0; row < rows; row++)
	{
		chartDisplay[row, 0] = "     ";
		for (int col = 1; col < 32; col++)
			chartDisplay[row, col] = "   ";
	}
	// Create Y axis
	chartDisplay[0, 0] = "  val ";
	chartDisplay[1, 0] = "-----";
	for (int i = 0; i < valueSpread; i++)
	{
		if (valuesHighest > 9.9)
			chartDisplay[2 + i, 0] = $"{valuesHighest:00.0}|";
		else
			chartDisplay[2 + i, 0] = $" {valuesHighest:0.0}|";
		valuesHighest -= 0.1;
	}
	chartDisplay[valueSpread + 2, 0] = "-----";
	chartDisplay[valueSpread + 3, 0] = " Day|";
	// Create x axis
	string month = dates[0].Substring(0, 2);
	int xAxisDays = 0;
	if (month.Equals("02"))
		xAxisDays = 28;
	else if (month.Equals("01") || month.Equals("03") || month.Equals("05") || month.Equals("07") ||
				month.Equals("08") || month.Equals("10") || month.Equals("12"))
		xAxisDays = 31;
	else
		xAxisDays = 30;
	for (int i = 1; i <= xAxisDays; i++)
	{
		chartDisplay[valueSpread + 2, i] = "---";
		chartDisplay[valueSpread + 3, i] = $"{i:00} ";
	}
	// Load chartDisplay with * depending on entry
	int xAxisIndex = 0;
	int yAxisIndex = 0;
	string value = "";
	for (int i = 0; i < logicalSize; i++)
	{
		// Determine x axis index
		xAxisIndex = int.Parse(dates[i].Substring(3, 2));
		// Determine y axis index
		if (values[i] < 10)
			value = $" {values[i]}|";
		else
			value = $" {values[i]}|";
		for (int y = 2; y < rows - 2; y++)
		{
			if (chartDisplay[y, 0].Equals(value))
				yAxisIndex = y;
		}
		chartDisplay[yAxisIndex, xAxisIndex] = " * ";
	}
	// Display Chart
	for (int row = 0; row < rows; row++)
	{
		Console.Write($"\n{chartDisplay[row, 0]}");
		for (int col = 0; col < xAxisDays; col++)
			Console.Write(chartDisplay[row, col + 1]);
	}
}
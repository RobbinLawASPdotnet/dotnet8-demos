using System;
using System.Collections.Generic;
using System.IO;

namespace Objects
{
	public class Demo5
	{
		public void RunDemo(string demoName)
		{
			try
			{
				Console.WriteLine($"{demoName} STARTED");
				const string csvFileName = "StudentDataBad.dat";
				List<StudentInfoWithFullProperties> students = new();
				//read the csv file and each line becomes a new student added to the list.
				string[] csvFileInput = File.ReadAllLines(csvFileName);
				StudentInfoWithFullProperties student = null;
				//each line read from the file is a string that now has to be parsed into different types.
				foreach(string line in csvFileInput)
				{
					try
					{
					bool returnedBool = StudentInfoWithFullProperties.TryParse(line, out student);
					//This line of code is here only to show that the bool is always returned.
					Console.WriteLine($"returnedBool is: {returnedBool} for: {line}");
					if(returnedBool != false && student != null)
						students.Add(student);
					}
					catch (Exception ex)
					{
						Console.WriteLine($"Exception (App foreach catch): {ex.Message}");
					}    
				}
				foreach (var item in students)
					Console.WriteLine(item.ToString());
				Console.WriteLine($"{demoName} ENDED");
				Console.WriteLine("");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception in {demoName}: {ex.Message}");
			}
		}
	}
}
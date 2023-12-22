using System;
using System.Collections.Generic;
using System.IO;

namespace Objects
{
	public class Demo4
	{
		public void RunDemo(string demoName)
		{
			try
			{
				Console.WriteLine($"{demoName} STARTED");
				const string csvFileName = "StudentDataGood.dat";
				List<StudentInfoWithFullProperties> students = new();
				students.Add(new StudentInfoWithFullProperties("Charles", 55));
				students.Add(new StudentInfoWithFullProperties("Jimmy", 45));
				students.Add(new StudentInfoWithFullProperties("Jill", 99));
				students.Add(new StudentInfoWithFullProperties("John", 88));
				students.Add(new StudentInfoWithFullProperties("James", 77));
				students.Add(new StudentInfoWithFullProperties("Robbin", 22));
				List<string> csvLines = new();
				foreach (var item in students)
					csvLines.Add(item.ToString());
				//write to a csv file. requires using System.IO    
				File.WriteAllLines(csvFileName, csvLines);
				Console.WriteLine($"Data successfully written to file at: {Path.GetFullPath(csvFileName)}");
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
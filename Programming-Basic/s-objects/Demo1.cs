using System;
using System.Collections.Generic;
using System.IO;

namespace Objects
{
	public class Demo1
	{
		private void WithArrayOfObjects()
		{
			int studentCount = CommonMethods.GetIntBetweenMinMax("How many students in your class? ", 0, 100);
			StudentInfoWithFields[] students = new StudentInfoWithFields[studentCount];
			string studentName;
			int studentGrade;
			for (int i = 0; i < students.Length; i++)
			{
				try
				{
					studentName = CommonMethods.GetString($"Student Name {i}: ");
					studentGrade = CommonMethods.GetIntBetweenMinMax($"Student Grade {i}: ", 0, 100);
					students[i] = new StudentInfoWithFields(studentName, studentGrade);
				}
				catch (Exception e)
				{
					Console.WriteLine($"Exception: {e.Message}");
					i--;
				}
				
			}
			for (int i = 0; i < students.Length; i++)
			{
				Console.WriteLine($"Name {i}: {students[i].StudentName}, Grade: {students[i].StudentGrade}");
			}
		}
		private void WithListOfObjects()
		{
			List<StudentInfoWithFields> students = new List<StudentInfoWithFields>();
			string studentName;
			int studentGrade;
			bool adding = true;
			int i = 0;
			while(adding)
			{
				try
				{
					studentName = CommonMethods.GetString($"Student Name {i}: ");
					studentGrade = CommonMethods.GetIntBetweenMinMax($"Student Grade {i}: ", 0, 100);
					StudentInfoWithFields newStudent = new StudentInfoWithFields(studentName, studentGrade);
					students.Add(newStudent);
					//We do not have set (mutator) access to the readonly field after instantiation.
					// newStudent.StudentName = "jimmy";
					i++;
					if (CommonMethods.GetString("Add another? y/n: ") == "n")
						adding = false;
				}
				catch (Exception e)
				{
					Console.WriteLine($"Exception: {e.Message}");
				}
			}
			for (int j = 0; j < students.Count; j++)
			{
				Console.WriteLine($"Name {j}: {students[j].StudentName}, Grade {j}: {students[j].StudentGrade}");
			}
		}
		public void RunDemo(string demoName)
		{
			try
			{
				Console.WriteLine($"{demoName} STARTED");
				//WithArrayOfObjects();
				WithListOfObjects();
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
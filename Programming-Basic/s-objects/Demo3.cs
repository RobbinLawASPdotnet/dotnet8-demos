using System;
using System.Collections.Generic;
using System.IO;

namespace Objects
{
	public class Demo3
	{
		public void AddStudents(List<StudentInfoWithFullProperties> students)
		{
			String PreformValidation = "yes";
			string studentName;
			int studentGrade;
			bool adding = true;
			//Adding a student with default values "James, 50".
			StudentInfoWithFullProperties newStudent0 = new StudentInfoWithFullProperties();
			students.Add(newStudent0);
			//Because the properties set is public we can set (mutate) 
			//it separately outside of the constructor after the object 
			//has been created (instantiated).
			//newStudent0.StudentName = "hi";
			//Because we now have validation in the setter we will NOT
			//allow bad data to creep in.
			//newStudent0.StudentName = "";
			int i = 1;
			while(adding)
			{
				try
				{
					studentName = CommonMethods.GetString($"Student Name {i}: ", PreformValidation);
					studentGrade = CommonMethods.GetIntBetweenMinMax($"Student Grade {i}: ", 0, 100, PreformValidation);
					StudentInfoWithFullProperties newStudent = new StudentInfoWithFullProperties(studentName, studentGrade);
					students.Add(newStudent);
					string myStudentNameString = newStudent.StudentName;
					i++;
					if (CommonMethods.GetString("Add another? y/n: ", "yes") == "n")
						adding = false;
				}
				catch (Exception e)
				{
					Console.WriteLine($"Exception: {e.Message}");
				}
			}
		}
		public void DisplayStudents(List<StudentInfoWithFullProperties> students)
		{
			for (int i = 0; i < students.Count; i++)
			{
				Console.WriteLine($"Name {i}: {students[i].StudentName}, Grade {i}: {students[i].StudentGrade}");
			}
			foreach (StudentInfoWithFullProperties student in students)
			{
				Console.WriteLine($"Name : {student.StudentName}, Grade : {student.StudentGrade}");
			}
		}
		public void RunDemo(string demoName)
		{
			try
			{
				Console.WriteLine($"{demoName} STARTED");
				List<StudentInfoWithFullProperties> students = new();
				AddStudents(students);
				DisplayStudents(students);
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
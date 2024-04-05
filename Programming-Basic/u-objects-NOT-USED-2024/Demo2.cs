using System;
using System.Collections.Generic;
using System.IO;

namespace Objects
{
	public class Demo2
	{
		public void AddStudents(List<StudentInfoWithAutoProperties> students)
		{
			string studentName;
			int studentGrade;
			bool adding = true;
			//Adding a student with default values "James, 50".
			StudentInfoWithAutoProperties newStudent0 = new StudentInfoWithAutoProperties();
			students.Add(newStudent0);
			//Because the properties set is private we cannot set (mutate) 
			//it separately outside of the constructor after the object 
			//has been created (instantiated).
			//newStudent0.StudentName = "hi";
			//We can access the private set this way though.
			newStudent0.AnotherInstanceMethod("hello");
			int i = 1;
			while(adding)
			{
				try
				{
					studentName = CommonMethods.GetString($"Student Name {i}: ");
					studentGrade = CommonMethods.GetIntBetweenMinMax($"Student Grade {i}: ", 0, 100);
					StudentInfoWithAutoProperties newStudent = new StudentInfoWithAutoProperties(studentName, studentGrade);
					students.Add(newStudent);
					string myStudentNameString = newStudent.StudentName;
					i++;
					if (CommonMethods.GetString("Add another? y/n: ") == "n")
						adding = false;
				}
				catch (Exception e)
				{
					Console.WriteLine($"Exception: {e.Message}");
				}
			}
		}
		public void DisplayStudents(List<StudentInfoWithAutoProperties> students)
		{
			for (int i = 0; i < students.Count; i++)
			{
				Console.WriteLine($"Name {i}: {students[i].StudentName}, Grade {i}: {students[i].StudentGrade}");
			}
			foreach (StudentInfoWithAutoProperties student in students)
			{
				Console.WriteLine($"Name : {student.StudentName}, Grade : {student.StudentGrade}");
			}
		}

		public void RunDemo(string demoName)
		{
			try
			{
				Console.WriteLine($"{demoName} STARTED");
				List<StudentInfoWithAutoProperties> students = new List<StudentInfoWithAutoProperties>();
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
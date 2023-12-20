using System;
using System.Collections.Generic;
using System.IO;

namespace Objects
{
	public class StudentInfoWithFields 
	{
		//string field, readonly means it can only be set by the constructor and never again.
		public readonly string StudentName;
		//int field
		public readonly int StudentGrade;
		//greedy constructor, to make sure fields and properties have meaningful values.
		public StudentInfoWithFields(string studentName, int studentGrade)
		{
			//validation in the constructor
			if(string.IsNullOrEmpty(studentName))
				throw new ArgumentException("Student Name cannot be empty");
			if (studentGrade < 0 || studentGrade > 100)
				throw new FormatException($"Student Grade must be between 0 and 100 inclusive");
			StudentName = studentName;
			StudentGrade = studentGrade;
		}
	}
}
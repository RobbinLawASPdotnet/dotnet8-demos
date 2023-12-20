using System;
using System.Collections.Generic;
using System.IO;

namespace Objects
{
	public class StudentInfoWithAutoProperties 
	{
		//String auto-implemented property.
		//By default the get (accessor) is public so StudentName can be on the right side of 
		//an = outside of this class.
		//For example you can have string myStudentName = myInstanceName.StudentName;
		//Private set (mutator) means that only the constructor or member methods can set it
		//or mutate it so StudentName cannot be on the left side of an = outside of this class.
		//For example you cannot have myInstanceName.StudentName = "hi";
		//NEVER make an auto-implemented properties set (mutator) public as there is no validation.
		public string StudentName {get; private set;}
		//int auto-implemented property
		public int StudentGrade {get; private set;}
		//greedy constructor, to make sure fields and properties have meaningful values.
		public StudentInfoWithAutoProperties(string studentName, int studentGrade)
		{
			//validation in the constructor
			if(string.IsNullOrEmpty(studentName))
				throw new ArgumentException("Student Name cannot be empty");
			if (studentGrade < 0 || studentGrade > 100)
				throw new FormatException($"Student Grade must be between 0 and 100 inclusive");
			StudentName = studentName;
			StudentGrade = studentGrade;
		}
		//Non greedy constructor, to make sure fields and properties have some default values.
		//Constructor chaining.
		public StudentInfoWithAutoProperties() : this("James", 50) {}
		//Instance method that has set access to StudentName.
		public void AnotherInstanceMethod(String newName)
		{
			StudentName = newName;
		}
	}
}
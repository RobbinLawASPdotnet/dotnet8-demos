using System;
using System.Collections.Generic;
using System.IO;

namespace Objects
{
	public class StudentInfoWithFullProperties 
	{
		//String fully-implemented property with a backing field.
		//By default the get (accessor) is public so StudentName can be on the right side of 
		//an = outside of this class.
		//For example you can have string myStudentName = myInstanceName.StudentName;
		//Public set (mutator) now means that any code outside of this class can set it
		//or mutate it so StudentName can now be on the left side of an = outside of this class.
		//For example you can now have myInstanceName.StudentName = "hi";
		//Because of this we now need validation inside the setter (mutator).
		private string _StudentName = "";
		public string StudentName 
		{
			get {return _StudentName;} 
			set
			{
				//validation in the setter (mutator)
				if(string.IsNullOrEmpty(value))
					throw new ArgumentException("Student Name cannot be empty");
				_StudentName = value;
			}
		}
		//int fully-implemented property with backing field.
		//This structure is performing ENCAPSULATION, nothing outside this
		//class can see the field directly, only the property.
		private int _StudentGrade;
		public int StudentGrade
		{
			get {return _StudentGrade;} 
			set
			{
				//validation in the setter (mutator)
				if (value < 0 || value > 100)
					throw new FormatException($"Student Grade must be between 0 and 100 inclusive");
				_StudentGrade = value;
			}
		}
		//greedy constructor, to make sure fields and properties have meaningful values.
		public StudentInfoWithFullProperties(string studentName, int studentGrade)
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
		public StudentInfoWithFullProperties() : this("James", 50) {}

		// code added for App4
		public override string ToString()
		{
			return $"{StudentName},{StudentGrade}";
		}
		// code added for App5
		public static StudentInfoWithFullProperties OurParse(string text)
		{
			string [] items = text.Split(',');
			if (items.Length != 2) 
				throw new FormatException("Input string is not the correct CSV format" );
			return new StudentInfoWithFullProperties(
				items[0],
				int.Parse(items[1])
			);
		}
		public static bool TryParse(string text, out StudentInfoWithFullProperties? result)
		{
			bool valid = false;
			try
			{
				result = OurParse(text);
				valid = true;
			}
			catch (Exception ex)
			{ 
				Console.WriteLine($"catch StudentInfoWithFullProperties.TryParse: {ex.Message}");  
				result = null;
			}
			//This code runs if the try is successful and does not have a return
			//and if the catch does not have a return as in this case.
			return valid;
		}
	}
}
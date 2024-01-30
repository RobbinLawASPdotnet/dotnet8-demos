using System;
using System.Collections.Generic;
using System.IO;

namespace Objects
{
	public class CommonMethods
	{
		private const string SPECIALCHARACTERS = @",:;\/!?@#$%^&*~`0123456789";
		//This is a class method that can be called without instantiating an object
		//of this class. The key word static makes it a class method.
		//Just call that class name and method, CommonMethods.GetString("hi","yes");
		public static string GetString(String msg, String PreformValidation)
		{
			bool inValidInput = true;
			string str = "";
			while (inValidInput)
			{
				try
				{
					Console.Write(msg);
					str = Console.ReadLine();
					if(PreformValidation == "yes")
					{
						if(string.IsNullOrEmpty(str))
							throw new ArgumentException("The string cannot be empty");
						foreach(char character in SPECIALCHARACTERS)
							if (str.Contains(character))
								throw new FormatException($"The string contains an invalid character.");
					}
					inValidInput = false; 
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Invalid: {ex.Message}");
				}
			}
			return str;
		}
		//This is another class method.
		public static int GetIntBetweenMinMax(String msg, int min, int max, String PreformValidation)
		{
			bool inValidInput = true;
			int num = 0;
			while (inValidInput)
			{
				try
				{
					Console.Write(msg);
					num = int.Parse(Console.ReadLine());
					if(PreformValidation == "yes")
						if (num < min || num > max)
							throw new Exception($"Must be between {min} and {max}");
					inValidInput = false; 
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Invalid: {ex.Message}");
				}
			}
			return num;
		}
	}
}
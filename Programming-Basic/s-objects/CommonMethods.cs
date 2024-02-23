using System;
using System.Collections.Generic;
using System.IO;

namespace Objects
{
	public class CommonMethods
	{
		//This is a class method that can be called without instantiating an object
		//of this class. The key word static makes it a class method.
		//Just call that class name and method, CommonMethods.GetString("hi");
		public static string GetString(String msg)
		{
			bool inValidInput = true;
			string str = "";
			while (inValidInput)
			{
				try
				{
					Console.Write(msg);
					str = Console.ReadLine();
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
		public static int GetIntBetweenMinMax(String msg, int min, int max)
		{
			bool inValidInput = true;
			int num = 0;
			while (inValidInput)
			{
				try
				{
					Console.Write($"{msg} between {min} and {max}: ");
					num = int.Parse(Console.ReadLine());
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
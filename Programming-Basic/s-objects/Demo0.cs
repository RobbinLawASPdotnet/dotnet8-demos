using System;
using System.Collections.Generic;
using System.IO;

namespace Objects
{
  public class Demo0
	{

public void RunDemo(string demoName)
{
  try
  {
    WithArrays();
    WithLists();
  }
  catch (Exception ex)
  {
    Console.WriteLine($"Exception in demo3: {ex.Message}");
  }

  void WithArrays()
  {
    Console.WriteLine("*** Using traditional arrays where size must be statically set at declaration ***");
    int studentCount = CommonMethods.GetIntBetweenMinMax("How many students in your class? ", 0, 100);
    string[] studentNames = new string[studentCount];
    int[] studentGrades = new int[studentCount];
    for (int i = 0; i < studentCount; i++)
    {
      studentNames[i] = CommonMethods.GetString("Student Name: ");
      studentGrades[i] = CommonMethods.GetIntBetweenMinMax("Student Grade: ", 0, 100);
    }
    for (int i = 0; i < studentCount; i++)
    {
      Console.WriteLine($"Name: {studentNames[i]}, Grade: {studentGrades[i]}");
    }
  }

	void WithLists()
  {
    Console.WriteLine("*** Using dynamic arrays called lists where size is not set at declaration ***");
    List<string> studentNames = new List<string>();
    List<int> studentGrades = new List<int>();
    bool adding = true;
    while(adding)
    {
      studentNames.Add(CommonMethods.GetString("Student Name: "));
      studentGrades.Add(CommonMethods.GetIntBetweenMinMax("Student Grade: ", 0, 100));
      if (CommonMethods.GetString("Add another? y/n: ") == "n")
        adding = false;
    }
    for (int i = 0; i < studentNames.Count; i++)
    {
      Console.WriteLine($"Name: {studentNames[i]}, Grade: {studentGrades[i]}");
    }
  }
}

  }
}
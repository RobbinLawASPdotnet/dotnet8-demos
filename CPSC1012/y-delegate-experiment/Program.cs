using System;
using System.Collections;

class MainClass
{
	public static void Main(string[] args)
	{
		Console.WriteLine("Menu sample: Simple text formatting.");
		Menu m = new Menu();
		m.Add("Convert to Upper-case", new MenuCallback(DoUppercase));
		m.Add("Convert to Lower-case", new MenuCallback(DoLowercase));
		m.Add("Capitalize", new MenuCallback(DoCapitalize));
		m.Show();
	}
	
	private static void DoUppercase()
	{
		Console.WriteLine();
		Console.WriteLine("Enter the text to convert to upper-case:");
		
		string text = Console.ReadLine();
		
		text = text.ToUpper();
		
		Console.WriteLine("Upper-case text::");
		
		Console.WriteLine(text);
	}
	
	private static void DoLowercase()
	{
		Console.WriteLine();
		Console.WriteLine("Enter the text to convert to lower-case:");
		
		string text = Console.ReadLine();
		
		text = text.ToLower();
		
		Console.WriteLine("Lower-case text:");
		
		Console.WriteLine(text);		
	}	
	
	private static void DoCapitalize()
	{
		Console.WriteLine();
		Console.WriteLine("Enter the text to be capitalized:");
		
		char[] text = Console.ReadLine().ToCharArray();
		
		string capitalized = "";
		
		bool IsNextCapital = true;
		
		for(int i = 0;i<text.Length;++i)
		{
			string curchar = text[i].ToString();
			
			string pairchar = "";
			string lastchar = "";
			
			try 
			{
				pairchar = text[i-2].ToString() + text[i-1].ToString();
				lastchar = text[i-1].ToString();
			}
			catch 
			{
				pairchar = "  ";
				lastchar = " ";
			}
						
			if ( (i == 0) || (lastchar == "(") || (pairchar == "? ") || (pairchar == "! ") || (pairchar == ". ") )
			{
				IsNextCapital = true;
			}
			else
			{
				IsNextCapital = false;
			}
			capitalized += IsNextCapital ? curchar.ToUpper() : curchar.ToLower();			
		}
		
		
		Console.WriteLine("Capitalized text:");
		
		Console.WriteLine(capitalized);		
	}	
}

delegate void MenuCallback();

class Menu
{
	private class MenuItem
	{
		public MenuCallback mc;
		public string text;
		
		public MenuItem(string Text, MenuCallback Mc)
		{
			mc = Mc;
			text = Text;
		}
	}
		
	private ArrayList m_Items = new ArrayList();
	
	public void Add(string text,MenuCallback mc)
	{
		m_Items.Add(new MenuItem(text,mc));
	}
	
	public void Show()
	{
		for(int i = 0;i<m_Items.Count;++i)
		{
			MenuItem mi = m_Items[i] as MenuItem;
			Console.WriteLine(" [{0}] {1}", i+1, mi.text);
		}
		
		int choosen = Int32.Parse(Console.ReadLine());
		
		if ( choosen > m_Items.Count || choosen < 1 )
		{
			Console.WriteLine("Invalid option.");
		}
		else
		{
			MenuItem mi = m_Items[choosen-1] as MenuItem;
			MenuCallback mc = mi.mc;
			mc();
		}
	}
	
}

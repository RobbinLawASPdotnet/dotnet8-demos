// Sequence Demos

// Demo-1-String Interpolation
Demo1();
// Demo-2-Escape Characters
//Demo2();
// Demo-3-Concatenate strings & Injecting Variable Values with String Interpolation
//Demo3();
// Demo-4-Math
//Demo4();
// Demo-5-ReadLine with Parse
//Demo5();
// Demo-6-Circle Circumference and Area
//Demo6();
// Demo-7-Average Velocity
//Demo7();
// Demo-8-Simple Future Value using compounding interest on a
// monthly basis
//Demo8();
// Demo-9-Calculating GST
//Demo9();
// Demo-10-String Building with String Interpolation Formatting
// NOT USED in 2024
//Demo10();
// Demo-11-More Complicated String Formatting
// NOT USED in 2024
//Demo11();

void Demo1()
{
  //A string without the $ is the old way of using strings.
  Console.WriteLine("Hello Everybody");
  //A string with the $ in front means use string interpolation
  //It is the new way. We will use this all the time.
  Console.WriteLine($"Hello Everybody");
  Console.WriteLine($"this is fun.");
}

void Demo2()
{
  //Console.WriteLine inserts new line characters CR (carriage return) and LF (line feed)
  Console.WriteLine($"Programming is Fun!");
  Console.WriteLine($"I just can't get enough of it.");
  //Console.Write function does not insert new line characters.
  Console.Write($"Programming is ");
  Console.Write($"FUN.");
  /*
    * We use ESCAPE-CHARACTERS to represent special or otherwise
    * un-typeable symbols inside our strings. Escape characters are
    * preceded by a BACKSLASH '\' .
    */
  Console.WriteLine($"\nMy real name is \"Robbin Law\".");
  Console.Write($"These are our top sellers:\n");
  Console.Write($"\tApples\n\tBananas\n\tTomatoes\n");
  Console.WriteLine($"See ya later");
}

void Demo3()
{
  // explicitly typed variables
  string myString = "Robbin";
  int myInt;
  double myDouble = 6.66;
  bool myBool = true;
  myInt = 17;
  // We can concatenate a string and variable without string
  // interpolation.
  Console.WriteLine("Hey " + myString);
  Console.WriteLine("Law, " + myString);
  // With string interpolation we can inject variables by placing
  // them in between {}.
  Console.WriteLine($"{myString}, {myInt}, {myDouble}, {myBool}");
  
  // implicitly typed variables
  var foo = "Apple";
  var bar = 15;
  // Without string interpolation
  Console.WriteLine(foo + ", " + bar);
  // With string interpolation
  Console.WriteLine($"{foo}, {bar}");
  Console.WriteLine($"the end");
}

// More on string interpolation
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated

void Demo4()
{
  int myInt1 = 8;
  int myInt2 = 5;
  double myDouble1 = 8.0;
  double myDouble2 = 5.0;
  double myDouble3 = 6.0;
  int myIntAnswer;
  double myDoubleAnswer;

  // This integer division only gives the whole part of division.
  myIntAnswer = myInt1 / myInt2;
  Console.WriteLine($"The 1st answer is: {myIntAnswer}");

  // This also only gives the whole part of division
  myIntAnswer = myInt2 / myInt1;
  Console.WriteLine($"The 2nd answer is: {myIntAnswer}");

  // this gives the remainder of integer division
  myIntAnswer = myInt1 % myInt2;
  Console.WriteLine($"The remainder is: {myIntAnswer}");

  // Whenever both a double and integer are involved
  // in a math expression, the integer is changed into
  // a double before the calculation begins, and
  // a double is returned from the calculation.
  myDoubleAnswer = myInt1 / myDouble2; 
  Console.WriteLine($"The 3rd answer is: {myDoubleAnswer}");

  // Here as well the integer is changed into a double
  myDoubleAnswer = myDouble2 / myInt1;
  Console.WriteLine($"The 4th answer is: {myDoubleAnswer}");

  myDoubleAnswer = myDouble1 / myDouble2;
  Console.WriteLine($"The 5th answer is: {myDoubleAnswer}");
  myDoubleAnswer = myDouble2 / myDouble1;
  Console.WriteLine($"The 6th answer is: {myDoubleAnswer}");
  Console.WriteLine($"The 6th answer truncated to 2 decimals is: {myDoubleAnswer:n2}");

  // Multiplication and Division precede Add and Subtract
  // when at the same level left to right so here Multiply first,
  // then Divide, then Add.
  myDoubleAnswer = myDouble1 + myDouble2 * myDouble3 / myDouble1;
  Console.WriteLine($"The 7th answer is:  {myDoubleAnswer}");

  // Any math done in parentheses is done first, so here
  // the Addition is done, then Multiply, then Divide.
  myDoubleAnswer = (myDouble1 + myDouble2) * myDouble3 / myDouble1;
  Console.WriteLine($"The 8th answer is:  {myDoubleAnswer:n5}");
}

// If we have <!-- <Nullable>enable</Nullable> --> commented out
// in the .csproj file then we do NOT have to worry about
// null safety with ReadLine().

// https://learn.microsoft.com/en-us/training/modules/csharp-null-safety/
// https://www.reddit.com/r/csharp/comments/tae9al/how_can_i_fix_this/

void Demo5()
{
  string name;
  string ageString;
  int age;
  double annualPay;

  Console.WriteLine("Enter your name: ");
  name = Console.ReadLine();

  // Anytime any value is read in with ReadLine()
  // the value will come back as a "string".
  Console.WriteLine("Enter your age:");
  ageString = Console.ReadLine();
  Console.WriteLine("ageString:" + ageString);
  age = int.Parse(ageString);

  // We can combine the two functions ReadLine() and double.Parse()
  // into one statement.
  Console.WriteLine("Enter your annual salary:");
  annualPay = double.Parse(Console.ReadLine());

  // The :c means output as a currency value.
  Console.WriteLine($"My name is {name}, my age is {age} " +
                    $"and I hope to earn {annualPay:c} per year.");
}

void Demo6()
{
  double myRadius;
  double myPi = Math.PI;
  double myCircumference;
  double myArea;
  Console.Write("Enter the Radius as a double: ");
  myRadius = double.Parse(Console.ReadLine());
  // Circumference = 2*pi*r
  myCircumference = 2.0 * myPi * myRadius;
  // Area = pi*r^2 = pi*r*r
  myArea = myPi * Math.Pow(myRadius, 2);
  Console.WriteLine($"The Radius was {myRadius:n} and its Circumference is {myCircumference:n} and its Area is {myArea:n}");
}

void Demo7()
{
  double x1, x2, t1, t2, avgVel;
  Console.WriteLine("Enter point x1 as a double");
  x1 = double.Parse(Console.ReadLine());
  Console.WriteLine("Enter point x2 as a double");
  x2 = double.Parse(Console.ReadLine());
  Console.WriteLine("Enter time t1 as a double");
  t1 = double.Parse(Console.ReadLine());
  Console.WriteLine("Enter time t2: as a double");
  t2 = double.Parse(Console.ReadLine());
  avgVel = (x2 - x1) / (t2 - t1);
  Console.WriteLine($"The average velocity is: {avgVel:n4}");
}

/*
The following is for calculating FV using MONTHLY COMPOUND
Where:
FV = Future value
I = Initial investment amount
R = Monthly interest rate as a decimal value not %
T = Number of months to leave invested

FV = I x (1 + R)^T
*/

void Demo8()
{
  Console.WriteLine("Enter Investment Amount:");
  double investAmt = double.Parse(Console.ReadLine());
  Console.WriteLine("Enter annual interest rate in percentage:");
  double interestRate = double.Parse(Console.ReadLine());
  double monthlyInterest = interestRate / 100 / 12;
  Console.WriteLine("Enter Number of years:");
  int numYears = int.Parse(Console.ReadLine());
  double futureVal = investAmt * Math.Pow(1 + monthlyInterest, numYears * 12);
  Console.WriteLine($"Future Value is {futureVal:c}");
}

void Demo9()
{
  // Declare variables that are Constants
  const double provTaxRate = 0.06;
  const double fedTaxRate = 0.05;
  // Inputs
  double itemPrice;
  int numItems;
  // Results
  double beforeTax;
  double totalProvTax;
  double totalFedTax;
  double totalTax;
  double totalSale;
  Console.WriteLine("Enter the item price as a double: ");
  itemPrice = double.Parse(Console.ReadLine());
  Console.WriteLine("Enter the Number of Items as an integer: ");
  numItems = int.Parse(Console.ReadLine());
  beforeTax = itemPrice * numItems;
  Console.WriteLine($"Purchase Total (before Tax): {beforeTax:c}");
  // Calculate Tax
  totalProvTax = beforeTax * provTaxRate;
  Console.WriteLine($"Total Provincial Tax: {totalProvTax:c}");
  totalFedTax = beforeTax * fedTaxRate;
  Console.WriteLine($"Total Federal Tax: {totalFedTax:c}");
  totalTax = totalProvTax + totalFedTax;
  Console.WriteLine($"Total Tax Amount: {totalTax:c}");
  totalSale = beforeTax + totalTax;
  Console.WriteLine($"Total Sale price: {totalSale:c}");
}

// Demo NOT USED as string interpolation formatting is not
// required now.

void Demo10()
{
  string name = "Lamp";
  int howMany = 34;
  double price = 4.52;
  double height = 1234.1283;
  bool hasLightBulb = true;
  //String building with multiple Console.WriteLine statements.
  //When a string begins with $ then whenever there is an {} 
  //inside is variable or literal string contents,justify format:presentation format.
  //left justified, decimal whole number, 2 digits
  Console.WriteLine($"{"howMany:",8} [{howMany,-10:d3}] lamps");
  //right justified, decimal whole number, 3 digits 
  Console.WriteLine($"{"howMany:",8} [{howMany,10:d4}] lamps");
  //right justified, numeric 3 decimals  
  Console.WriteLine($"{"howMany:",8} [{howMany,10:n3}] lamps");
  //left justified, numeric 2 decimals  
  Console.WriteLine($"{"height:",8} [{height,-10:n2}] cm");
  //right justified, numeric 3 decimals  
  Console.WriteLine($"{"height:",8} [{height,10:n3}] cm");
  //left justified, currency 2 decimals  
  Console.WriteLine($"{"price:",8} [{price,-10:c2}]");
  //right justified, currency 3 decimals  
  Console.WriteLine($"{"price:",8} [{price,10:c3}]");
  //right justified, numeric 1 decimals  
  Console.WriteLine($"{"price:",8} [{price,10:n1}]");
  //String building by forming one long string using concatenation.
  string desc =
      $"\n{"Name:",15} {name,-8}" +
      $"\n{"Price:",15} {price,-8:c}" +
      $"\n{"How Many:",15} {howMany,-8:d}" +
      $"\n{"Height:",15} {height,-8:n} cm" +
      $"\n{"Has Light Bulb:",15} {hasLightBulb,-8}\n";
  Console.WriteLine(desc);
}

// Demo NOT USED as string interpolation formatting is not
// required now.

void Demo11()
{
  int hamburgerNumber = 2;
  decimal hamburgerPrice = 8.56M;
  decimal hamburgerCost = hamburgerNumber * hamburgerPrice;
  int beerNumber = 3;
  decimal beerPrice = 5.20M;
  decimal beerCost = beerNumber * beerPrice;
  decimal netTotal = hamburgerCost + beerCost;
  decimal GST = netTotal * 0.05M;
  decimal total = netTotal + GST;
  string desc =
      $"\n{"Packing Slip",30}" +
      $"\n{"************************************************",25}" +
      $"\n{"Hamburgers:",15} {hamburgerNumber,-8:d}{"@",-1} {hamburgerPrice,-8:c}{"=",-1} {hamburgerCost,-8:c}" +
      $"\n{"Beers:",15} {beerNumber,-8:d}{"@",-1} {beerPrice,-8:c}{"=",-1} {beerCost,-8:c}" +
      $"\n{"Net Total:",15}{"=",20} {netTotal,-8:c}" +
      $"\n{"GST:",15}{"=",20} {GST,-8:c}" +
      $"\n{"Total:",15}{"=",20} {total,-8:c}" +
      $"\n";
  Console.WriteLine(desc);
}
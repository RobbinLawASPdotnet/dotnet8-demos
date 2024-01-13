# Using VSCode to create/run a C# program

## Links

- [The .net new templates](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new)

---

## Instructions

### Method 1

- Keep the instance of VSCode where these instructions are alive.
- Create another instance of VSCode and in that instance open the folder`C:\CPSC1012`.
- Now you can flip between the two VSCode instances, one for instructions, and the other to do the work in.
- Within the second instance of VSCode, go to `View/CommandPallet/.net: New Project`, choose `Console App`, name it `ConsoleApp1` (default, but you can name it whatever you want), and store it in `C:\CPSC1012` which will be the `default directory`.
- In the .csproj file that is created comment out the following:
```csharp
<!-- <Nullable>enable</Nullable> -->
```
- Right mouse click on the `project` name, default is `ConsoleApp1`.
- From the context sensitive menu choose `Open in Integrated Terminal`.
- From the terminal when your working directory is `ConsoleApp1` type the following commands:
```csharp
dotnet build
dotnet run
```

The resulting output should be `Hello, World!`.

---

### Method 2

- Keep the instance of VSCode where these instructions are alive.
- Create another instance of VSCode and in that instance open the folder`C:\CPSC1012`.
- Now you can flip between the two VSCode instances, one for instructions, and the other to do the work in.
- Start a terminal in the second instance of VSCode.
  - From the top menu choose `Terminal/New Terminal`.
  - You may have to press the `...` to see the `Terminal` option.
- From the terminal when your working directory is `C:\CPSC1012` type the following commands:

```csharp
dotnet new console -n ConsoleApp1 --framework net8.0
```
- In the .csproj file that is created comment out the following:
```csharp
<!-- <Nullable>enable</Nullable> -->
```

- From the terminal when your working directory is `C:\CPSC1012` type the following commands:
```csharp
cd ConsoleApp1
dotnet build
dotnet run
```

The resulting output should be `Hello, World!`.

---


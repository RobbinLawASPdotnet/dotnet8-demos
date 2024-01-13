# Using VSCode to create/run a C# program

## Links

- [The .net new templates](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new)

---

## Instructions

### Method 1

- Within VSCode close all folders, then open `C:\CPSC1012`.
- Within VSCode go to `View/CommandPallet/.net: New Project`, choose `Console app`, name it `ConsoleApp1` and store it in `C:\CPSC1012` which will be the `default directory`.
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

- Open the folder `C:\CPSC1012` in VSCode.
- Start a terminal in VSCode.
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


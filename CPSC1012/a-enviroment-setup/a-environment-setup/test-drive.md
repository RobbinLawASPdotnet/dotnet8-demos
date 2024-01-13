# Using Visual Studio Code and the Terminal

## Links

- [The .net new templates](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new)

---

## Instructions

We will create a dotnet8 project and run it.

- Open `C:\CPSC1012` in VSCode.
- Start a terminal in VSCode.
  - From the top menu choose `Terminal/New Terminal`.
  - You may have to press the `...` to see the `Terminal` option.
- From the terminal when your working directory is `C:\CPSC1012` type the following commands:

```csharp
# Create a console project
dotnet new console -n ConsoleApp --framework net8.0
```
In the .csproj file that is created comment out the following:
```csharp
<!-- <Nullable>enable</Nullable> -->
```

To ensure that your console application works, build and run your project.

- From the terminal when your working directory is `C:\CPSC1012` type the following commands:
```csharp
cd ConsoleApp
dotnet build
dotnet run
```

The resulting output should be `Hello, World!`.

---


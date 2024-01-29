<base target="_blank">

# Environment Setup for C# Console Dev (Windows10)

## Download Git

- [Git Website](https://git-scm.com/)
- Download the latest version. Allow all the defaults on download. The path should be updated automatically, so that `git` is available from any directory.
- Open a PowerShell or CMD terminal. In the shell run `git –version` to make sure that git is installed and accessible from this directory. Note that it is two minus bars before version. If a version number is not returned, the path must be set so that `git` is available from any directory. To set the path, in the search area at the bottom of the windows task bar type `env` and select `Edit Environment Variables for your Account`. Then edit the `PATH` and add new `C:\Program Files\Git\cmd`. You could add this to the system environments alternatively. Now you can run the `git` command from a terminal anywhere.
  
----

## Download Visual Studio Code

- [Visual Studio Code Website](https://code.visualstudio.com)
- Download Visual Studio Code if you do not already have it on your machine.
- From VS Code install the extensions `C#`, and `C# Dev Kit`.

---

## Setup Folder Structure

- Create the following folders in the C drive:
  - C:\CPSC1012

---

## Clone My Demos to Your Machine

- [My Demos Repo on GitHub](https://github.com/RobbinLawASPdotnet/dotnet8-demos.git)
- From the link above, clone my repo to your machine.
  - from the green dropdown copy the link to your clipboard.
  - in VSCode run the command `View/CommandPallet/Git:Clone`
  - clone the repo to `C:\CPSC1012`

---

## Create a GitHub Account

- [GitHub Website](https://github.com)
- Go to GitHub and create an account. Choose an appropriate username that has your first and last name in it. Remember the username that you create the account with as well as the email that you use. You will need this information to complete the setup.

---

## Download dotnet8 software dev kit

- [dotnet8 sdk download](https://dotnet.microsoft.com/en-us/download)
- Go to the link above and download the dotnet8 sdk.

---
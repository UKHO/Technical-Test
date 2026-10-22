# Technical Test - Front End

## Local environment setup

### Prerequisites

- An IDE of your choice (we recommend Visual Studio or Visual Studio Code)
- The [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- Git

### Setup and commands

1. Open a suitable directory in terminal and run the following command  
    `git clone https://github.com/UKHO/Technical-Test.git`

2. Change to the challenge directory:

    `cd ./Technical-Test/src/FrontEndChallenge`

3. Open `FrontEndChallenge.sln` in your IDE, or use the commands below.

**To build the solution**

`dotnet build FrontEndChallenge.sln`

**To run the application**

`dotnet run --project FrontEndChallenge.Web`

Open one of the URLs printed in the terminal. If your browser does not trust the local HTTPS certificate, run `dotnet dev-certs https --trust`.

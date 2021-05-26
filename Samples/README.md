# Introduction 

The Repository Contains Sample Console Application For MPPGv3 Operations

 1. GetProcessorReport
 2. ProcessCardSwipe
 3. ProcessEMVSRED
 4. ProcessEncryptedManualEntry
 5. ProcessKeyPadEntry
 6. ProcessEncryptedManualEntry
 7. ProcessReferenceID
 8. ProcessToken
 
    
# Clone the repository
 1. Navigate to the main page of the  **repository**. 
 2. Under the  **repository**  name, click  **Clone** .
 3. Use any Git Client(eg.: GitBash, Git Hub for windows, Source tree ) to  **clone**  the  **repository**  using HTTPS.

Note: reference for  [Cloning a Github Repository](https://help.github.com/en/articles/cloning-a-repository)


# Getting Started

1.  Install .net core 3.1 LTS

    - Demo app requires dotnet core 3.1 LTS is installed

2.  Software dependencies( The Following nuget packages are automatically installed when we open and run the project), please recheck and add the references from nuget
 

     Microsoft.Extensions.DependencyInjection

     Microsoft.Extensions.Configuration

     Microsoft.Extensions.Configuration.EnvironmentVariables

     Microsoft.Extensions.Configuration.Json
     
     Microsoft.Extensions.Configuration.Binder

    
###Latest releases
- Initial release with all commits and changes as on Jan 25th 2021

# Build and Test

 Steps to Build and run project( .net core 3.1)

 From the cmd,  Navigate to the cloned folder and go to respective folder  Ex: For MPPGv3DemoApps
    
 Run the following commands
    
 ```dotnet clean MPPGv3.DemoApps.sln```

 ```dotnet build MPPGv3.DemoApps.sln```

 Navigate from command prompt to MPPGv3.DemoApp folder containing MPPGv3.DemoApp.csproj and run below command

 ```dotnet run --project MPPGv3.DemoApp.csproj```

 This should open the application running in console.


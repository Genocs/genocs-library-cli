# Genocs cli

Another key component for the Genocs ecosystem

## Introduction

Genocs cli is the genocs **dotnet tool**  that allow you to use the genocs templates.
Genocs template are dotnet template that will help you to setup quickly and easily your microservices.

Here where you can find the official Documentation:
- [microsoft - dotnet tools](https://learn.microsoft.com/en-us/dotnet/core/tools/global-tools)


## Supported runtime

Genocs cli can be used on NET6 or NET7 runtimes

---

Useful commands 
``` bash
# Get the list of tool
dotnet tool list

# Get the list of templates
dotnet new list

# Install from nuget
dotnet tool install -g genocs.cli

# Update the tool
dotnet tool update -g genocs.cli

# Uninstall cache
dotnet tool uninstall -g genocs.cli
```


Useful commands to work on your own 
``` bash
# build the project 
dotnet build ./src/genocs.cli.csproj

# Pack the tool (to be deployed on nuget) 
dotnet pack

# Run the tool to install the templates
dotnet run -f net7.0 --project ./src/genocs.cli.csproj genocs -i

# Run the tool to install the templates (some as above with cd command)
cd ./src
dotnet run -f net7.0 genocs -i

# Install the tool from local folder to the global cache
dotnet tool install --global --add-source ./src/nupkg genocs.cli
```
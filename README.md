# Genocs cli

[![GitHub](https://img.shields.io/github/license/Genocs/genocs-library-cli?color=2da44e&style=flat-square)](https://github.com/Genocs/genocs-library-cli/blob/main/LICENSE)
[![.NET build and test](https://github.com/Genocs/genocs-library-cli/actions/workflows/build_and_test.yml/badge.svg)](https://github.com/Genocs/genocs-library-cli/actions/workflows/build_and_test.yml)
[![NuGet](https://img.shields.io/badge/nuget-v.0.0.7-blue)](https://www.nuget.org/packages/Genocs.CLI)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Genocs.CLI.svg)](https://www.nuget.org/packages/Genocs.CLI)
[![All Contributors](https://img.shields.io/badge/all_contributors-1-yellow.svg?style=flat-square)](#contributors)
<a href="https://www.nuget.org/packages/Genocs.WebApiTemplate/" rel="Genocs.WebApiTemplate"></a>
[![Gitter](https://img.shields.io/badge/chat-on%20gitter-blue.svg)](https://gitter.im/genocs/)
[![Discord](https://img.shields.io/discord/1106846706512953385?color=%237289da&label=Discord&logo=discord&logoColor=%237289da&style=flat-square)](https://discord.com/invite/fWwArnkV)
[![Twitter](https://img.shields.io/twitter/follow/genocs?color=1DA1F2&label=Twitter&logo=Twitter&style=flat-square)](https://twitter.com/genocs)



Another key component for the Genocs ecosystem.

## Introduction

Genocs cli is the genocs **dotnet tool**  that allow you to use genocs templates.
Genocs templates are dotnet template that will help you to setup quick and easy your microservice solution.

Here where you can find the official Documentation:
- [Microsoft - dotnet tools](https://learn.microsoft.com/en-us/dotnet/core/tools/global-tools)


## Supported runtime

Genocs cli can be used on NET6 or NET7 runtimes.

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
cd ./src
# build the project 
dotnet build genocs.cli.csproj

# Pack the tool (to be deployed on nuget) 
dotnet pack -p:PackageVersion={semver} --output nupkgs
dotnet pack --output nupkgs

# Run the tool to install the templates
dotnet run -f net7.0 --project ./src/genocs.cli.csproj genocs -i

# Run the tool to install the templates (some as above with cd command)
cd ./src
dotnet run -f net7.0 genocs -i

# Install the tool from local folder to the global cache
dotnet tool install --global --add-source ./nupkgs genocs.cli
```


## Community

- Discord [@genocs](https://discord.com/invite/fWwArnkV)
- Facebook Page [@genocs](https://facebook.com/Genocs)
- Youtube Channel [@genocs](https://youtube.com/c/genocs)

## Contributors

Submit your PR and join the list!

<a href="https://github.com/Genocs/genocs-library/graphs/contributors">
  <img src="https://contrib.rocks/image?repo=Genocs/genocs-library" />
</a>

## License

This project is licensed with the [MIT license](LICENSE).

## Support :star:

Has this project helped you learn something New? or Helped you at work?
Here are a few ways by which you can support.

-   Leave a star! :star:
-   Recommend this awesome project to your colleagues. 🥇
-   Do consider endorsing me on LinkedIn for ASP.NET Core - [Connect via LinkedIn](https://www.linkedin.com/in/giovanni-emanuele-nocco-b31a5169/) 🦸
-   Or, If you want to support this project in the long run, [consider buying me a coffee](https://www.buymeacoffee.com/genocs)! ☕

<br>
    
<a href="https://www.buymeacoffee.com/genocs"><img width="250" alt="black-button" src="https://user-images.githubusercontent.com/31455818/138557309-27587d91-7b82-4cab-96bb-90f4f4e600f1.png" ></a>

## **acknowledgments**

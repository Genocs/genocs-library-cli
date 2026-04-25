# Genocs cli

[![GitHub](https://img.shields.io/github/license/Genocs/genocs-library-cli?color=2da44e&style=flat-square)](https://github.com/Genocs/genocs-library-cli/blob/main/LICENSE)
[![.NET build and test](https://github.com/Genocs/genocs-library-cli/actions/workflows/build-and-test.yml/badge.svg)](https://github.com/Genocs/genocs-library-cli/actions/workflows/build-and-test.yml)
[![NuGet](https://img.shields.io/nuget/v/Genocs.CLI.svg)](https://www.nuget.org/packages/Genocs.CLI)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Genocs.CLI.svg)](https://www.nuget.org/packages/Genocs.CLI)
[![Discord](https://img.shields.io/discord/1106846706512953385?color=%237289da&label=Discord&logo=discord&logoColor=%237289da&style=flat-square)](https://discord.com/invite/fWwArnkV)
[![Twitter](https://img.shields.io/twitter/follow/genocs?color=1DA1F2&label=Twitter&logo=Twitter&style=flat-square)](https://twitter.com/genocs)

## Introduction

Genocs CLI is a **dotnet tool** that helps you install and use Genocs templates.
These templates help you bootstrap microservices and other solution types quickly.

Official .NET tool documentation:
- [Microsoft - dotnet tools](https://learn.microsoft.com/en-us/dotnet/core/tools/global-tools)

## Supported runtime

Genocs CLI runs on .NET 10.

## Documentation: [Genocs Library - CLI](https://learn.fiscanner.net/cli/)

---

Useful commands

```bash
# Get the list of tool
dotnet tool list

# Get the list of templates
dotnet new list

# Install from nuget
dotnet tool install -g genocs.cli

# Update the tool
dotnet tool update -g genocs.cli

# Uninstall the tool
dotnet tool uninstall -g genocs.cli
```

Useful commands for local development

```bash
cd ./src
# build the project
dotnet build genocs.cli.csproj

# Pack the tool (to be deployed on nuget)
dotnet pack genocs.cli.csproj -p:PackageVersion={semver} --output nupkg
dotnet pack genocs.cli.csproj --output nupkg

# Run the tool to install templates
dotnet run -f net10.0 --project ./src/genocs.cli.csproj -- install

# Install the tool from local folder to the global cache
dotnet tool install --global --add-source ./nupkg genocs.cli
```

Supported template commands:

```bash
genocs blazor new <ProjectName>
genocs webapi new <ProjectName>
genocs worker new <ProjectName>
genocs cleanapi new <ProjectName>
genocs angular new <ProjectName>
genocs react new <ProjectName>
```

Run tests locally:

```bash
dotnet test genocs.cli.slnx
```


## Changelogs

View Complete [Changelogs](https://github.com/genocs/genocs-library-cli/blob/main/CHANGELOG.md).

## License

This project is licensed with the [MIT license](LICENSE).

## Community

- Discord [@genocs](https://discord.com/invite/fWwArnkV)
- Facebook Page [@genocs](https://facebook.com/Genocs)
- Youtube Channel [@genocs](https://youtube.com/c/genocs)

## Support

Has this Project helped you learn something New? or Helped you at work?

Here are a few ways by which you can support.

- ⭐ Leave a star!
- 🥇 Recommend this project to your colleagues.
- 🦸 Do consider endorsing me on LinkedIn for ASP.NET Core - [Connect via LinkedIn](https://www.linkedin.com/in/giovanni-emanuele-nocco-b31a5169/)
- ☕ If you want to support this project in the long run, consider [buying me a coffee](https://www.buymeacoffee.com/genocs)!

[![buy-me-a-coffee](https://raw.githubusercontent.com/Genocs/genocs-library-cli/main/assets/buy-me-a-coffee.png "buy me a coffee")](https://www.buymeacoffee.com/genocs)

## Code Contributors

This project exists thanks to all the people who contribute. [Submit your PR and join the team!](CONTRIBUTING.md)

[![genocs contributors](https://contrib.rocks/image?repo=Genocs/genocs-library-cli "genocs contributors")](https://github.com/genocs/genocs-library-cli/graphs/contributors)

## Financial Contributors

Become a financial contributor and help me sustain the project.

**Support the Project** on [Opencollective](https://opencollective.com/genocs)

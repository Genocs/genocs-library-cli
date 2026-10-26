# Genocs CLI

![Genocs Library Banner](assets/genocs-library-banner_v2.png)

[![GitHub](https://img.shields.io/github/license/Genocs/genocs-library-cli?color=2da44e&style=flat-square)](https://github.com/Genocs/genocs-library-cli/blob/main/LICENSE)
[![.NET build and test](https://github.com/Genocs/genocs-library-cli/actions/workflows/build-and-test.yml/badge.svg)](https://github.com/Genocs/genocs-library-cli/actions/workflows/build-and-test.yml)
[![NuGet](https://img.shields.io/nuget/v/Genocs.CLI.svg)](https://www.nuget.org/packages/Genocs.CLI)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Genocs.CLI.svg)](https://www.nuget.org/packages/Genocs.CLI)
[![Discord](https://img.shields.io/discord/1106846706512953385?color=%237289da&label=Discord&logo=discord&logoColor=%237289da&style=flat-square)](https://discord.com/invite/fWwArnkV)
[![Twitter](https://img.shields.io/twitter/follow/genocs?color=1DA1F2&label=Twitter&logo=Twitter&style=flat-square)](https://twitter.com/genocs)

<p align="center">
  <img src="assets/genocs-library-logo.png" alt="Genocs Library Logo" width="800" />
</p>

## Introduction

Genocs CLI is a **.NET tool** for installing and using Genocs templates.
Use these templates to quickly bootstrap microservices and other types of solutions.

## Supported runtime

Genocs CLI runs on .NET 10.

## Documentation

- [Genocs CLI docs](https://genocs-blog.netlify.app/cli/)
- [Microsoft - .NET tools](https://learn.microsoft.com/en-us/dotnet/core/tools/global-tools)
- [Changelog](https://github.com/genocs/genocs-library-cli/blob/main/CHANGELOG.md)

---

## Common commands

```bash
# List installed tools
dotnet tool list -g

# List available templates
dotnet new list

# Install from NuGet
dotnet tool install -g genocs.cli

# Update the tool
dotnet tool update -g genocs.cli

# Uninstall the tool
dotnet tool uninstall -g genocs.cli
```

## Local development

```bash
# Build the project
dotnet build

# Run the tests
dotnet test

# Pack the tool for NuGet
dotnet pack -p:PackageVersion=1.5.4 --output nupkg
dotnet pack --output nupkg

# Run the tool to install templates
dotnet run -f net10.0 --project ./src/Genocs.Cli/Genocs.Cli.csproj -- install

# Install the tool from the local folder to the global cache
dotnet tool install --global --add-source ./nupkg genocs.cli
```

## CLI commands

```bash
genocs version
genocs install
# Install/update commands: genocs install (genocs i) and genocs update (genocs u)

genocs blazor new <ProjectName>
genocs webapi new <ProjectName>
genocs worker new <ProjectName>
genocs cleanapi new <ProjectName>
genocs angular new <ProjectName>
genocs react new <ProjectName>
```

## Community

- Discord [@genocs](https://discord.com/invite/fWwArnkV)
- Facebook Page [@genocs](https://facebook.com/Genocs)
- YouTube channel [@genocs](https://youtube.com/c/genocs)

## Support

Has this project helped you learn something new or helped you at work?

Here are a few ways you can support the project:

- ⭐ Leave a star!
- 🥇 Recommend this project to your colleagues.
- 🦸 Consider endorsing me on LinkedIn for ASP.NET Core: [Connect via LinkedIn](https://www.linkedin.com/in/giovanni-emanuele-nocco-b31a5169/)
- ☕ If you want to support this project in the long run, consider [buying me a coffee](https://www.buymeacoffee.com/genocs)!

[![buy-me-a-coffee](https://raw.githubusercontent.com/Genocs/genocs-library-cli/main/assets/buy-me-a-coffee.png "buy me a coffee")](https://www.buymeacoffee.com/genocs)

## Financial contributors

Become a financial contributor to help sustain the project.

**Support the project** on [Open Collective](https://opencollective.com/genocs)

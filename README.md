<!-- PROJECT SHIELDS -->

[![License][license-shield]][license-url]
[![Build][build-shield]][build-url]
[![Packages][package-shield]][package-url]
[![Downloads][downloads-shield]][downloads-url]
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![Discord][discord-shield]][discord-url]
[![Gitter][gitter-shield]][gitter-url]
[![Twitter][twitter-shield]][twitter-url]
[![Twitterx][twitterx-shield]][twitterx-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

[license-shield]: https://img.shields.io/github/license/Genocs/genocs-library-cli?color=2da44e&style=flat-square
[license-url]: https://github.com/Genocs/genocs-library-cli/blob/main/LICENSE
[build-shield]: https://github.com/Genocs/genocs-library-cli/actions/workflows/build_and_test.yml/badge.svg?branch=main
[build-url]: https://github.com/Genocs/genocs-library-cli/actions/workflows/build_and_test.yml
[package-shield]: https://img.shields.io/badge/nuget-v.1.3.1-blue?&label=latests&logo=nuget
[package-url]: https://github.com/Genocs/genocs-library-cli/actions/workflows/build_and_test.yml
[downloads-shield]: https://img.shields.io/nuget/dt/Genocs.CLI.svg?color=2da44e&label=downloads&logo=nuget
[downloads-url]: https://www.nuget.org/packages/Genocs.CLI
[contributors-shield]: https://img.shields.io/github/contributors/Genocs/genocs-library-cli.svg?style=flat-square
[contributors-url]: https://github.com/Genocs/genocs-library-cli/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/Genocs/genocs-library-cli?style=flat-square
[forks-url]: https://github.com/Genocs/genocs-library-cli/network/members
[stars-shield]: https://img.shields.io/github/stars/Genocs/genocs-library-cli.svg?style=flat-square
[stars-url]: https://img.shields.io/github/stars/Genocs/genocs-library-cli?style=flat-square
[issues-shield]: https://img.shields.io/github/issues/Genocs/genocs-library-cli?style=flat-square
[issues-url]: https://github.com/Genocs/genocs-library-cli/issues
[discord-shield]: https://img.shields.io/discord/1106846706512953385?color=%237289da&label=Discord&logo=discord&logoColor=%237289da&style=flat-square
[discord-url]: https://discord.com/invite/fWwArnkV
[gitter-shield]: https://img.shields.io/badge/chat-on%20gitter-blue.svg
[gitter-url]: https://gitter.im/genocs/
[twitter-shield]: https://img.shields.io/twitter/follow/genocs?color=1DA1F2&label=Twitter&logo=Twitter&style=flat-square
[twitter-url]: https://twitter.com/genocs
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=flat-square&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/giovanni-emanuele-nocco-b31a5169/
[twitterx-shield]: https://img.shields.io/twitter/url/https/twitter.com/genocs.svg?style=social
[twitterx-url]: https://twitter.com/genocs

<!-- PROJECT LOGO -->
<p align="center">
  <a href="https://github.com/genocs/genocs-library-cli">
    <img src="https://raw.githubusercontent.com/genocs/genocs-library-cli/main/assets/genocs-library-logo.png" alt=".NET Microservice Template">
  </a>
  <h3 align="center">.NET CLI</h3>
  <p align="center">
    Open Source CLI For .NET10 Microservice
    <br />
    <a href="https://learn.fiscanner.net"><strong>Read the Documentation »</strong></a>
    <br />
    <br />
    <a href="https://github.com/genocs/genocs-library-cli/issues">Report Bug</a>
    ·
    <a href="https://github.com/genocs/genocs-library-cli/issues">Request Feature</a>
    .
    <a href="https://github.com/genocs/genocs-library-cli/issues">Request Documentation</a>
  </p>
</p>


# Genocs cli

## Introduction

Genocs cli is the Genocs **dotnet tool** that allow you to use Genocs templates.
Genocs templates are dotnet template that will help you to setup quick and easy your microservice solution.

Here where you can find the Dotnet tools official Documentation:

- [Microsoft - dotnet tools](https://learn.microsoft.com/en-us/dotnet/core/tools/global-tools)

## Supported runtime

Genocs cli can be used on .NET10 runtimes.

Please check the GitHub repository getting more info.

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

# Uninstall cache
dotnet tool uninstall -g genocs.cli
```

Useful commands to work on your own

```bash
cd ./src
# build the project
dotnet build genocs.cli.csproj

# Pack the tool (to be deployed on nuget)
dotnet pack -p:PackageVersion={semver} --output nupkgs
dotnet pack --output nupkgs

# Run the tool to install the templates
dotnet run -f net10.0 --project ./src/genocs.cli.csproj genocs -i

# Run the tool to install the templates (some as above with cd command)
cd ./src
dotnet run -f net10.0 genocs -i

# Install the tool from local folder to the global cache
dotnet tool install --global --add-source ./nupkgs genocs.cli
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

## Acknowledgements
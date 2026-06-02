# Genocs CLI

![Genocs Library Banner](https://raw.githubusercontent.com/Genocs/genocs-library-cli/main/assets/genocs-library-banner_v2.png)

Genocs CLI is the official .NET tool to install Genocs templates and bootstrap projects from the command line.

## Supported runtime

Genocs CLI runs on .NET 10.

## Install

```bash
dotnet tool install -g genocs.cli
```

## Basic usage

```bash
# Install or update Genocs templates
genocs install
# aliases: genocs i | genocs update | genocs u

# Show tool version
genocs version

# Create new projects
genocs blazor new <ProjectName>
genocs webapi new <ProjectName>
genocs worker new <ProjectName>
genocs cleanapi new <ProjectName>
genocs angular new <ProjectName>
genocs react new <ProjectName>
```

## Useful dotnet commands

```bash
# List installed tools
dotnet tool list -g

# Update the tool
dotnet tool update -g genocs.cli

# Uninstall the tool
dotnet tool uninstall -g genocs.cli
```

## Documentation

- [Genocs CLI docs](https://learn.fiscanner.net/cli/)
- [Microsoft - .NET tools](https://learn.microsoft.com/en-us/dotnet/core/tools/global-tools)
- [Changelog](https://github.com/Genocs/genocs-library-cli/blob/main/CHANGELOG.md)

## License

Licensed under the [MIT license](https://github.com/Genocs/genocs-library-cli/blob/main/LICENSE).

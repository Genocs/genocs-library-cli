# Genocs CLI - Copilot Instructions

## Project Overview
This is a .NET 9 CLI tool packaged as a global dotnet tool (`genocs`) that provides templates for Genocs microservice solutions. The tool generates project scaffolding for various frontend and backend architectures.

## Architecture & Structure

### Core Components
- **Single executable**: `src/Program.cs` contains all CLI command logic in a top-level program pattern
- **Template bootstrapping**: Commands call specific `Bootstrap*SolutionAsync()` methods that invoke `dotnet new` with Genocs templates
- **Command pattern**: Simple string parsing with format `genocs <template-type> <command> <project-name>`

### Supported Templates
Available via commands like `genocs [template] new CompanyName.ProjectName`:
- `angular` - Angular frontend projects
- `react` - React frontend projects  
- `blazor-clean` - Clean Blazor applications
- `blazor-wasm` - Blazor WebAssembly projects
- `clean-webapi` - Clean Architecture Web APIs
- `libra-webapi` - Libra Web API template
- `micro-webapi` - Microservice Web API template

### Project Naming Convention
Uses `ToCapitalCase()` extension method (in `StringExtensions.cs`) to convert input like "company.project" to "Company.Project" format for proper C# namespace conventions.

## Development Workflows

### Building & Testing
```bash
# From repository root
dotnet build
dotnet run --project src/genocs.cli.csproj -- genocs -i

# From src/ directory  
dotnet build genocs.cli.csproj
dotnet run -f net9.0 genocs -i
```

### Local Installation & Testing
```bash
# Pack for local installation
dotnet pack --output nupkgs
dotnet tool install --global --add-source ./nupkgs genocs.cli

# Test template installation
genocs install  # or genocs i
```

### Template Management
- `genocs install|i` - Installs/updates Genocs templates from remote repositories
- `genocs update|u` - Alias for install command
- Templates are installed via `dotnet new install` commands in bootstrap methods

## Build Configuration

### Project Structure
- **Single project solution**: Only `src/genocs.cli.csproj` with solution items folder
- **Global build props**: `Directory.Build.props` enforces StyleCop, Roslynator analyzers, nullable reference types
- **Tool packaging**: Configured as `<PackAsTool>true</PackAsTool>` with command name `genocs`

### Code Quality
- **StyleCop + Roslynator**: Enforced via `Directory.Build.props` with custom `stylecop.json` rules
- **Nullable enabled**: All projects use `<Nullable>enable</Nullable>`
- **Documentation**: `GenerateDocumentationFile` enabled for XML docs
- **Global using**: `System.Guid` aliased as `DefaultIdType`

## Key Patterns

### Command Parsing
Simple imperative parsing in `Program.cs`:
```csharp
string firstArg = args[0].Trim().ToLower();
if (firstArg == "install" || firstArg == "i" || firstArg == "update" || firstArg == "u")
{
    await InstallTemplates();
    return;
}
```

### Error Handling
Basic validation with console output:
```csharp
if (args.Length != 3)
{
    Console.WriteLine("Invalid command. Use something like: genocs angular new <CompanyName.ProjectName>");
    return;
}
```

### Resource Management
- `MainResource.resx` for embedded strings/resources
- `Figgle` dependency for ASCII art rendering
- `icon.png` and license files embedded in NuGet package

## CI/CD Pipeline
- **GitHub Actions**: `build_and_test.yml` runs on .NET 9 with restore, build, test, pack
- **NuGet publishing**: Separate workflow for package deployment
- **Version management**: `PackageVersion` in csproj, uses SemVer

## Dependencies & External Integration
- **Figgle**: ASCII art rendering for CLI branding
- **Genocs Templates**: External template repositories installed via `dotnet new install` 
- **NuGet**: Published as global tool with command name `genocs`
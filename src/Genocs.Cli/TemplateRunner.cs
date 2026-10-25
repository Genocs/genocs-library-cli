using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Spectre.Console;

namespace Genocs.Cli;

internal static class TemplateRunner
{
    // Allows letters, digits, underscores, hyphens, and dots; must start with a letter or underscore.
    private static readonly Regex ValidProjectNameRegex =
        new(@"^[a-zA-Z_][a-zA-Z0-9_\-\.]*$", RegexOptions.Compiled, TimeSpan.FromMilliseconds(500));

    internal static async Task InstallTemplatesAsync(CancellationToken cancellationToken)
    {
        AnsiConsole.MarkupLine("[green]Installing Genocs Clean Architecture template...[/]");
        await RunDotNetAsync(["new", "install", "Genocs.CleanArchitecture.Template"], cancellationToken);

        AnsiConsole.WriteLine("Installing Genocs Microservice template...");
        await RunDotNetAsync(["new", "install", "Genocs.Microservice.Template"], cancellationToken);

        AnsiConsole.WriteLine("Installing Genocs Blazor WASM template...");
        await RunDotNetAsync(["new", "install", "Genocs.BlazorWasm.Template"], cancellationToken);

        AnsiConsole.WriteLine("Installing Genocs Library template...");
        await RunDotNetAsync(["new", "install", "Genocs.Library.Template"], cancellationToken);

        AnsiConsole.WriteLine("Installing Genocs Blazor Clean template...");
        await RunDotNetAsync(["new", "install", "Genocs.BlazorClean.Template"], cancellationToken);

        AnsiConsole.MarkupLine("[green]Templates installed successfully.[/]");
        AnsiConsole.MarkupLine("[green]Run [grey]dotnet new list[/] to see installed templates.[/]");
        CliPresentation.WritePostInstallHint();
    }

    internal static Task BootstrapAngularAsync(string projectName, CancellationToken cancellationToken)
    {
        AnsiConsole.WriteLine("Angular template not available ...");
        return Task.CompletedTask;
    }

    internal static Task BootstrapReactAsync(string projectName, CancellationToken cancellationToken)
    {
        AnsiConsole.WriteLine("React template not available ...");
        return Task.CompletedTask;
    }

    internal static Task BootstrapWorkerAsync(string projectName, CancellationToken cancellationToken)
    {
        AnsiConsole.WriteLine("Worker template not available ...");
        return Task.CompletedTask;
    }

    internal static async Task BootstrapCleanArchitectureAsync(string projectName, CancellationToken cancellationToken)
    {
        ValidateProjectName(projectName);
        AnsiConsole.WriteLine($"Bootstrapping genocs Clean Architecture project at '{projectName}' ...");
        await RunDotNetAsync(["new", "gnx-cleanarchitecture", "-n", projectName, "-o", projectName, "-v=q"], cancellationToken);
        AnsiConsole.MarkupLine($"[green]Genocs Clean Architecture solution '{Markup.Escape(projectName)}' successfully created.[/]");
        AnsiConsole.MarkupLine("Refer to [link]https://genocs-blog.netlify.app/[/]");
    }

    internal static async Task BootstrapMicroserviceAsync(string projectName, CancellationToken cancellationToken)
    {
        ValidateProjectName(projectName);
        AnsiConsole.WriteLine($"Bootstrapping genocs Microservice project at '{projectName}' ...");
        await RunDotNetAsync(["new", "gnx-webapi", "-n", projectName, "-o", projectName, "-v=q"], cancellationToken);
        AnsiConsole.MarkupLine($"[green]Genocs Microservice solution '{Markup.Escape(projectName)}' successfully created.[/]");
        AnsiConsole.MarkupLine("Refer to [link]https://genocs-blog.netlify.app/[/]");
    }

    internal static async Task BootstrapBlazorWasmAsync(string projectName, CancellationToken cancellationToken)
    {
        ValidateProjectName(projectName);
        AnsiConsole.WriteLine($"Bootstrapping genocs Blazor WebAssembly solution at '{projectName}' ...");
        await RunDotNetAsync(["new", "gnx-blazor", "-n", projectName, "-o", projectName, "-v=q"], cancellationToken);
        AnsiConsole.MarkupLine($"[green]Genocs blazor solution '{Markup.Escape(projectName)}' successfully created.[/]");
        AnsiConsole.MarkupLine("Refer to [link]https://genocs-blog.netlify.app/[/]");
    }

    private static void ValidateProjectName(string projectName)
    {
        if (string.IsNullOrWhiteSpace(projectName))
            throw new ArgumentException("Project name cannot be empty.", nameof(projectName));

        if (!ValidProjectNameRegex.IsMatch(projectName))
        {
            throw new ArgumentException(
                $"Project name '{projectName}' contains invalid characters. " +
                "Use only letters, digits, underscores, hyphens, and dots, starting with a letter or underscore.",
                nameof(projectName));
        }
    }

    private static async Task RunDotNetAsync(string[] arguments, CancellationToken cancellationToken)
    {
        var psi = new ProcessStartInfo
        {
            FileName = ResolveDotNetPath(),
            UseShellExecute = false,
        };

        foreach (string arg in arguments)
        {
            psi.ArgumentList.Add(arg);
        }

        using var proc = Process.Start(psi) ?? throw new InvalidOperationException("Could not start the dotnet process.");

        try
        {
            await proc.WaitForExitAsync(cancellationToken);
        }
        catch (OperationCanceledException)
        {
            try
            {
                proc.Kill(entireProcessTree: true);
            }
            catch (InvalidOperationException) { /* process already exited — nothing to kill */ }
            throw;
        }

        if (proc.ExitCode != 0)
        {
            throw new InvalidOperationException($"dotnet exited with code {proc.ExitCode}.");
        }
    }

    private static string ResolveDotNetPath()
    {
        string exeName = OperatingSystem.IsWindows() ? "dotnet.exe" : "dotnet";

        // 1. Same installation as the runtime currently executing this CLI
        string? runtimeDir = RuntimeEnvironment.GetRuntimeDirectory()
            .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

        // .../dotnet/shared/Microsoft.NETCore.App/<version> -> .../dotnet
        string? root = Directory.GetParent(runtimeDir)?.Parent?.Parent?.FullName;
        if (root is not null)
        {
            string? candidate = Path.Combine(root, exeName);
            if (File.Exists(candidate)) return candidate;
        }

        // 2. DOTNET_ROOT, if the user or installer defined it
        string? dotnetRoot = Environment.GetEnvironmentVariable("DOTNET_ROOT");
        if (!string.IsNullOrWhiteSpace(dotnetRoot))
        {
            string? candidate = Path.Combine(dotnetRoot, exeName);
            if (File.Exists(candidate)) return candidate;
        }

        // 3. Well-known default install location
        string? defaultRoot = OperatingSystem.IsWindows()
            ? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "dotnet")
            : OperatingSystem.IsMacOS() ? "/usr/local/share/dotnet" : "/usr/share/dotnet";

        string? fallback = Path.Combine(defaultRoot, exeName);
        if (File.Exists(fallback)) return fallback;

        throw new FileNotFoundException("Unable to locate the dotnet executable.", fallback);
    }
}

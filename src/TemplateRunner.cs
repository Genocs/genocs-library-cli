using System.Diagnostics;
using System.Text.RegularExpressions;
using Spectre.Console;

namespace Genocs.CLI;

internal static class TemplateRunner
{
    // Allows letters, digits, underscores, hyphens, and dots; must start with a letter or underscore.
    private static readonly Regex ValidProjectNameRegex =
        new(@"^[a-zA-Z_][a-zA-Z0-9_\-\.]*$", RegexOptions.Compiled);

    internal static async Task InstallTemplatesAsync(CancellationToken cancellationToken)
    {
        AnsiConsole.MarkupLine("[green]Installing genocs dotnet Clean Architecture template...[/]");
        await RunDotNetAsync(["new", "install", "Genocs.CleanArchitectureTemplate::2.1.0"], cancellationToken).ConfigureAwait(false);

        AnsiConsole.WriteLine("Installing Genocs Microservice template...");
        await RunDotNetAsync(["new", "install", "Genocs.WebApiTemplate::1.0.3"], cancellationToken).ConfigureAwait(false);

        AnsiConsole.WriteLine("Installing Genocs Blazor template...");
        await RunDotNetAsync(["new", "install", "Genocs.MicroserviceTemplate::0.1.0"], cancellationToken).ConfigureAwait(false);

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
        await RunDotNetAsync(["new", "cleanarchitecture", "-n", projectName, "-o", projectName, "-v=q"], cancellationToken).ConfigureAwait(false);
        AnsiConsole.MarkupLine($"[green]Genocs Clean Architecture solution '{Markup.Escape(projectName)}' successfully created.[/]");
        AnsiConsole.MarkupLine("Refer to [link]https://genocs-blog.netlify.app/[/]");
    }

    internal static async Task BootstrapMicroserviceAsync(string projectName, CancellationToken cancellationToken)
    {
        ValidateProjectName(projectName);
        AnsiConsole.WriteLine($"Bootstrapping genocs Microservice project at '{projectName}' ...");
        await RunDotNetAsync(["new", "gnx-webapi", "-n", projectName, "-o", projectName, "-v=q"], cancellationToken).ConfigureAwait(false);
        AnsiConsole.MarkupLine($"[green]Genocs Microservice solution '{Markup.Escape(projectName)}' successfully created.[/]");
        AnsiConsole.MarkupLine("Refer to [link]https://genocs-blog.netlify.app/[/]");
    }

    internal static async Task BootstrapBlazorAsync(string projectName, CancellationToken cancellationToken)
    {
        ValidateProjectName(projectName);
        AnsiConsole.WriteLine($"Bootstrapping genocs Blazor WebAssembly solution at '{projectName}' ...");
        await RunDotNetAsync(["new", "gnx-blazor", "-n", projectName, "-o", projectName, "-v=q"], cancellationToken).ConfigureAwait(false);
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
            FileName = "dotnet",
            UseShellExecute = false,
        };

        foreach (var arg in arguments)
        {
            psi.ArgumentList.Add(arg);
        }

        using var proc = Process.Start(psi) ?? throw new InvalidOperationException("Could not start the dotnet process.");

        try
        {
            await proc.WaitForExitAsync(cancellationToken).ConfigureAwait(false);
        }
        catch (OperationCanceledException)
        {
            try { proc.Kill(entireProcessTree: true); }
            catch (InvalidOperationException) { /* process already exited — nothing to kill */ }
            throw;
        }

        if (proc.ExitCode != 0)
        {
            throw new InvalidOperationException($"dotnet exited with code {proc.ExitCode}.");
        }
    }
}

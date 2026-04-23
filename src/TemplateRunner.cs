using System.Diagnostics;
using Spectre.Console;

namespace Genocs.CLI;

internal static class TemplateRunner
{
    internal static async Task InstallTemplatesAsync(CancellationToken cancellationToken)
    {
        AnsiConsole.MarkupLine("[green]Installing genocs dotnet Clean Architecture template...[/]");
        await RunDotNetAsync("new install Genocs.CleanArchitectureTemplate::2.1.0", cancellationToken).ConfigureAwait(false);

        AnsiConsole.WriteLine("Installing Genocs Microservice template...");
        await RunDotNetAsync("new install Genocs.WebApiTemplate::1.0.3", cancellationToken).ConfigureAwait(false);

        AnsiConsole.WriteLine("Installing Genocs Blazor template...");
        await RunDotNetAsync("new install Genocs.MicroserviceTemplate::0.1.0", cancellationToken).ConfigureAwait(false);

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
        AnsiConsole.WriteLine($"Bootstrapping genocs Clean Architecture project at '{projectName}' ...");
        await RunDotNetAsync($"new cleanarchitecture -n {projectName} -o {projectName} -v=q", cancellationToken).ConfigureAwait(false);
        AnsiConsole.MarkupLine($"[green]Genocs Clean Architecture solution '{Markup.Escape(projectName)}' successfully created.[/]");
        AnsiConsole.MarkupLine("Refer to [link]https://genocs-blog.netlify.app/[/]");
    }

    internal static async Task BootstrapMicroserviceAsync(string projectName, CancellationToken cancellationToken)
    {
        AnsiConsole.WriteLine($"Bootstrapping genocs Microservice project at '{projectName}' ...");
        await RunDotNetAsync($"new gnx-webapi -n {projectName} -o {projectName} -v=q", cancellationToken).ConfigureAwait(false);
        AnsiConsole.MarkupLine($"[green]Genocs Microservice solution '{Markup.Escape(projectName)}' successfully created.[/]");
        AnsiConsole.MarkupLine("Refer to [link]https://genocs-blog.netlify.app/[/]");
    }

    internal static async Task BootstrapBlazorAsync(string projectName, CancellationToken cancellationToken)
    {
        AnsiConsole.WriteLine($"Bootstrapping genocs Blazor WebAssembly solution at '{projectName}' ...");
        await RunDotNetAsync($"new gnx-blazor -n {projectName} -o {projectName} -v=q", cancellationToken).ConfigureAwait(false);
        AnsiConsole.MarkupLine($"[green]Genocs blazor solution '{Markup.Escape(projectName)}' successfully created.[/]");
        AnsiConsole.MarkupLine("Refer to [link]https://genocs-blog.netlify.app/[/]");
    }

    private static async Task RunDotNetAsync(string arguments, CancellationToken cancellationToken)
    {
        var psi = new ProcessStartInfo
        {
            FileName = "dotnet",
            Arguments = arguments,
            UseShellExecute = false,
        };

        using var proc = Process.Start(psi) ?? throw new InvalidOperationException("Could not start the dotnet process.");
        await proc.WaitForExitAsync(cancellationToken).ConfigureAwait(false);
    }
}

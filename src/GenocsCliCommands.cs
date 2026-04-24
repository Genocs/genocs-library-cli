using System.ComponentModel;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Genocs.CLI;

[Description("Print the application version.")]
internal sealed class VersionCommand : Command<EmptyCommandSettings>
{
    protected override int Execute(CommandContext context, EmptyCommandSettings settings, CancellationToken cancellationToken)
    {
        AnsiConsole.WriteLine(ToolVersion.GetInformationalVersion());
        return 0;
    }
}

internal sealed class NewProjectSettings : CommandSettings
{
    [CommandArgument(0, "<projectName>")]
    [Description("Company.Project or service name.")]
    public required string ProjectName { get; init; }
}

[Description("Show usage and the genocs banner.")]
internal sealed class WelcomeCommand : Command<EmptyCommandSettings>
{
    protected override int Execute(CommandContext context, EmptyCommandSettings settings, CancellationToken cancellationToken)
    {
        CliPresentation.ShowBanner();
        CliPresentation.WriteUsage();
        return 0;
    }
}

[Description("Install or update Genocs dotnet templates.")]
internal sealed class InstallCommand : AsyncCommand<EmptyCommandSettings>
{
    protected override async Task<int> ExecuteAsync(CommandContext context, EmptyCommandSettings settings, CancellationToken cancellationToken)
    {
        await TemplateRunner.InstallTemplatesAsync(cancellationToken).ConfigureAwait(false);
        return 0;
    }
}

[Description("Create a new Angular solution from template.")]
internal sealed class AngularNewCommand : AsyncCommand<NewProjectSettings>
{
    protected override async Task<int> ExecuteAsync(CommandContext context, NewProjectSettings settings, CancellationToken cancellationToken)
    {
        string name = settings.ProjectName.Trim().ToCapitalCase();
        await TemplateRunner.BootstrapAngularAsync(name, cancellationToken).ConfigureAwait(false);
        return 0;
    }
}

[Description("Create a new React solution from template.")]
internal sealed class ReactNewCommand : AsyncCommand<NewProjectSettings>
{
    protected override async Task<int> ExecuteAsync(CommandContext context, NewProjectSettings settings, CancellationToken cancellationToken)
    {
        string name = settings.ProjectName.Trim().ToCapitalCase();
        await TemplateRunner.BootstrapReactAsync(name, cancellationToken).ConfigureAwait(false);
        return 0;
    }
}

[Description("Create a new Blazor WebAssembly solution.")]
internal sealed class BlazorNewCommand : AsyncCommand<NewProjectSettings>
{
    protected override async Task<int> ExecuteAsync(CommandContext context, NewProjectSettings settings, CancellationToken cancellationToken)
    {
        string name = settings.ProjectName.Trim().ToCapitalCase();
        await TemplateRunner.BootstrapBlazorWasmAsync(name, cancellationToken).ConfigureAwait(false);
        return 0;
    }
}

[Description("Create a new worker project.")]
internal sealed class WorkerNewCommand : AsyncCommand<NewProjectSettings>
{
    protected override async Task<int> ExecuteAsync(CommandContext context, NewProjectSettings settings, CancellationToken cancellationToken)
    {
        string name = settings.ProjectName.Trim().ToCapitalCase();
        await TemplateRunner.BootstrapWorkerAsync(name, cancellationToken).ConfigureAwait(false);
        return 0;
    }
}

[Description("Create a new Web API microservice.")]
internal sealed class WebApiNewCommand : AsyncCommand<NewProjectSettings>
{
    protected override async Task<int> ExecuteAsync(CommandContext context, NewProjectSettings settings, CancellationToken cancellationToken)
    {
        string name = settings.ProjectName.Trim().ToCapitalCase();
        await TemplateRunner.BootstrapMicroserviceAsync(name, cancellationToken).ConfigureAwait(false);
        return 0;
    }
}

[Description("Create a new Clean Architecture solution.")]
internal sealed class CleanApiNewCommand : AsyncCommand<NewProjectSettings>
{
    protected override async Task<int> ExecuteAsync(CommandContext context, NewProjectSettings settings, CancellationToken cancellationToken)
    {
        string name = settings.ProjectName.Trim().ToCapitalCase();
        await TemplateRunner.BootstrapCleanArchitectureAsync(name, cancellationToken).ConfigureAwait(false);
        return 0;
    }
}

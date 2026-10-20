using System.ComponentModel;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Genocs.Cli;

[Description("Print the application version.")]
internal sealed class VersionCommand : Command<EmptyCommandSettings>
{
    public override int Execute(CommandContext context, EmptyCommandSettings settings, CancellationToken cancellationToken)
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

[Description("Show usage")]
internal sealed class WelcomeCommand : Command<EmptyCommandSettings>
{
    public override int Execute(CommandContext context, EmptyCommandSettings settings, CancellationToken cancellationToken)
    {
        CliPresentation.ShowBanner();
        CliPresentation.WriteUsage();
        return 0;
    }
}

[Description("Install or update Genocs templates.")]
internal sealed class InstallCommand : AsyncCommand<EmptyCommandSettings>
{
    public override async Task<int> ExecuteAsync(CommandContext context, EmptyCommandSettings settings, CancellationToken cancellationToken)
    {
        await TemplateRunner.InstallTemplatesAsync(cancellationToken);
        return 0;
    }
}

[Description("Create a new Angular solution from template.")]
internal sealed class AngularNewCommand : AsyncCommand<NewProjectSettings>
{
    public override async Task<int> ExecuteAsync(CommandContext context, NewProjectSettings settings, CancellationToken cancellationToken)
    {
        string name = settings.ProjectName.Trim().ToCapitalCase();
        await TemplateRunner.BootstrapAngularAsync(name, cancellationToken);
        return 0;
    }
}

[Description("Create a new React solution from template.")]
internal sealed class ReactNewCommand : AsyncCommand<NewProjectSettings>
{
    public override async Task<int> ExecuteAsync(CommandContext context, NewProjectSettings settings, CancellationToken cancellationToken)
    {
        string name = settings.ProjectName.Trim().ToCapitalCase();
        await TemplateRunner.BootstrapReactAsync(name, cancellationToken);
        return 0;
    }
}

[Description("Create a new Blazor WebAssembly solution.")]
internal sealed class BlazorNewCommand : AsyncCommand<NewProjectSettings>
{
    public override async Task<int> ExecuteAsync(CommandContext context, NewProjectSettings settings, CancellationToken cancellationToken)
    {
        string name = settings.ProjectName.Trim().ToCapitalCase();
        await TemplateRunner.BootstrapBlazorWasmAsync(name, cancellationToken);
        return 0;
    }
}

[Description("Create a new worker project.")]
internal sealed class WorkerNewCommand : AsyncCommand<NewProjectSettings>
{
    public override async Task<int> ExecuteAsync(CommandContext context, NewProjectSettings settings, CancellationToken cancellationToken)
    {
        string name = settings.ProjectName.Trim().ToCapitalCase();
        await TemplateRunner.BootstrapWorkerAsync(name, cancellationToken);
        return 0;
    }
}

[Description("Create a new Web API microservice.")]
internal sealed class WebApiNewCommand : AsyncCommand<NewProjectSettings>
{
    public override async Task<int> ExecuteAsync(CommandContext context, NewProjectSettings settings, CancellationToken cancellationToken)
    {
        string name = settings.ProjectName.Trim().ToCapitalCase();
        await TemplateRunner.BootstrapMicroserviceAsync(name, cancellationToken);
        return 0;
    }
}

[Description("Create a new Clean Architecture solution.")]
internal sealed class CleanApiNewCommand : AsyncCommand<NewProjectSettings>
{
    public override async Task<int> ExecuteAsync(CommandContext context, NewProjectSettings settings, CancellationToken cancellationToken)
    {
        string name = settings.ProjectName.Trim().ToCapitalCase();
        await TemplateRunner.BootstrapCleanArchitectureAsync(name, cancellationToken);
        return 0;
    }
}

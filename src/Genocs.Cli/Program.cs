using Spectre.Console.Cli;

namespace Genocs.Cli;

internal static class Program
{
    private static int Main(string[] args)
    {
        var app = new CommandApp<WelcomeCommand>();
        app.Configure(config =>
        {
            config.SetApplicationName("genocs");
            config.UseAssemblyInformationalVersion();

            config.AddCommand<VersionCommand>("version");

            config.AddCommand<InstallCommand>("install")
                .WithAlias("i")
                .WithAlias("update")
                .WithAlias("u");

            config.AddBranch("angular", branch =>
            {
                branch.SetDescription("Scaffold an Angular application.");
                branch.AddCommand<AngularNewCommand>("new").WithAlias("n");
            });

            config.AddBranch("react", branch =>
            {
                branch.SetDescription("Scaffold a React application.");
                branch.AddCommand<ReactNewCommand>("new").WithAlias("n");
            });

            config.AddBranch("blazor", branch =>
            {
                branch.SetDescription("Scaffold a Blazor WebAssembly application.");
                branch.AddCommand<BlazorNewCommand>("new").WithAlias("n");
            });

            config.AddBranch("worker", branch =>
            {
                branch.SetDescription("Scaffold a worker application.");
                branch.AddCommand<WorkerNewCommand>("new").WithAlias("n");
            });

            config.AddBranch("webapi", branch =>
            {
                branch.SetDescription("Scaffold a Web API microservice.");
                branch.AddCommand<WebApiNewCommand>("new").WithAlias("n");
            });

            config.AddBranch("cleanapi", branch =>
            {
                branch.SetDescription("Scaffold a Clean Architecture solution.");
                branch.AddCommand<CleanApiNewCommand>("new").WithAlias("n");
            });
        });

        return app.Run(args);
    }
}

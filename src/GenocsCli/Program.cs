using Spectre.Console.Cli;

namespace Genocs.CLI;

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
                branch.SetDescription("Angular template commands.");
                branch.AddCommand<AngularNewCommand>("new").WithAlias("n");
            });

            config.AddBranch("react", branch =>
            {
                branch.SetDescription("React template commands.");
                branch.AddCommand<ReactNewCommand>("new").WithAlias("n");
            });

            config.AddBranch("blazor", branch =>
            {
                branch.SetDescription("Blazor WebAssembly template commands.");
                branch.AddCommand<BlazorNewCommand>("new").WithAlias("n");
            });

            config.AddBranch("worker", branch =>
            {
                branch.SetDescription("Worker template commands.");
                branch.AddCommand<WorkerNewCommand>("new").WithAlias("n");
            });

            config.AddBranch("webapi", branch =>
            {
                branch.SetDescription("Web API microservice template commands.");
                branch.AddCommand<WebApiNewCommand>("new").WithAlias("n");
            });

            config.AddBranch("cleanapi", branch =>
            {
                branch.SetDescription("Clean Architecture template commands.");
                branch.AddCommand<CleanApiNewCommand>("new").WithAlias("n");
            });
        });

        return app.Run(args);
    }
}

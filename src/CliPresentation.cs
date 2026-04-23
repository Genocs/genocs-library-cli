using Spectre.Console;

namespace Genocs.CLI;

internal static class CliPresentation
{
    internal static void ShowBanner()
    {
        const string art = @"
..######...########.##....##..#######...######...######............######..##.......####
.##....##..##.......###...##.##.....##.##....##.##....##..........##....##.##........##.
.##........##.......####..##.##.....##.##.......##................##.......##........##.
.##...####.######...##.##.##.##.....##.##........######...........##.......##........##.
.##....##..##.......##..####.##.....##.##.............##..........##.......##........##.
.##....##..##.......##...###.##.....##.##....##.##....##..........##....##.##........##.
..######...########.##....##..#######...######...######............######..########.####
";
        foreach (string line in art.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries))
        {
            AnsiConsole.Write(new Text(line, new Style(foreground: Color.Blue)));
            AnsiConsole.WriteLine();
        }
    }

    internal static void WriteUsage()
    {
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine("[yellow]Missing params.[/] Use:");
        AnsiConsole.MarkupLine("  [cyan]genocs install[/] (aliases: [grey]i[/], [grey]update[/], [grey]u[/])");
        AnsiConsole.WriteLine("Then:");
        AnsiConsole.MarkupLine("  [cyan]genocs <template> new <CompanyName.ProjectName.ServiceName>[/]");
        AnsiConsole.MarkupLine("  [cyan]genocs <template> new <ServiceName>[/]");
        AnsiConsole.MarkupLine("Templates: [grey]blazor[/], [grey]webapi[/], [grey]worker[/], [grey]cleanapi[/], [grey]angular[/], [grey]react[/]");
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine("See [link]https://genocs-blog.netlify.app/[/]");
    }

    internal static void WritePostInstallHint()
    {
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine("Get started:");
        AnsiConsole.MarkupLine("  [cyan]genocs <template> new <CompanyName.ProjectName.ServiceName>[/]");
        AnsiConsole.MarkupLine("  [cyan]genocs <template> new <ServiceName>[/]");
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine("See [link]https://genocs-blog.netlify.app/[/]");
    }
}

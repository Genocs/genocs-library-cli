// See https://aka.ms/new-console-template for more information

using Genocs.CLI;
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;

if (args.Length == 0)
{
    ShowBot(string.Empty);
    return;
}

// var version = Assembly.GetEntryAssembly()?
//                        .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
//                        .InformationalVersion;

// WriteColorConsole(Figgle.FiggleFonts.Doom.Render($"genocs v{version}"), ConsoleColor.DarkGreen);

string firstArg = args[0].Trim().ToLower();
if (firstArg == "install" || firstArg == "i" || firstArg == "update" || firstArg == "u")
{
    await InstallTemplates();
    return;
}

if (firstArg == "angular")
{
    if (args.Length != 3)
    {
        Console.WriteLine("Invalid command. Use something like: genocs angular new <CompanyName.ProjectName>");
        return;
    }

    string command = args[1].Trim().ToLower();
    string projectName = args[2].Trim().ToCapitalCase();

    if (command == "n" || command == "new")
    {
        await BootstrapAngularSolutionAsync(projectName);
    }

    return;
}

if (firstArg == "react")
{
    if (args.Length != 3)
    {
        Console.WriteLine("Invalid command. Use something like: genocs react new <CompanyName.ProjectName>");
        return;
    }

    string command = args[1].Trim().ToLower();
    string projectName = args[2].Trim().ToCapitalCase();

    if (command == "n" || command == "new")
    {
        await BootstrapReactSolutionAsync(projectName);
    }

    return;
}

if (firstArg == "blazor-clean")
{
    if (args.Length != 3)
    {
        Console.WriteLine("Invalid command. Use something like: genocs blazor-clean n <CompanyName.ProjectName>");
        return;
    }

    string command = args[1].Trim().ToLower();
    string projectName = args[2].Trim().ToCapitalCase();

    if (command == "n" || command == "new")
    {
        await BootstrapBlazorCleanSolutionAsync(projectName);
    }

    return;
}

if (firstArg == "blazor-wasm")
{
    if (args.Length != 3)
    {
        Console.WriteLine("Invalid command. Use something like: genocs blazor-wasm n <CompanyName.ProjectName>");
        return;
    }

    string command = args[1].Trim().ToLower();
    string projectName = args[2].Trim().ToCapitalCase();

    if (command == "n" || command == "new")
    {
        await BootstrapBlazorWasmSolutionAsync(projectName);
    }

    return;
}

if (firstArg == "clean-webapi")
{
    if (args.Length != 3)
    {
        Console.WriteLine("Invalid command. Use something like: genocs clean-webapi new <CompanyName.ProjectName>");
        return;
    }

    string command = args[1].Trim().ToLower();
    string projectName = args[2].Trim().ToCapitalCase();

    if (command == "n" || command == "new")
    {
        await BootstrapCleanWebApiSolutionAsync(projectName);
    }

    return;
}

if (firstArg == "libra-webapi")
{
    if (args.Length != 3)
    {
        Console.WriteLine("Invalid command. Use something like: genocs libra-webapi new <CompanyName.ProjectName>");
        return;
    }

    string command = args[1].Trim().ToLower();
    string projectName = args[2].Trim().ToCapitalCase();

    if (command == "n" || command == "new")
    {
        await BootstrapLibraWebApiSolution(projectName);
    }

    return;
}

if (firstArg == "micro-webapi")
{
    if (args.Length != 3)
    {
        Console.WriteLine("Invalid command. Use something like: genocs micro-webapi new <CompanyName.ProjectName>");
        return;
    }

    string command = args[1].Trim().ToLower();
    string projectName = args[2].Trim().ToCapitalCase();

    if (command == "n" || command == "new")
    {
        await BootstrapMicroWebApiSolution(projectName);
    }

    return;
}

if (firstArg == "h" || firstArg == "help")
{
    WriteColorConsole("    genocs [i|install|u|update]", ConsoleColor.Cyan);
    Console.WriteLine("then follow with:");
    WriteColorConsole("    genocs [blazor-clean|blazor-wasm|clean-webapi|libra-webapi|micro-webapi|angular|react] [n|new] <CompanyName.ProjectName.ServiceName>", ConsoleColor.Cyan);
    Console.WriteLine("\nPlease refer to https://learn.fiscanner.net/");

    return;
}

// Fallback
WriteColorConsole("Sorry I don't understand your command!", ConsoleColor.DarkRed);
WriteColorConsole("Accepted syntax is something like:", ConsoleColor.Cyan);
WriteColorConsole("    genocs [i|install|u|update]", ConsoleColor.Cyan);
return;

static void ShowBot(string message)
{
    string bot = $"\n        {message}";
    bot += @"
..######...########.##....##..#######...######...######............######..##.......####
.##....##..##.......###...##.##.....##.##....##.##....##..........##....##.##........##.
.##........##.......####..##.##.....##.##.......##................##.......##........##.
.##...####.######...##.##.##.##.....##.##........######...........##.......##........##.
.##....##..##.......##..####.##.....##.##.............##..........##.......##........##.
.##....##..##.......##...###.##.....##.##....##.##....##..........##....##.##........##.
..######...########.##....##..#######...######...######............######..########.####
";
    WriteColorConsole(bot, ConsoleColor.Blue);
    WriteColorConsole($"Runtime: {Environment.Version}", ConsoleColor.DarkGreen);
    WriteColorConsole($"Version: {Assembly.GetExecutingAssembly().GetName().Version}", ConsoleColor.DarkGreen);
    WriteColorConsole($"Please type: 'genocs help' to get more info.", ConsoleColor.Blue);

}

static void WriteColor(string message, ConsoleColor color)
{
    string[] pieces = Regex.Split(message, @"(\[[^\]]*\])");

    for (int i = 0; i < pieces.Length; i++)
    {
        string piece = pieces[i];

        if (piece.StartsWith("[") && piece.EndsWith("]"))
        {
            Console.ForegroundColor = color;
            piece = piece.Substring(1, piece.Length - 2);
        }

        Console.Write(piece);
        Console.ResetColor();
    }

    Console.WriteLine();
}

async Task InstallTemplates()
{
    foreach (string template in MainResource.Templates.Split(",").ToList())
    {
        Console.WriteLine($"Installing {template} template...");
        var psi = new ProcessStartInfo
        {
            FileName = "dotnet",
            Arguments = $"new install {template}"
        };

        using var proc = Process.Start(psi)!;
        await proc.WaitForExitAsync();
    }

    WriteSuccessMessage("Templates installed successfully.");
    WriteSuccessMessage("Type: dotnet new list to see the whole set of dotnet templates.");

    Console.WriteLine("Get started by typing:");
    WriteColorConsole("    genocs [blazor-clean|blazor-wasm|clean-webapi|libra-webapi|micro-webapi|angular|react] [n|new] <CompanyName.ProjectName.ServiceName>", ConsoleColor.Cyan);
    Console.WriteLine("\nPlease refer to https://learn.fiscanner.net/");
}

async Task BootstrapAngularSolutionAsync(string projectName)
{
    Console.WriteLine($"Angular Template not available ...");
    await Task.CompletedTask;
}

async Task BootstrapReactSolutionAsync(string projectName)
{
    Console.WriteLine($"React Template not available ...");
    await Task.CompletedTask;
}

async Task BootstrapBlazorCleanSolutionAsync(string projectName)
{
    Console.WriteLine($"Bootstrapping Blazor Clean WebAssembly Solution at '{projectName}' ...");
    var psi = new ProcessStartInfo
    {
        FileName = "dotnet",
        Arguments = $"new gnx-blazorclean -n {projectName} -o {projectName} -v=q"
    };

    using var proc = Process.Start(psi)!;
    await proc.WaitForExitAsync();
    WriteSuccessMessage($"Blazor Clean WebAssembly Solution '{projectName}' successfully created.");
    Console.WriteLine("Refer to documentation at https://learn.fiscanner.net/");
}

async Task BootstrapBlazorWasmSolutionAsync(string projectName)
{
    Console.WriteLine($"Bootstrapping Blazor WebAssembly Solution at '{projectName}' ...");
    var psi = new ProcessStartInfo
    {
        FileName = "dotnet",
        Arguments = $"new gnx-blazorwasm -n {projectName} -o {projectName} -v=q"
    };

    using var proc = Process.Start(psi)!;
    await proc.WaitForExitAsync();
    WriteSuccessMessage($"Blazor WebAssembly Solution '{projectName}' successfully created.");
    Console.WriteLine("Refer to documentation at https://learn.fiscanner.net/");
}

async Task BootstrapCleanWebApiSolutionAsync(string projectName)
{
    Console.WriteLine($"Bootstrapping Microservice (Clean Architecture - Onion) solution at '{projectName}' ...");
    var psi = new ProcessStartInfo
    {
        FileName = "dotnet",
        Arguments = $"new cleanarchitecture -n {projectName} -o {projectName} -v=q"
    };
    using var proc = Process.Start(psi)!;
    await proc.WaitForExitAsync();
    WriteSuccessMessage($"Microservice (Clean Architecture - Onion) Solution '{projectName}' successfully created.");
    Console.WriteLine("Refer to documentation at https://learn.fiscanner.net/");
}

async Task BootstrapLibraWebApiSolution(string projectName)
{
    Console.WriteLine($"Bootstrapping Microservice (with Genocs library) Solution at '{projectName}' ...");
    var psi = new ProcessStartInfo
    {
        FileName = "dotnet",
        Arguments = $"new gnx-librawebapi -n {projectName} -o {projectName} -v=q"
    };
    using var proc = Process.Start(psi)!;
    await proc.WaitForExitAsync();
    WriteSuccessMessage($"Microservice (with Genocs Library) solution '{projectName}' successfully created.");
    Console.WriteLine("Refer to documentation at https://learn.fiscanner.net/");
}

async Task BootstrapMicroWebApiSolution(string projectName)
{
    Console.WriteLine($"Bootstrapping Microservice (with Multitenancy) solution at '{projectName}' ...");
    var psi = new ProcessStartInfo
    {
        FileName = "dotnet",
        Arguments = $"new gnx-microservice -n {projectName} -o {projectName} -v=q"
    };
    using var proc = Process.Start(psi)!;
    await proc.WaitForExitAsync();
    WriteSuccessMessage($"Microservice (with Multitenancy) Solution '{projectName}' successfully created.");
    Console.WriteLine("Refer to documentation at https://learn.fiscanner.net/");
}

static void WriteColorConsole(string message, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine(message);
    Console.ResetColor();
}

static void WriteSuccessMessage(string message)
{
    WriteColorConsole(message, ConsoleColor.Green);
}

static void WriteColorEx(string str, params (string SubString, ConsoleColor Color)[] colors)
{
    string[] words = Regex.Split(str, @"( )");

    foreach (string word in words)
    {
        (string SubString, ConsoleColor Color) cl = colors.FirstOrDefault(x => x.SubString.Equals("{" + word + "}"));
        if (cl.SubString != null)
        {
            Console.ForegroundColor = cl.Color;
            Console.Write(cl.SubString.Substring(1, cl.SubString.Length - 2));
            Console.ResetColor();
        }
        else
        {
            Console.Write(word);
        }
    }
}

Console.WriteLine("Invalid params. Use following syntax:");
WriteColorConsole("    genocs [i|install|u|update", ConsoleColor.Cyan);
Console.WriteLine("Than follow with:");
WriteColorConsole("    genocs [blazor|webapi|worker|cleanapi|angular|react] [n|new] <CompanyName.ProjectName.ServiceName>", ConsoleColor.Cyan);
Console.WriteLine("or with:");
WriteColorConsole("    genocs [blazor|webapi|worker|cleanapi|angular|react] [n|new] <ServiceName>", ConsoleColor.Cyan);
Console.WriteLine("\nPlease refer to https://learn.fiscanner.net/");

// WriteColorEx("This is my message with new color with red", ("{message}", ConsoleColor.Red), ("{with}", ConsoleColor.Blue));
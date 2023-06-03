// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;


if (args.Length == 0)
{
    ShowBot("Hello!!!");
    Console.WriteLine("Missing params. Use following syntax:");
    WriteColorConsole("    genocs [i|install|u|update", ConsoleColor.Cyan);
    Console.WriteLine("Than follow with:");
    WriteColorConsole("    genocs [blazor|webapi|worker|cleanapi|angular|react] [n|new] <CompanyName.ProjectName.ServiceName>", ConsoleColor.Cyan);
    Console.WriteLine("or with:");
    WriteColorConsole("    genocs [blazor|webapi|worker|cleanapi|angular|react] [n|new] <ServiceName>", ConsoleColor.Cyan);
    Console.WriteLine("\nPlease refer to https://genocs-blog.netlify.app/");
    return;
}

var version = Assembly.GetEntryAssembly()?
                        .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
                        .InformationalVersion;

WriteColorConsole(Figgle.FiggleFonts.Doom.Render($"genocs v{version}"), ConsoleColor.DarkGreen);


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
    // Convert to Capital case
    string projectName = args[2].Trim().ToLower();
    if (command == "n" || command == "new")
    {
        await BootstrapAngularSolution(projectName);
    }

    return;
}

if (firstArg == "blazor")
{
    if (args.Length != 3)
    {
        Console.WriteLine("Invalid command. Use something like: genocs blazor new <CompanyName.ProjectName>");
        return;
    }

    string command = args[1].Trim().ToLower();
    // Convert to Capital case
    string projectName = args[2].Trim().ToLower();
    if (command == "n" || command == "new")
    {
        await BootstrapBlazorSolution(projectName);
    }

    return;
}

if (firstArg == "worker")
{
    if (args.Length != 3)
    {
        Console.WriteLine("Invalid command. Use something like: genocs worker new <CompanyName.ProjectName>");
        return;
    }

    string command = args[1].Trim().ToLower();
    // Convert to Capital case
    string projectName = args[2].Trim().ToLower();
    if (command == "n" || command == "new")
    {
        await BootstrapBlazorSolution(projectName);
    }

    return;
}

if (firstArg == "webapi")
{
    if (args.Length != 3)
    {
        Console.WriteLine("Invalid command. Use something like: genocs webapi new <CompanyName.ProjectName>");
        return;
    }

    string command = args[1].Trim().ToLower();
    // Convert to Capital case
    string projectName = args[2].Trim().ToLower();
    if (command == "n" || command == "new")
    {
        await BootstrapMicroserviceSolution(projectName);
    }

    return;
}

if (firstArg == "cleanapi")
{
    if (args.Length != 3)
    {
        Console.WriteLine("Invalid command. Use something like: genocs cleanapi new <CompanyName.ProjectName>");
        return;
    }

    string command = args[1].Trim().ToLower();
    // Convert to Capital case
    // Convert to Capital case
    string projectName = args[2].Trim().ToLower();
    if (command == "n" || command == "new")
    {
        await BootstrapCleanArchitectureSolution(projectName);
    }

    return;
}


static void ShowBot(string message)
{
    string bot = $"\n        {message}";
    bot += @"
    __________________
                      \
                       \
                          ....
                          ....'
                           ....
                        ..........
                    .............'..'..
                 ................'..'.....
               .......'..........'..'..'....
              ........'..........'..'..'.....
             .'....'..'..........'..'.......'.
             .'..................'...   ......
             .  ......'.........         .....
             .    _            __        ......
            ..    #            ##        ......
           ....       .                 .......
           ......  .......          ............
            ................  ......................
            ........................'................
           ......................'..'......    .......
        .........................'..'.....       .......
     ........    ..'.............'..'....      ..........
   ..'..'...      ...............'.......      ..........
  ...'......     ...... ..........  ......         .......
 ...........   .......              ........        ......
.......        '...'.'.              '.'.'.'         ....
.......       .....'..               ..'.....
   ..       ..........               ..'........
          ............               ..............
         .............               '..............
        ...........'..              .'.'............
       ...............              .'.'.............
      .............'..               ..'..'...........
      ...............                 .'..............
       .........                        ..............
        .....
";
    WriteColorConsole(bot, ConsoleColor.Blue);
}

static void WriteColor(string message, ConsoleColor color)
{
    var pieces = Regex.Split(message, @"(\[[^\]]*\])");

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
    WriteSuccessMessage("Installing genocs dotnet Clean Architecture template...");

    var cleanArchitecturePsi = new ProcessStartInfo
    {
        FileName = "dotnet",
        Arguments = "new install Genocs.CleanArchitectureTemplate::2.1.0"
    };

    using var cleanArchitectureProc = Process.Start(cleanArchitecturePsi)!;
    await cleanArchitectureProc.WaitForExitAsync();
    // --------------------------

    Console.WriteLine("Installing Genocs Microservice template...");
    var microservicePsi = new ProcessStartInfo
    {
        FileName = "dotnet",
        Arguments = "new install Genocs.MicroserviceTemplate::0.1.0"
    };

    using var microserviceProc = Process.Start(microservicePsi)!;
    await microserviceProc.WaitForExitAsync();
    // --------------------------

    Console.WriteLine("Installing Genocs Blazor template...");
    var blazorWebAssemblyPsi = new ProcessStartInfo
    {
        FileName = "dotnet",
        Arguments = "new install Genocs.MicroserviceTemplate::0.1.0"
    };

    using var blazorWebAssemblyProc = Process.Start(blazorWebAssemblyPsi)!;
    await blazorWebAssemblyProc.WaitForExitAsync();
    // --------------------------

    WriteSuccessMessage("Installed the required templates.");
    WriteSuccessMessage("Type: dotnet new list to see the whole set of dotnet templates.");

    Console.WriteLine("Get started by typing:");
    WriteColorConsole("    genocs [blazor|webapi|worker|cleanapi|angular|react] [n|new] <CompanyName.ProjectName.ServiceName>", ConsoleColor.Cyan);
    Console.WriteLine("or with:");
    WriteColorConsole("    genocs [blazor|webapi|worker|cleanapi|angular|react] [n|new] <ServiceName>", ConsoleColor.Cyan);
    Console.WriteLine("\nPlease refer to https://genocs-blog.netlify.app/");
}

async Task BootstrapAngularSolution(string projectName)
{
    Console.WriteLine($"Angular Template not available ...");
    await Task.CompletedTask;
}

async Task BootstrapReactSolution(string projectName)
{
    Console.WriteLine($"React Template not available ...");
    await Task.CompletedTask;
}

async Task BootstrapWorkerSolution(string projectName)
{
    Console.WriteLine($"Worker Template not available ...");
    await Task.CompletedTask;
}


async Task BootstrapCleanArchitectureSolution(string projectName)
{
    Console.WriteLine($"Bootstrapping genocs Clean Architecture project at '{projectName}' ...");
    var psi = new ProcessStartInfo
    {
        FileName = "dotnet",
        Arguments = $"new cleanarchitecture -n {projectName} -o {projectName} -v=q"
    };
    using var proc = Process.Start(psi)!;
    await proc.WaitForExitAsync();
    WriteSuccessMessage($"Genocs Clean Architecture solution '{projectName}' successfully created.");
    Console.WriteLine("Refer to documentation at https://genocs-blog.netlify.app/");
}

async Task BootstrapMicroserviceSolution(string projectName)
{
    Console.WriteLine($"Bootstrapping genocs Microservice project at '{projectName}' ...");
    var psi = new ProcessStartInfo
    {
        FileName = "dotnet",
        Arguments = $"new microservice -n {projectName} -o {projectName} -v=q"
    };
    using var proc = Process.Start(psi)!;
    await proc.WaitForExitAsync();
    WriteSuccessMessage($"Genocs Microservice solution '{projectName}' successfully created.");
    Console.WriteLine("Refer to documentation at https://genocs-blog.netlify.app/");
}

async Task BootstrapBlazorSolution(string projectName)
{
    Console.WriteLine($"Bootstrapping genocs Blazor WebAssembly solution at '{projectName}' ...");
    var psi = new ProcessStartInfo
    {
        FileName = "dotnet",
        Arguments = $"new gnx-blazor -n {projectName} -o {projectName} -v=q"
    };

    using var proc = Process.Start(psi)!;
    await proc.WaitForExitAsync();
    WriteSuccessMessage($"Genocs blazor solution '{projectName}' successfully created.");
    Console.WriteLine("Refer to documentation at https://genocs-blog.netlify.app/");
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

static void WriteColorEx(string str, params (string substring, ConsoleColor color)[] colors)
{
    var words = Regex.Split(str, @"( )");

    foreach (var word in words)
    {
        (string substring, ConsoleColor color) cl = colors.FirstOrDefault(x => x.substring.Equals("{" + word + "}"));
        if (cl.substring != null)
        {
            Console.ForegroundColor = cl.color;
            Console.Write(cl.substring.Substring(1, cl.substring.Length - 2));
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
Console.WriteLine("\nPlease refer to https://genocs-blog.netlify.app/");
// WriteColorEx("This is my message with new color with red", ("{message}", ConsoleColor.Red), ("{with}", ConsoleColor.Blue));
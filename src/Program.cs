// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;


var version = Assembly.GetEntryAssembly()?
                        .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
                        .InformationalVersion;

Console.WriteLine($"genocs v{version}");
Console.WriteLine(Figgle.FiggleFonts.Doom.Render($"genocs v{version}"));
ShowBot("Hello!!!");

if (args.Length == 0)
{
    Console.WriteLine("Insufficient params. Please refer to https://blog.genocs.com/dotnet-webapi-boilerplate/general/genocs-api-console");
    return;
}


string firstArg = args[0].Trim().ToLower();
if (firstArg == "install" || firstArg == "i" || firstArg == "update" || firstArg == "u")
{
    await InstallTemplates();
    return;
}

if (firstArg == "cleanarchitecture")
{
    if (args.Length != 3)
    {
        Console.WriteLine("Invalid command. Use something like: genocs cleanarchitecture new <CompanyName.ProjectName>");
        return;
    }

    string command = args[1].Trim().ToLower();
    // Convert to Capital case
    string projectName = args[2].Trim();
    if (command == "n" || command == "new")
    {
        await BootstrapCleanArchitectureSolution(projectName);
    }

    return;
}

if (firstArg == "microservice")
{
    if (args.Length != 3)
    {
        Console.WriteLine("Invalid command. Use something like: genocs microservice new <CompanyName.ProjectName>");
        return;
    }

    string command = args[1].Trim().ToLower();
    // Convert to Capital case
    string projectName = args[2].Trim();
    if (command == "n" || command == "new")
    {
        await BootstrapMicroserviceSolution(projectName);
    }

    return;
}


if (firstArg == "wasm")
{
    if (args.Length != 3)
    {
        Console.WriteLine("Invalid command. Use something like: genocs wasm new <CompanyName.ProjectName>");
        return;
    }

    string command = args[1].Trim().ToLower();
    // Convert to Capital case
    // Convert to Capital case
    string projectName = args[2].Trim();
    if (command == "n" || command == "new")
    {
        await BootstrapBlazorWasmSolution(projectName);
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
    Console.WriteLine(bot);
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

    Console.WriteLine("Installing genocs Microservice template...");
    var microservicePsi = new ProcessStartInfo
    {
        FileName = "dotnet",
        Arguments = "new install Genocs.MicroserviceTemplate::0.1.0"
    };

    using var microserviceProc = Process.Start(microservicePsi)!;
    await microserviceProc.WaitForExitAsync();
    // --------------------------

    Console.WriteLine("Installing genocs blazor wasm template...");
    var blazorWebAssemblyPsi = new ProcessStartInfo
    {
        FileName = "dotnet",
        Arguments = "new install Genocs.MicroserviceTemplate::0.1.0"
    };

    using var blazorWebAssemblyProc = Process.Start(blazorWebAssemblyPsi)!;
    await blazorWebAssemblyProc.WaitForExitAsync();
    // --------------------------

    WriteSuccessMessage("Installed the required templates.");
    Console.WriteLine("Get started by using : genocs <type> new <CompanyName.ProjectName>.");
    Console.WriteLine("NOTE: <type> can be [cleanarchitecture | microservice | blazor].");
    Console.WriteLine("Refer to documentation at https://majestic-wisp-d90424.netlify.app");
}

async Task BootstrapCleanArchitectureSolution(string projectName)
{
    Console.WriteLine($"Bootstrapping genocs Clean Architecture project at \"./{projectName}\"...");
    var psi = new ProcessStartInfo
    {
        FileName = "dotnet",
        Arguments = $"new cleanarchitecture -n {projectName} -o {projectName} -v=q"
    };
    using var proc = Process.Start(psi)!;
    await proc.WaitForExitAsync();
    WriteSuccessMessage($"Genocs Architecture solution {projectName} successfully created.");
    WriteSuccessMessage("Application ready! Build something amazing!");
    Console.WriteLine("Refer to documentation at https://blog.genocs.com/dotnet-webapi-boilerplate/general/getting-started");
}

async Task BootstrapMicroserviceSolution(string projectName)
{
    Console.WriteLine($"Bootstrapping genocs Microservice project at \"./{projectName}\"...");
    var psi = new ProcessStartInfo
    {
        FileName = "dotnet",
        Arguments = $"new microservice -n {projectName} -o {projectName} -v=q"
    };
    using var proc = Process.Start(psi)!;
    await proc.WaitForExitAsync();
    WriteSuccessMessage($"Genocs Microservice solution {projectName} successfully created.");
    WriteSuccessMessage("Application ready! Build something amazing!");
    Console.WriteLine("Refer to documentation at https://blog.genocs.com/dotnet-webapi-boilerplate/general/getting-started");
}

async Task BootstrapBlazorWasmSolution(string projectName)
{
    Console.WriteLine($"Bootstrapping genocs Blazor wasm solution at \"./{projectName}\"...");
    var psi = new ProcessStartInfo
    {
        FileName = "dotnet",
        Arguments = $"new gnx-blazor -n {projectName} -o {projectName} -v=q"
    };

    using var proc = Process.Start(psi)!;
    await proc.WaitForExitAsync();
    WriteSuccessMessage($"Genocs blazor wasm solution {projectName} successfully created.");
    WriteSuccessMessage("Application ready! Build something amazing!");
    Console.WriteLine("Refer to documentation at https://blog.genocs.com/blazor-webassembly-boilerplate/general/getting-started/");
}

static void WriteSuccessMessage(string message)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(message);
    Console.ResetColor();
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

Console.WriteLine("\nUsage:");
Console.WriteLine("  genocs <params>");

// WriteColorEx("This is my message with new color with red", ("{message}", ConsoleColor.Red), ("{with}", ConsoleColor.Blue));

Console.WriteLine("\n");

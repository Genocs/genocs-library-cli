using System.Reflection;

namespace Genocs.CLI;

internal static class ToolVersion
{
    internal static string GetInformationalVersion()
    {
        var assembly = Assembly.GetEntryAssembly() ?? typeof(ToolVersion).Assembly;
        return assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion
            ?? assembly.GetName().Version?.ToString()
            ?? "0.0.0";
    }
}

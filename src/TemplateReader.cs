using System.Text.Json;

using Genocs.CLI;

internal class TemplateReader
{
    /// <summary>
    /// Read template from json file locate in the same folder of the executable.
    /// </summary>
    /// <returns></returns>
    public static List<string>? GetTemplates()
    {
        const string resourceName = "genocs.cli.templates.json";

        // Read json file
        string fileContent = System.IO.File.ReadAllText(resourceName);

        // Deserialize json
        return JsonSerializer.Deserialize<List<string>>(fileContent);
    }
}

internal record Template(string FileName, string Arguments, string Message);

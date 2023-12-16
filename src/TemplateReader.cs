using System.Text.Json;

internal class TemplateReader
{
    /// <summary>
    /// Read template from json file locate in the same folder of the executable.
    /// </summary>
    /// <returns>List of Items.</returns>
    public static List<string>? GetTemplates()
    {
        const string resourceName = "genocs.cli.templates.json";

        // Read json file
        string fileContent = File.ReadAllText(resourceName);

        // Deserialize json
        return JsonSerializer.Deserialize<List<string>>(fileContent);
    }
}

internal record Template(string FileName, string Arguments, string Message);

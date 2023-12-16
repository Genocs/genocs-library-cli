using genocs.cli;

internal class TemplateReader
{
    /// <summary>
    /// Read template from json file locate in the same folder of the executable.
    /// </summary>
    /// <returns>List of Items.</returns>
    public static List<string>? GetTemplates()
    {
        return MainResource.Templates.Split(",").ToList();
    }
}

internal record Template(string FileName, string Arguments, string Message);

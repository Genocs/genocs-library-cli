using System.Text;

namespace Genocs.CLI;

public static class StringExtensions
{
    public static string ToCapitalCase(this string str)
    {
        // Implement capital case logic here
        if (string.IsNullOrWhiteSpace(str))
        {
            return str;
        }

        // Split the string into words separated by a space character or period
        var splitString = str.Trim().Split(' ', '.');
        var sb = new StringBuilder();
        foreach (var word in splitString)
        {
            // Capitalize the first letter of each word
            sb.Append(char.ToUpper(word[0]));
            // Add the rest of the word as is
            sb.Append(word.Substring(1));
            // Add a space character after each word
            sb.Append('.');
        }

        return sb.ToString(0, sb.Length - 1);
    }
}

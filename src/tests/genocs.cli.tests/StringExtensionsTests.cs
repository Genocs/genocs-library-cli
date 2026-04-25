using Genocs.CLI;

namespace genocs.cli.tests;

public sealed class StringExtensionsTests
{
    [Theory]
    [InlineData("hello", "Hello")]
    [InlineData("hello world", "Hello.World")]
    [InlineData("company.project", "Company.Project")]
    [InlineData("  my service  ", "My.Service")]
    public void ToCapitalCaseTransformsValidInput(string input, string expected)
    {
        string result = input.ToCapitalCase();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToCapitalCaseReturnsNullWhenInputIsNull()
    {
        string? input = null;

        string? result = StringExtensions.ToCapitalCase(input!);

        Assert.Null(result);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void ToCapitalCaseReturnsOriginalWhenInputIsEmptyOrWhitespace(string input)
    {
        string result = input.ToCapitalCase();

        Assert.Equal(input, result);
    }
}

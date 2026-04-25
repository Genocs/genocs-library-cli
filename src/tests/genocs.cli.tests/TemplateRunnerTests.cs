using Genocs.CLI;

namespace genocs.cli.tests;

public sealed class TemplateRunnerTests
{
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("-myproject")]
    [InlineData("my project")]
    [InlineData("my*project")]
    public async Task BootstrapCleanArchitectureAsyncThrowsForInvalidNameAsync(string projectName)
    {
        Task action() => TemplateRunner.BootstrapCleanArchitectureAsync(projectName, CancellationToken.None);

        ArgumentException exception = await Assert.ThrowsAsync<ArgumentException>(action);

        Assert.Equal("projectName", exception.ParamName);
    }

    [Fact]
    public async Task BootstrapMicroserviceAsyncThrowsForInvalidCharactersAsync()
    {
        Task action() => TemplateRunner.BootstrapMicroserviceAsync("my/project", CancellationToken.None);

        await Assert.ThrowsAsync<ArgumentException>(action);
    }

    [Fact]
    public async Task BootstrapBlazorWasmAsyncThrowsForInvalidCharactersAsync()
    {
        Task action() => TemplateRunner.BootstrapBlazorWasmAsync("my?project", CancellationToken.None);

        await Assert.ThrowsAsync<ArgumentException>(action);
    }
}

using System.Diagnostics;
using Reqnroll;
using Xunit;

namespace genocs.cli.tests.Steps;

[Binding]
public sealed class CliVersionCommandSteps
{
    private int _exitCode;
    private string _standardOutput = string.Empty;
    private string _standardError = string.Empty;

    [Given("the genocs CLI project is available")]
    public void GivenTheGenocsCliProjectIsAvailable()
    {
        string projectPath = Path.Combine(ResolveRepositoryRoot(), "src", "genocs.cli.csproj");
        Assert.True(File.Exists(projectPath), $"CLI project was not found at '{projectPath}'.");
    }

    [When("I run the version command")]
    public async Task WhenIRunTheVersionCommandAsync()
    {
        var psi = new ProcessStartInfo
        {
            FileName = "dotnet",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true,
            WorkingDirectory = ResolveRepositoryRoot(),
        };

        psi.ArgumentList.Add("run");
        psi.ArgumentList.Add("--project");
        psi.ArgumentList.Add("src/genocs.cli.csproj");
        psi.ArgumentList.Add("--");
        psi.ArgumentList.Add("version");

        using var process = Process.Start(psi) ?? throw new InvalidOperationException("Failed to start the dotnet process.");
        Task<string> standardOutputTask = process.StandardOutput.ReadToEndAsync();
        Task<string> standardErrorTask = process.StandardError.ReadToEndAsync();

        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(90));
        await process.WaitForExitAsync(timeout.Token).ConfigureAwait(false);

        _exitCode = process.ExitCode;
        _standardOutput = (await standardOutputTask.ConfigureAwait(false)).Trim();
        _standardError = (await standardErrorTask.ConfigureAwait(false)).Trim();
    }

    [Then("the command should exit with code {int}")]
    public void ThenTheCommandShouldExitWithCode(int expectedExitCode)
    {
        Assert.Equal(expectedExitCode, _exitCode);
        Assert.True(string.IsNullOrWhiteSpace(_standardError), $"Unexpected stderr: {_standardError}");
    }

    [Then("the command output should contain a semantic version")]
    public void ThenTheCommandOutputShouldContainASemanticVersion()
    {
        Assert.Matches(@"\d+\.\d+\.\d+", _standardOutput);
    }

    private static string ResolveRepositoryRoot()
    {
        string? current = AppContext.BaseDirectory;

        while (!string.IsNullOrEmpty(current))
        {
            if (File.Exists(Path.Combine(current, "genocs.cli.slnx")))
            {
                return current;
            }

            current = Directory.GetParent(current)?.FullName;
        }

        throw new DirectoryNotFoundException("Could not resolve repository root from test execution directory.");
    }
}

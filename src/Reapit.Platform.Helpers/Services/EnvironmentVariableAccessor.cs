namespace Reapit.Platform.Helpers.Services;

/// <summary>
/// Class defining methods to interact with environment variables 
/// </summary>
public class EnvironmentVariableAccessor : IEnvironmentVariableAccessor
{
    /// <inheritdoc />
    public string? GetEnvironmentVariable(string variableName)
        => Environment.GetEnvironmentVariable(variableName);

    /// <inheritdoc />
    public void SetEnvironmentVariable(string variableName, string? value)
        => Environment.SetEnvironmentVariable(variableName, value);
}
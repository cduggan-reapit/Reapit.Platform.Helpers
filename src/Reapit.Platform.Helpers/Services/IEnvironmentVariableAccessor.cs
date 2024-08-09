namespace Reapit.Platform.Helpers.Services;

/// <summary>
/// Interface describing methods to interact with environment variables 
/// </summary>
public interface IEnvironmentVariableAccessor
{
    /// <summary>Gets an environment variable.</summary>
    /// <param name="variableName">The name of the variable to retrieve.</param>
    /// <returns>The value associated with the variable; null if not found.</returns>
    string? GetEnvironmentVariable(string variableName);

    /// <summary>Sets an environment variable.</summary>
    /// <param name="variableName">The name of the variable to set.</param>
    /// <param name="value">The value to assign to the variable.</param>
    void SetEnvironmentVariable(string variableName, string? value);
}
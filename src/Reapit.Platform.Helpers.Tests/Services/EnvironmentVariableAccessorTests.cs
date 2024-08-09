using Reapit.Platform.Helpers.Services;

namespace Reapit.Platform.Helpers.Tests.Services;

public class EnvironmentVariableAccessorTests
{
    /*
     * GetEnvironmentVariable
     */
    
    [Fact]
    public void GetEnvironmentVariable_ReturnsNull_WhenNotSet()
    {
        const string variableName = "example-variable-1";
        Environment.SetEnvironmentVariable(variableName, null);

        var sut = CreateSut();
        var actual = sut.GetEnvironmentVariable(variableName);
        actual.Should().BeNull();
    }
    
    [Fact]
    public void GetEnvironmentVariable_ReturnsValue_WhenSet()
    {
        const string variableName = "example-variable-2";
        const string variableValue = "lorem ipsum";
        Environment.SetEnvironmentVariable(variableName, variableValue);

        var sut = CreateSut();
        var actual = sut.GetEnvironmentVariable(variableName);
        actual.Should().Be(variableValue);
        
        Environment.SetEnvironmentVariable(variableName, null);
    }
    
    /*
     * SetEnvironmentVariable
     */
    
    [Fact]
    public void SetEnvironmentVariable_SetsEnvironmentVariable_WhenNoValuePreviouslyAssigned()
    {
        const string variableName = "example-variable-1";
        const string value = "value";

        var sut = CreateSut();
        sut.SetEnvironmentVariable(variableName, value);
        sut.GetEnvironmentVariable(variableName).Should().Be(value);
        
        Environment.SetEnvironmentVariable(variableName, null);
    }
    
    [Fact]
    public void SetEnvironmentVariable_ClearsEnvironmentVariable_WhenValueIsNull()
    {
        const string variableName = "example-variable-1";
        const string value = "value";
        
        Environment.SetEnvironmentVariable(variableName, value);

        var sut = CreateSut();
        sut.SetEnvironmentVariable(variableName, null);
        sut.GetEnvironmentVariable(variableName).Should().BeNull();
    }
    
    [Fact]
    public void SetEnvironmentVariable_UpdatesEnvironmentVariable_WhenValuePreviouslyDefined()
    {
        const string variableName = "example-variable-1";
        const string value = "value";
        
        Environment.SetEnvironmentVariable(variableName, "previousValue");

        var sut = CreateSut();
        sut.SetEnvironmentVariable(variableName, value);
        sut.GetEnvironmentVariable(variableName).Should().Be(value);
        
        Environment.SetEnvironmentVariable(variableName, null);
    }

    /*
     * Private methods
     */
    
    private static EnvironmentVariableAccessor CreateSut() 
        => new();
}
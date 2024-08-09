using Reapit.Platform.Helpers.Exceptions;
using Reapit.Platform.Helpers.Extensions;

namespace Reapit.Platform.Helpers.Tests.Extensions;

public class AnonymousObjectExtensionsTests
{
    /*
     * GetPropertyValue
     */

    [Fact]
    public void GetPropertyValue_ReturnsNull_WhenObjectNull()
    {
        var obj = (object?)null;
        var value = obj.GetPropertyValue("TestProperty");
        value.Should().BeNull();
    }
    
    [Fact]
    public void GetPropertyValue_ThrowsException_WhenPropertyNotOnObject()
    {
        var obj = new { TestProperty = "testProperty" };
        var action = () => obj.GetPropertyValue("OtherProperty");
        action.Should().Throw<ObjectPropertyNotFoundException>();
    }
    
    [Fact]
    public void GetPropertyValue_ReturnsValue_WhenPropertySet()
    {
        var obj = new { TestProperty = "testProperty" };
        var value = obj.GetPropertyValue("TestProperty");

        value.Should().NotBeNull();
        value!.ToString().Should().BeEquivalentTo("testProperty");
    }
}
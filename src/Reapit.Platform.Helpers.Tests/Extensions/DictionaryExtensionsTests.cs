using Reapit.Platform.Helpers.Enums;
using Reapit.Platform.Helpers.Extensions;

namespace Reapit.Platform.Helpers.Tests.Extensions;

public class DictionaryExtensionsTests
{
    /*
     * Combine
     */

    [Theory]
    [InlineData(DictionaryConflictBehaviour.IgnoreNew)]
    [InlineData(DictionaryConflictBehaviour.UpdateExisting)]
    [InlineData(DictionaryConflictBehaviour.ThrowException)]
    public void Combine_AddsElementToDictionary_WhenKeysDoNotConflict(DictionaryConflictBehaviour behaviour)
    {
        var dictionary = new Dictionary<int, string>
        {
            { 1, "one" },
            { 2, "two" },
            { 3, "three" }
        };

        var newValues = new Dictionary<int, string>
        {
            { 4, "four" },
            { 5, "five" }
        };
        
        dictionary.Combine(newValues, behaviour);
        dictionary.Should().HaveCount(5);
    }
    
    [Fact]
    public void Combine_DoesNotAlterExistingValues_WhenKeysMatch_AndBehaviourIgnoreNew()
    {
        var dictionary = new Dictionary<int, string>
        {
            { 1, "one" },
            { 2, "two" },
            { 3, "three" }
        };

        var newValues = new Dictionary<int, string>
        {
            { 3, "drei" },
            { 4, "vier" }
        };

        var expected = new Dictionary<int, string>
        {
            { 1, "one" },
            { 2, "two" },
            { 3, "three" },
            { 4, "vier" }
        };
        
        dictionary.Combine(newValues, DictionaryConflictBehaviour.IgnoreNew);
        dictionary.Should().BeEquivalentTo(expected);
    }
    
    [Fact]
    public void Combine_UpdatesExistingValues_WhenKeysMatch_AndBehaviourUpdateExisting()
    {
        var dictionary = new Dictionary<int, string>
        {
            { 1, "one" },
            { 2, "two" },
            { 3, "three" }
        };

        var newValues = new Dictionary<int, string>
        {
            { 3, "drei" },
            { 4, "vier" }
        };

        var expected = new Dictionary<int, string>
        {
            { 1, "one" },
            { 2, "two" },
            { 3, "drei" },
            { 4, "vier" }
        };
        
        dictionary.Combine(newValues, DictionaryConflictBehaviour.UpdateExisting);
        dictionary.Should().BeEquivalentTo(expected);
    }
    
    [Fact]
    public void Combine_ThrowsArgumentException_WhenKeysMatch_AndBehaviourThrowException()
    {
        var dictionary = new Dictionary<int, string>
        {
            { 1, "one" },
            { 2, "two" },
            { 3, "three" }
        };

        var newValues = new Dictionary<int, string>
        {
            { 3, "drei" },
            { 4, "vier" }
        };

        var expected = new Dictionary<int, string>
        {
            { 1, "one" },
            { 2, "two" },
            { 3, "drei" },
            { 4, "vier" }
        };
        
        var action = () => dictionary.Combine(newValues);
        action.Should().Throw<ArgumentException>();
    }
}
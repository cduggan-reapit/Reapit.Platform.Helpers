using Reapit.Platform.Helpers.Extensions;

namespace Reapit.Platform.Helpers.Tests.Extensions;

public class CollectionExtensionsTests
{
    /*
     * IsNullOrEmpty
     */

    [Fact]
    public void IsNullOrEmpty_ReturnsTrue_WhenCollectionNull()
    {
        var sut = (string[]?)null;
        sut.IsNullOrEmpty().Should().BeTrue();
    }
    
    [Fact]
    public void IsNullOrEmpty_ReturnsTrue_WhenCollectionEmpty()
    {
        var sut = Array.Empty<int>();
        sut.IsNullOrEmpty().Should().BeTrue();
    }
    
    [Fact]
    public void IsNullOrEmpty_ReturnsFalse_WhenCollectionPopulated()
    {
        var sut = new[] { 1.234d };
        sut.IsNullOrEmpty().Should().BeFalse();
    }
    
    /*
     * ContainsAny
     */

    [Fact]
    public void ContainsAny_ReturnsFalse_WhenCollectionNull()
    {
        var sut = (string[]?)null;
        var actual = sut.ContainsAny("item1", "item2", "item3");
        actual.Should().BeFalse();
    }


    [Fact]
    public void ContainsAny_ReturnsFalse_WhenComparisonSetEmpty()
    {
        var sut = new[] { 1, 2, 3 };
        var actual = sut.ContainsAny(Array.Empty<int>());
        actual.Should().BeFalse();
    }

    [Fact]
    public void ContainsAny_ReturnsFalse_WhenNoItemsMatch()
    {
        var sut = new[] { 1d, 2d, 3d };
        var actual = sut.ContainsAny(4d, 5d, 6d);
        actual.Should().BeFalse();
    }

    [Fact]
    public void ContainsAny_ReturnsTrue_WhenOneItemMatches()
    {
        var sut = new[] { 1d, 2d, 3d };
        var actual = sut.ContainsAny(3d, 4d, 5d);
        actual.Should().BeTrue();
    }

    [Fact]
    public void ContainsAny_ReturnsFalse_WhenMultipleItemsMatch()
    {
        var sut = new[] { 1d, 2d, 3d };
        var actual = sut.ContainsAny(2d, 3d, 4d);
        actual.Should().BeTrue();
    }
}
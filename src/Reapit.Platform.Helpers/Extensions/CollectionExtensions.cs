namespace Reapit.Platform.Helpers.Extensions;

/// <summary>
/// Class defining extension methods for collection types.
/// </summary>
/// <seealso cref="IEnumerable{T}"/>
public static class CollectionExtensions
{
    /// <summary>Determines whether a sequence is null or empty.</summary>
    /// <param name="collection">The collection to evaluate.</param>
    /// <typeparam name="T">The type of object in the collection.</typeparam>
    /// <returns>True if collection is null or contains no items, otherwise false.</returns>
    public static bool IsNullOrEmpty<T>(this IEnumerable<T>? collection)
        => !collection?.Any() ?? true;
    
    /// <summary>Determines whether a collection contains any element in another collection.</summary>
    /// <param name="collection">The collection to evaluate.</param>
    /// <param name="comparisonSet">The collection of values to seek.</param>
    /// <typeparam name="T">The type of object in the collection.</typeparam>
    /// <returns>True if collection contains any of the values in comparison; otherwise false.</returns>
    public static bool ContainsAny<T>(this IEnumerable<T>? collection, params T[]? comparisonSet)
        => collection?.Intersect(comparisonSet ?? Array.Empty<T>()).Any() ?? false;
}
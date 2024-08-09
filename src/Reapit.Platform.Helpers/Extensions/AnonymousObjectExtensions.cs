using Reapit.Platform.Helpers.Exceptions;

namespace Reapit.Platform.Helpers.Extensions;

/// <summary>
/// Class defining extension methods for anonymous objects.
/// </summary>
/// <seealso cref="object"/>
public static class AnonymousObjectExtensions
{
    /// <summary>Gets the value for a given property name from an anonymous object.</summary>
    /// <param name="obj">The object.</param>
    /// <param name="propertyName">The name of the property to retrieve.</param>
    /// <exception cref="ObjectPropertyNotFoundException">Property not found in the object type definition with the requested name.</exception>
    /// <returns>An object representing the value of the property in the given object.</returns>
    public static object? GetPropertyValue(this object? obj, string propertyName)
    {
        if (obj == null)
            return null;
        
        var objectType = obj.GetType();
        var property = objectType.GetProperty(propertyName)
            ?? throw new ObjectPropertyNotFoundException(objectType.Name, propertyName);

        return property.GetValue(obj, null);
    }
}
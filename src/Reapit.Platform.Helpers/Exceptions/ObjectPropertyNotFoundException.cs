namespace Reapit.Platform.Helpers.Exceptions;

/// <summary>
/// Exception thrown when attempting to access a property which does not exist within an object.
/// </summary>
public class ObjectPropertyNotFoundException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectPropertyNotFoundException"/> class.
    /// </summary>
    /// <param name="objectType">The type of object.</param>
    /// <param name="propertyName">The name of the property which was not found.</param>
    public ObjectPropertyNotFoundException(string objectType, string propertyName)
        : base($"Property {propertyName} not found for object of type {objectType}.")
    {
    }
}
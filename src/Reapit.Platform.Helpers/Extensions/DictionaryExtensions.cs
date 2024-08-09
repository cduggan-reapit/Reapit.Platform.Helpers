using Reapit.Platform.Helpers.Enums;
using static Reapit.Platform.Helpers.Enums.DictionaryConflictBehaviour;

namespace Reapit.Platform.Helpers.Extensions;

/// <summary>
/// Class defining extension methods for dictionary types.
/// </summary>
/// <seealso cref="IDictionary{TKey,TValue}"/>
public static class DictionaryExtensions
{
    /// <summary>
    /// Merge the values of a dictionary into an existing dictionary.
    /// </summary>
    /// <param name="dictionary">The dictionary to extend.</param>
    /// <param name="newValues">The collection of values to add to the dictionary object.</param>
    /// <param name="behaviour">How conflicting keys should be handled.</param>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    /// <exception cref="ArgumentException">Key conflict between dictionary and newValues with behaviour of <see cref="ThrowException"/></exception>
    public static void Combine<TKey, TValue>(
        this Dictionary<TKey, TValue> dictionary,
        Dictionary<TKey, TValue> newValues,
        DictionaryConflictBehaviour behaviour = ThrowException)
        where TKey: notnull
    {
        // Behaviour changes what we use to add to the dictionary.
        // IgnoreNew                    => TryAdd (InsertionBehavior.None)
        // UpdateExisting               => direct assignment (InsertionBehavior.OverwriteExisting)
        // ThrowException (default)     => Add (InsertionBehavior.ThrowOnExisting)
        Action<KeyValuePair<TKey, TValue>> action = behaviour switch
        {
            IgnoreNew => pair => dictionary.TryAdd(pair.Key, pair.Value),
            UpdateExisting => pair => dictionary[pair.Key] = pair.Value,
            _ => pair => dictionary.Add(pair.Key, pair.Value)
        };
        
        // Add each key-value pair in newValues
        foreach (var pair in newValues)
            action(pair);
    }
}
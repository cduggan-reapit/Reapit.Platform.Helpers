namespace Reapit.Platform.Helpers.Enums;

/// <summary>
/// Contains the values of behaviours available when adding entries to a dictionary
/// </summary>
public enum DictionaryConflictBehaviour : byte
{
    /// <summary>Ignore new entries with the same key as existing dictionary values.</summary>
    IgnoreNew = 0x03,
    /// <summary>Overwrite existing entries when a new value is provided with the same key.</summary>
    UpdateExisting = 0x02,
    /// <summary>Throw <see cref="Exception"/> when a new entry has the same key as an existing dictionary value.</summary>
    ThrowException = 0x01
}
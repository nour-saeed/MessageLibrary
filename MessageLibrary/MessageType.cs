using System;

namespace MessageLibrary
{
    /// <summary>
    /// Enum represent the type of a message.
    /// </summary>
    [Flags]
    public enum MessageType
    {
        NULL = 0,           // 00000
        Error = 1,          // 00001
        Warning = 2,        // 00010
        Information = 4,    // 00100
        Success = 8,        // 01000
        Failure = 16        // 10000
    }
}

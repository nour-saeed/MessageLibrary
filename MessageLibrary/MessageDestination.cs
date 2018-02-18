using System;

namespace MessageLibrary
{
    /// <summary>
    /// Enum represent the Destination of the Message.
    /// </summary>
    [Flags]
    public enum MessageDestination
    {
        None = 0,           // 0000
        Log = 1,            // 0001
        EventLog = 2,       // 0010
        Email = 4,          // 0100
        MessageBox = 8      // 1000
    }
}

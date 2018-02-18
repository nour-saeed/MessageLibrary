using System;

namespace MessageLibrary
{
    /// <summary>
    /// Message class, conatin data about a message.
    /// </summary>
    public static class Message
    {
        #region Global
        
        /// <summary>
        /// MessageType Type: contain the type of the message.
        /// </summary>
        public MessageType Type = MessageType.None;

        /// <summary>
        /// String Message(Msg): conatin the message as string.
        /// </summary>
        public string Msg = String.Empty;

        

        #endregion

        #region Properties
        #endregion

        #region Constructor

        /// <summary>
        /// The default contructor initiate a new instance. Set empty Msg and Type.Null if no parameters passed to it.
        /// <paramref name="msg">Optional parameter to set a new message.</param>
        /// <paramref name="type">Optional parameter to set a new type.</paramref>
        /// </summary>
        public Message(string msg = "", MessageType type = MessageType.NULL)
        {
            Type = type;
            Msg = msg;
        }
        #endregion

        #region Method
        #endregion
    }
}

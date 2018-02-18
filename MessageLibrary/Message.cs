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
        public static MessageType Type = MessageType.None;

        /// <summary>
        /// String Message(Msg): conatin the message as string.
        /// </summary>
        public static string Msg = String.Empty;

        public static MessageConfigurations Configuration;
        

        #endregion

        #region Properties
        #endregion

        #region Constructor

        /// <summary>
        /// The default contructor initiate a new instance. Set empty Msg and Type.Null if no parameters passed to it.
        /// <paramref name="msg">Optional parameter to set a new message.</param>
        /// <paramref name="type">Optional parameter to set a new type.</paramref>
        /// </summary>
        //public Message(string msg = "", MessageType type = MessageType.None)
        //{
        //    Type = type;
        //    Msg = msg;
        //}
        #endregion

        #region Method
        public static void WriteAll(
            string message,
            MessageType type,
            MessageDestination destination = MessageDestination.None,
            string format = "")
        {
            MessageDestination ActiveDestination = destination;
            string ActiveFormat = format;

            // if the destination not passed take the destination from the configuration variable.
            if (ActiveDestination == MessageDestination.None)
                ActiveDestination = Configuration.Destination;

            // if the format not passed take the format from the configuration variable.
            if (ActiveFormat == "")
                ActiveFormat = Configuration.Format;

            // Write to Log.
            if(ActiveDestination.HasFlag(MessageDestination.Log))
            {
                if (Configuration.Log.Type.HasFlag(type))
                    Log.Write(Message: message, type: type);
            }

            if(ActiveDestination.HasFlag(MessageDestination.EventLog))
            {
                //if (Configuration.EventLog.Type.HasFlag(type))
                //    EventLog.Write(Message: message);
            }
        }
        #endregion
    }
}

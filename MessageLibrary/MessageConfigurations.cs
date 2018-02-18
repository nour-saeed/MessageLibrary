using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageLibrary
{
    #region Message Configurations Class
    /// <summary>
    /// This class contain the configurations of Message.
    /// </summary>
    public class MessageConfigurations
    {
        #region Variables Members
        private MessageType _Type = (MessageType)11111; // Set the default value: ALL types of messages.
        private MessageDestination _Destination = MessageDestination.None;
        private string _Format = "";
        public LogConfigurations Log = null;
        public EventLogConfigurations EventLog = null;
        #endregion

        #region Properties
        /// <summary>
        /// Types of the messages that will be written to all destinations.
        /// </summary>
        public MessageType Type
        {
            get => _Type;
            set
            {
                _Type = value;

                if (Log != null)
                    Log.Type = _Type;

                if (EventLog != null)
                    ;

            }
        }

        /// <summary>
        /// The destinations for the message.
        /// </summary>
        public MessageDestination Destination
        {
            get => _Destination;
            set
            {
                _Destination = value;

                // if Destination contain Log option init new instance from type LogConfigurations.
                if ((_Destination & MessageDestination.Log) == MessageDestination.Log)
                {
                    this.Log = new LogConfigurations(type: _Type, formate: _Format);
                }

                if((_Destination & MessageDestination.EventLog) == MessageDestination.EventLog)
                {
                    this.EventLog = new EventLogConfigurations();
                }
            }
        }

        /// <summary>
        /// The format of informations in all destinations.
        /// </summary>
        public string Format
        {
            get => _Format;
            set
            {
                _Format = value;

                if (Log != null)
                    Log.Format = _Format;

                if (EventLog != null)
                    ;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Define a new instance of Message's configurations type.
        /// </summary>
        /// <param name="type">The types of the messages that send to the log file. Default value: All Types</param>
        /// <param name="destination">The destinations for the message. Default value: None. Examples: Log, EventLog, Email.</param>
        /// <param name="log">contain the configurations of a Log Message</param>
        /// <param name="formate">The format of informations in the log file. Default value: " DateTime.Now ---> "</param>
        public MessageConfigurations(
            MessageType type = (MessageType)11111, // Set the default value: ALL types of messages.
            MessageDestination destination = MessageDestination.None,
            LogConfigurations log = null,
            string formate = ""
            )
        {
            this._Type = type;
            this._Destination = destination;
            this.Log = log;
            this._Format = formate == "" ? $" {DateTime.Now} ---> " : formate;
        } 
        #endregion
    } 
    #endregion

    #region Log Configurations Class
    /// <summary>
    /// This class contain the configurations of a Log Message.
    /// </summary>
    public class LogConfigurations
    {
        #region Variables Members
        /// <summary>
        /// Types of the messages that will be written to Log.
        /// </summary>
        public MessageType Type = (MessageType)11111; // Set the default value: ALL types of messages.

        /// <summary>
        /// The destination is Log file.
        /// </summary>
        public readonly MessageDestination Destination = MessageDestination.Log;

        /// <summary>
        /// The path of the log file.
        /// </summary>
        public string FilePath = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// The name of the log file.
        /// </summary>
        public string FileName = "Log.txt";

        /// <summary>
        /// The format of informations in the log file.
        /// </summary>
        public string Format;
        #endregion

        #region Constructor
        /// <summary>
        /// Define a new instance of log's configurations type.
        /// </summary>
        /// <param name="type">The types of the messages that send to the log file. Default value: All Types</param>
        /// <param name="filePath">The path of the log file. Default value: Application Directory</param>
        /// <param name="fileName">The name of the log file. Default value: Log.txt</param>
        /// <param name="formate">The format of informations in the log file. Default value: " DateTime.Now ---> "</param>
        public LogConfigurations(
            MessageType type = (MessageType)11111, // Set the default value: ALL types of messages.
            string filePath = "",
            string fileName = "Log.txt",
            string formate = ""
            )
        {
            this.Type = type;
            this.FilePath = filePath == "" ? AppDomain.CurrentDomain.BaseDirectory : filePath;
            this.FileName = fileName;
            this.Format = formate == "" ? $" {DateTime.Now} ---> " : formate;
        } 
        #endregion

        public string GetPrevious(MessageType type)
        {
            string retString = "";
            string types = type == MessageType.None ? "" : $"-- [Message Type: {type.ToString()}] ";
            retString = Format + types;

            return retString;
        }
    }
    #endregion


    #region EventLog Configurations class
    public class EventLogConfigurations
    {

    } 
    #endregion
}

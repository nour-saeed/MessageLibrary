using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageLibrary
{
    public class MessageConfigurations
    {
        public MessageType _Type = MessageType.None;
        public MessageDestination _Destination = MessageDestination.None;
        public MessageConfigurations Log = new MessageConfigurations();

        public MessageType Type
        {
            get => _Type;
            set
            {
                _Type = value;

                if (Log != null)
                    Log.Type = _Type;
            }
        }

        public MessageConfigurations()
        {
            Type = MessageType.None;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Contracts
{
    public class ChatBotMessage
    {
        public int ID { get; set; }
        public MessageType MsgType { get; set; }
        public string ChatMessage { get; set; }
    }
}

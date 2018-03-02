using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatBot.Models
{
    public class BotReply
    {
        public string usertyped { get; set; }
        public string usertime { get; set; }
        public string message { get; set; }
        public string timestamp { get; set; }
    }
}
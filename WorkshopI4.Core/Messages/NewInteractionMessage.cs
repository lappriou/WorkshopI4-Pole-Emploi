using System;
using System.Collections.Generic;
using System.Text;
using WorkshopI4.Core.Models;

namespace WorkshopI4.Core.Messages
{
    [Serializable]
    public class NewInteractionMessage : IMessage
    {
        public string IDPage { get; set; }
        public string IDComponent { get; set; }
        public string IDTerminal { get; set; }
        public ETypeAction TypeAction { get; set; }
        public ETypeUIElement TypeComponentUI { get; set; }
        public DateTime Date { get; set; }
    }
}

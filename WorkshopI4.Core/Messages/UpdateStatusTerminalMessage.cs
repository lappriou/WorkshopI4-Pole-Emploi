using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkshopI4.Core.Models;

namespace WorkshopI4.Core.Messages
{
    [Serializable]
    public class UpdateStatusTerminalMessage
    {
        public string IdTerminal { get; set; }

        public ETerminalStatut Statut { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WorkshopI4.Core.Models;

namespace WorkshopI4.Core.Data
{
    public class TerminalData : DataBase
    {
        public ETerminalStatut Statut { get; set; }
        public IEnumerable<InteractionData> Interactions { get; set; }
    }
}

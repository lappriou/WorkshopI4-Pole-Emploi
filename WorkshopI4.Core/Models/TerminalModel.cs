using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkshopI4.Core.Predicats;

namespace WorkshopI4.Core.Models
{
    public class TerminalModel : ModelBase
    {
        public ETerminalStatut Statut { get; set; }
        public List<InteractionModel> Interactions { get; set; }

        public void UpdateStatut()
        {
            if(TerminalPredicat.PCritical(this))
            {
                Statut = ETerminalStatut.Bloqué;
            }

            else if (TerminalPredicat.PUncertain(this))
            {
                Statut = ETerminalStatut.Incertain;
            }

            else if (TerminalPredicat.PSafe(this))
            {
                Statut = ETerminalStatut.Fluide;
            }
        }
    }
}

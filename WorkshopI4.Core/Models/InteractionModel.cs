using System;
using System.Collections.Generic;
using System.Text;

namespace WorkshopI4.Core.Models
{
    public class InteractionModel : ModelBase
    {
        public ComponentUIModel Component { get; set; }
        public ETypeAction TypeAction { get; set; }
        public TerminalModel Terminal { get; set; }
        public DateTime Date { get; set; }
        public IndividualModel Individual { get; set; }
        public int IntervalTimeSecond { get; set; }
    }
}

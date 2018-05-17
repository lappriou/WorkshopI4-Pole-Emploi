using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WorkshopI4.Core.Models;

namespace WorkshopI4.Core.Data
{
    public class InteractionData : DataBase
    {
        public ComponentUIData Component { get; set; }
        public ETypeAction TypeAction { get; set; }
        public TerminalData Terminal { get; set; }
        public int Time { get; set; }
        public IndividualData Individual { get; set; }
        public DateTime Date { get; set; }
    }
}

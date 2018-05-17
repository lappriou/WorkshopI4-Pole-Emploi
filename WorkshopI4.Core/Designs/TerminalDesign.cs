using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkshopI4.Core.Models;
using WorkshopI4.Core.Services;

namespace WorkshopI4.Core.Designs
{
    public class TerminalDesign
    {
        private List<TerminalModel> terminals;

        public TerminalDesign()
        {
            terminals = InitTerminals();
        }
        public TerminalModel GetTerminal(string id)
        {
            return terminals.Where(t => t.ID == id).FirstOrDefault();
        }

        public List<TerminalModel> GetTerminals()
        {
            return terminals;
        }

        private List<TerminalModel> InitTerminals()
        {
            var terms = new List<TerminalModel>()
            {
                new TerminalModel()
            };

            return terms;
        }
    }
}

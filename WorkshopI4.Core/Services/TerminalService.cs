using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkshopI4.Core.Models;

namespace WorkshopI4.Core.Services
{
    public static class TerminalService
    {
        private static List<TerminalModel> terminals = new List<TerminalModel>();

        public static List<TerminalModel> Get()
        {
            return terminals;
        }

        public static TerminalModel Get(string id)
        {
            return terminals.Where(p=> p.ID == id).FirstOrDefault();
        }

        public static void Insert(TerminalModel terminal)
        {
            terminals.Add(terminal);
        }
    }
}

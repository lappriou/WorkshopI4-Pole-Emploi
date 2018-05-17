using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkshopI4.Core.Models;

namespace WorkshopI4.Core.Predicats
{
    public class TerminalPredicat
    {
        public static Predicate<TerminalModel> PCritical = Critical;
        public static Predicate<TerminalModel> PSafe = Safe;
        public static Predicate<TerminalModel> PUncertain = Uncertain;



        private static bool Safe(TerminalModel terminal)
        {
            return InteractionPredicat.PSafe(terminal.Interactions.Last());
        }

        private static bool Uncertain(TerminalModel terminal)
        {
            return InteractionPredicat.PUncertain(terminal.Interactions.Last());
        }

        private static bool Critical(TerminalModel terminal)
        {
            return InteractionPredicat.PCritical(terminal.Interactions.Last());
        }
    }
}

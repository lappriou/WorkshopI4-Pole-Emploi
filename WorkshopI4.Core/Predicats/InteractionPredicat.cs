using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkshopI4.Core.Models;

namespace WorkshopI4.Core.Predicats
{
    public static class InteractionPredicat
    {
        private static int safeTime = 0;
        private static int uncertainTime = 20;
        private static int criticalTime = 40;
        private static Predicate<int> PCriticalTime = CriticalTime;
        private static Predicate<int> PSafeTime = UncertainTime;
        private static Predicate<int> PUncertainTime = SafeTime;

        public static Predicate<InteractionModel> PCritical = Critical;
        public static Predicate<InteractionModel> PSafe = Safe;
        public static Predicate<InteractionModel> PUncertain = Uncertain;



        private static bool Safe(InteractionModel interaction)
        {
            return PSafeTime(interaction.IntervalTimeSecond) ;
        }

        private static bool Uncertain(InteractionModel interaction)
        {
            return PUncertainTime(interaction.IntervalTimeSecond);
        }

        private static bool Critical(InteractionModel interaction)
        {
            return PCriticalTime(interaction.IntervalTimeSecond);
        }

        private static bool CriticalTime(int timeSecond)
        {
            return criticalTime <= timeSecond;
        }

        private static bool UncertainTime(int timeSecond)
        {
            return (uncertainTime <= timeSecond  && timeSecond < criticalTime) ;
        }

        private static bool SafeTime(int timeSecond)
        {
            return (safeTime <= timeSecond && timeSecond < uncertainTime);
        }
    }
}

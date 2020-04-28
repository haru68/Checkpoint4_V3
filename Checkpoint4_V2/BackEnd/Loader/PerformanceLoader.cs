using System.Collections.Generic;
using System.Linq;

namespace Checkpoint4_V2.BackEnd
{
    public static class PerformanceLoader
    {
        public static List<Performance> Load()
        {
            List<Performance> performances;
            using (var context = new CircusContext())
            {
                performances = (from p in context.Performances
                                select p).ToList();
            }
            return performances;
        }
    }
}

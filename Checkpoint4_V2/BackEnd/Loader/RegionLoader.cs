using System.Collections.Generic;
using System.Linq;

namespace Checkpoint4_V2
{
    public static class RegionLoader
    {
        public static List<Region> Load()
        {
            List<Region> regions;
            using (var context = new CircusContext())
            {
                regions = (from r in context.Regions
                           select r).ToList();
            }
            return regions;
        }
    }
}

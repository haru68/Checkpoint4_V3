using System.Collections.Generic;
using System.Linq;

namespace Checkpoint4_V2
{
    public static class StarLoader
    {
        public static List<Star> Load(Performance performance)
        {
            List<Star> stars;
            using (var context = new CircusContext())
            {
                stars = (from s in context.Stars
                         where s.Performance == performance
                         select s).ToList();
                stars.ForEach(s => s.Performance = performance);
            }
            return stars;
        }

        public static List<Star> Load()
        {
            List<Star> stars;
            using (var context = new CircusContext())
            {
                var tempStars = (from s in context.Stars
                                select s).ToList();
                var performances = (from p in context.Performances
                                    select p).ToList();
                stars = (from s in tempStars
                         join p in performances on s.Performance equals p
                         select s).ToList();
            }
            return stars;
        }
    }
}

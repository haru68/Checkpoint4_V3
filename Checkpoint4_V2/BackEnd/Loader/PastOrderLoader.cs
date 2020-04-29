using System.Collections.Generic;
using System.Linq;

namespace Checkpoint4_V2
{
    public static class PastOrderLoader
    {
        public static List<PastOrder> Load(User user)
        {
            List<PastOrder> pastOrders;
            using (var context = new CircusContext())
            {
                var tempPastOrders = (from p in context.PastOrders
                                      where p.User == user
                                      select p).ToList();
                var tours = (from t in context.Tours
                             select t).ToList();

                var performances = (from p in context.Performances
                                    select p).ToList();

                var addresses = (from a in context.Addresses
                                 select a).ToList();

                var cities = (from c in context.Cities
                              select c).ToList();

                pastOrders = (from po in tempPastOrders
                              join t in tours on po.Tour equals t
                              join p in performances on t.Performance equals p
                              join a in addresses on t.Place equals a
                              join c in cities on a.City equals c
                              select po).ToList();
            }
            return pastOrders;
        }
    }
}

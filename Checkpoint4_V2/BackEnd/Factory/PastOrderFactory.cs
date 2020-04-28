using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Checkpoint4_V2
{
    public static class PastOrderFactory
    {
        public static PastOrder Create(ProcessingOrder processingOrder, User user)
        {
            PastOrder pastOrder = new PastOrder();
            pastOrder.User = user;
            pastOrder.Date = DateTime.Now;
            pastOrder.Amount = processingOrder.TotalAmount;
            pastOrder.Tour = processingOrder.Tour;
            pastOrder.AdultNumber = processingOrder.AdultNumber;
            pastOrder.ChildrenNumber = processingOrder.ChildrenNumber;

            return pastOrder;
        }

        public static List<PastOrder> CreateSeveral(List<ProcessingOrder> processingOrders, User user)
        {
            List<PastOrder> pastOrders = new List<PastOrder>();
            foreach(ProcessingOrder p in processingOrders)
            {
                PastOrder pastOrder = PastOrderFactory.Create(p, user);
                pastOrders.Add(pastOrder);
            }
            return pastOrders;
        }
    }
}

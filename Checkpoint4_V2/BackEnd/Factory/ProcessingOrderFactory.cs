using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Checkpoint4_V2
{
    public static class ProcessingOrderFactory
    {
        public static void AddInSingleton(ProcessingOrder processingOrder)
        {
            if (UserSingleton.GetInstance.IsAuthenticated == false)
            {
                UserSingleton.VisitorProcessingOrders.Add(processingOrder);
            }
            else
            {
                UserSingleton.GetInstance.ProcessingOrders.Add(processingOrder);
            }
        }

        public static ProcessingOrder Create(int adults, int children, Tour tour)
        {
            ProcessingOrder processingOrder = new ProcessingOrder();
            processingOrder.AdultNumber = adults;
            processingOrder.ChildrenNumber = children;
            processingOrder.Tour = tour;
            Price price = Price.GetPrice();
            double amount = adults * price.AdultPrice + children * price.ChildPrice;
            processingOrder.TotalAmount = amount;
            return processingOrder;
        }
    }
}

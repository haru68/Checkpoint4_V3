using System;
using System.Collections.Generic;

namespace Checkpoint4_V2
{
    public class ProcessingOrder
    {
        public Tour Tour { get; set; }
        public int AdultNumber { get; set; }
        public int ChildrenNumber { get; set; }
        public double TotalAmount { get; set; }

        public static void PaymentConfirmed()
        {
            List<ProcessingOrder> processingOrders;
            if (UserSingleton.GetInstance.IsAuthenticated)
            {
                processingOrders = UserSingleton.GetInstance.ProcessingOrders;
                List<PastOrder> pastOrders = PastOrderFactory.CreateSeveral(processingOrders, UserSingleton.GetInstance.User);
                pastOrders.ForEach(p => p.Record());
                UserSingleton.GetInstance.PastOrders.AddRange(pastOrders);
                UserSingleton.GetInstance.ProcessingOrders.Clear();
            }
            UserSingleton.VisitorProcessingOrders.Clear();
        }

        public void AddAdult()
        {
            if (UserSingleton.GetInstance.IsAuthenticated == true)
            {
                UserSingleton.GetInstance.ProcessingOrders.Remove(this);
                this.AdultNumber += 1;
                UserSingleton.GetInstance.ProcessingOrders.Add(this);
                this.Tour.BookSeats(1);
            }
            else if (!UserSingleton.GetInstance.IsAuthenticated)
            {
                UserSingleton.VisitorProcessingOrders.Remove(this);
                this.AdultNumber += 1;
                UserSingleton.VisitorProcessingOrders.Add(this);
                this.Tour.BookSeats(1);
            }
        }

        public bool CanAddPerson()
        {
            if(this.Tour.AvailableSeats >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void RemoveAdult()
        {
            if (UserSingleton.GetInstance.IsAuthenticated)
            {
                UserSingleton.GetInstance.ProcessingOrders.Remove(this);
                this.AdultNumber -= 1;
                UserSingleton.GetInstance.ProcessingOrders.Add(this);
                this.Tour.DeBookSeats(1);
            }
            else if (!UserSingleton.GetInstance.IsAuthenticated)
            {
                UserSingleton.VisitorProcessingOrders.Remove(this);
                this.AdultNumber -= 1;
                UserSingleton.VisitorProcessingOrders.Add(this);
                this.Tour.DeBookSeats(1);
            }
        }

        public bool CanRemoveAdult()
        {
            if(this.AdultNumber >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddChild()
        {
            if (UserSingleton.GetInstance.IsAuthenticated)
            {
                UserSingleton.GetInstance.ProcessingOrders.Remove(this);
                this.ChildrenNumber += 1;
                UserSingleton.GetInstance.ProcessingOrders.Add(this);
                this.Tour.BookSeats(1);
            }
            else if (!UserSingleton.GetInstance.IsAuthenticated)
            {
                UserSingleton.VisitorProcessingOrders.Remove(this);
                this.ChildrenNumber += 1;
                UserSingleton.VisitorProcessingOrders.Add(this);
                this.Tour.BookSeats(1);
            }
        }

        public bool CanRemoveChild()
        {
            if (this.ChildrenNumber >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveChild()
        {
            if (UserSingleton.GetInstance.IsAuthenticated)
            {
                UserSingleton.GetInstance.ProcessingOrders.Remove(this);
                this.ChildrenNumber -= 1;
                UserSingleton.GetInstance.ProcessingOrders.Add(this);
                this.Tour.DeBookSeats(1);
            }
            else if (!UserSingleton.GetInstance.IsAuthenticated)
            {
                UserSingleton.VisitorProcessingOrders.Remove(this);
                this.ChildrenNumber -= 1;
                UserSingleton.VisitorProcessingOrders.Add(this);
                this.Tour.DeBookSeats(1);
            }
        }

        public bool IsOrderRegistered()
        {
            bool isOrderRegisterd;
            if (UserSingleton.GetInstance.IsAuthenticated)
            {
                isOrderRegisterd = UserSingleton.GetInstance.ProcessingOrders.Contains(this);
            }
            else
            {
                isOrderRegisterd = UserSingleton.VisitorProcessingOrders.Contains(this);
            }
            return isOrderRegisterd;
        }
    }
}

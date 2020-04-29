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
                pastOrders.ForEach(p => p.RecordInDb());
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
                AdultNumber += 1;
                UserSingleton.GetInstance.ProcessingOrders.Add(this);
                Tour.BookSeats(1);
            }
            else if (!UserSingleton.GetInstance.IsAuthenticated)
            {
                UserSingleton.VisitorProcessingOrders.Remove(this);
                AdultNumber += 1;
                UserSingleton.VisitorProcessingOrders.Add(this);
                Tour.BookSeats(1);
            }
        }

        public bool CanAddPerson()
        {
            return this.Tour.IsEnoughAvailableSeats(1);
        }


        public void RemoveAdult()
        {
            if (UserSingleton.GetInstance.IsAuthenticated)
            {
                UserSingleton.GetInstance.ProcessingOrders.Remove(this);
                AdultNumber -= 1;
                UserSingleton.GetInstance.ProcessingOrders.Add(this);
                Tour.DeBookSeats(1);
            }
            else if (!UserSingleton.GetInstance.IsAuthenticated)
            {
                UserSingleton.VisitorProcessingOrders.Remove(this);
                AdultNumber -= 1;
                UserSingleton.VisitorProcessingOrders.Add(this);
                Tour.DeBookSeats(1);
            }
        }

        public bool CanRemoveAdult()
        {
            if(AdultNumber >= 1)
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
                ChildrenNumber += 1;
                UserSingleton.GetInstance.ProcessingOrders.Add(this);
                Tour.BookSeats(1);
            }
            else if (!UserSingleton.GetInstance.IsAuthenticated)
            {
                UserSingleton.VisitorProcessingOrders.Remove(this);
                ChildrenNumber += 1;
                UserSingleton.VisitorProcessingOrders.Add(this);
                Tour.BookSeats(1);
            }
        }

        public bool CanRemoveChild()
        {
            if (ChildrenNumber >= 1)
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
                ChildrenNumber -= 1;
                UserSingleton.GetInstance.ProcessingOrders.Add(this);
                Tour.DeBookSeats(1);
            }
            else if (!UserSingleton.GetInstance.IsAuthenticated)
            {
                UserSingleton.VisitorProcessingOrders.Remove(this);
                ChildrenNumber -= 1;
                UserSingleton.VisitorProcessingOrders.Add(this);
                Tour.DeBookSeats(1);
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

        public void AddInSingleton()
        {
            if (UserSingleton.GetInstance.IsAuthenticated == false)
            {
                UserSingleton.VisitorProcessingOrders.Add(this);
            }
            else
            {
                UserSingleton.GetInstance.ProcessingOrders.Add(this);
            }
        }

        public void Delete()
        {
            if (UserSingleton.GetInstance.IsAuthenticated)
            {
                UserSingleton.GetInstance.ProcessingOrders.Remove(this);
            }
            else
            {
                UserSingleton.VisitorProcessingOrders.Remove(this);
            }
            Tour.DeBookSeats(AdultNumber + ChildrenNumber);
        }
    }
}

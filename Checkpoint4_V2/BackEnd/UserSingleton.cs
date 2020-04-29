using System.Collections.Generic;
using System.Threading;

namespace Checkpoint4_V2
{
    public class UserSingleton
    {
        private static UserSingleton instance = null;
        public List<ProcessingOrder> ProcessingOrders { get; set; }
        public List<PastOrder> PastOrders { get; set; }
        public User User { get; private set; } = new User();
        public bool IsAuthenticated { get; private set; } = false;
        public static List<ProcessingOrder> VisitorProcessingOrders { get; set; } = new List<ProcessingOrder>();

        public static UserSingleton GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserSingleton();
                }
                return instance;
            }
        }

        public void RefreshPastOrders()
        {
            var threadStartDelegate = new ThreadStart(OnRefreshStart);
            Thread refreshThread = new Thread(threadStartDelegate);
            refreshThread.Start();
        }

        private void OnRefreshStart()
        {
            PastOrders = PastOrderLoader.Load(User);
            Thread.Sleep(5000);
            RefreshPastOrders();
        }

        public void Init(string login, string password)
        {
            IAuthentification authentification = new Authentification();
            User = authentification.LoginUsers(login, password);
            if (User != null)
            {
                IsAuthenticated = true;
                ProcessingOrders = VisitorProcessingOrders;
                PastOrders = PastOrderLoader.Load(User);
                UserSingleton.GetInstance.RefreshPastOrders();
            }
        }

        public static void Disconnect()
        {
            instance = null;
        }

        public static double GetTotalAmount()
        {
            double amount = 0;
            Price price = Price.GetPrice();
            if (UserSingleton.GetInstance.IsAuthenticated)
            {
                UserSingleton.GetInstance.ProcessingOrders.ForEach(x => amount += (x.AdultNumber * price.AdultPrice + x.ChildrenNumber*price.ChildPrice));
            }
            else
            {
                UserSingleton.VisitorProcessingOrders.ForEach(x => amount += (x.AdultNumber * price.AdultPrice + x.ChildrenNumber * price.ChildPrice));
            }
            return amount;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Checkpoint4_V2;
using System.Threading;

namespace Checkpoint4_WPF
{
    /// <summary>
    /// Logique d'interaction pour UserControlBasket.xaml
    /// </summary>
    public partial class UserControlBasket : UserControl
    {
        public UserControlBasket()
        {
            InitializeComponent();
            if(UserSingleton.GetInstance.IsAuthenticated == true)
            {
                ProcessingOrders_lv.ItemsSource = UserSingleton.GetInstance.ProcessingOrders;
                PastOrders_lv.ItemsSource = UserSingleton.GetInstance.PastOrders;
            }
            else
            {
                ProcessingOrders_lv.ItemsSource = UserSingleton.VisitorProcessingOrders;
            }
        }

        private void AddAdult_Btn(object sender, RoutedEventArgs e)
        {
            ProcessingOrder po = (ProcessingOrder)ProcessingOrders_lv.SelectedItem;
            if(po.CanAddPerson())
            {
                po.AddAdult();
            }
            else
            {
                DialogBox.Ok("Error", "Not enough seats available");
            }
            ProcessingOrders_lv.Items.Refresh();
        }

        private void RemoveAdult_Btn(object sender, RoutedEventArgs e)
        {
            ProcessingOrder po = (ProcessingOrder)ProcessingOrders_lv.SelectedItem;
            if(po.CanRemoveAdult())
            {
                po.RemoveAdult();
            }
            ProcessingOrders_lv.Items.Refresh();
        }

        private void AddChild_Btn(object sender, RoutedEventArgs e)
        {
            ProcessingOrder po = (ProcessingOrder)ProcessingOrders_lv.SelectedItem;
            if(po.CanAddPerson())
            {
                po.AddChild();
            }
            else
            {
                DialogBox.Ok("Error", "Not enough seats available");
            }
            ProcessingOrders_lv.Items.Refresh();
        }

        private void RemoveChild_Btn(object sender, RoutedEventArgs e)
        {
            ProcessingOrder po = (ProcessingOrder)ProcessingOrders_lv.SelectedItem;
            if(po.CanRemoveChild())
            {
                po.RemoveChild();
            }
            ProcessingOrders_lv.Items.Refresh();
        }

        private void CmbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CmbBox_Selection.SelectedItem == CurrentOrdersItem)
            {
                ProcessingOrder_Grid.Visibility = Visibility.Visible;
                PastOrders_Grid.Visibility = Visibility.Hidden;
            }
            else
            {
                ProcessingOrder_Grid.Visibility = Visibility.Hidden;
                PastOrders_Grid.Visibility = Visibility.Visible;
            }
        }

        private void DeleteOrder_Btn(object sender, RoutedEventArgs e)
        {
            ProcessingOrder poToDelete = (ProcessingOrder)ProcessingOrders_lv.SelectedItem;
            if(UserSingleton.GetInstance.IsAuthenticated)
            {
                UserSingleton.GetInstance.ProcessingOrders.Remove(poToDelete);
            }
            else
            {
                UserSingleton.VisitorProcessingOrders.Remove(poToDelete);

            }
            poToDelete.Tour.DeBookSeats(poToDelete.AdultNumber + poToDelete.ChildrenNumber);
            ProcessingOrders_lv.Items.Refresh();
        }

        private void PayOrder_Btn(object sender, RoutedEventArgs e)
        {
            UserControl usc = new UserControlPay();
            this.Content = usc;
        }
    }
}

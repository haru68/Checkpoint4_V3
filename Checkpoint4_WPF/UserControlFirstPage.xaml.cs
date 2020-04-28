using System.Windows.Controls;
using System.Windows.Input;

namespace Checkpoint4_WPF
{
    /// <summary>
    /// Logique d'interaction pour UserControlFirstPage.xaml
    /// </summary>
    public partial class UserControlFirstPage : UserControl
    {
        public UserControlFirstPage()
        {
            InitializeComponent();
        }

        private void PerformancesGrid_Click(object sender, MouseButtonEventArgs e)
        {
            UserControl usc = new UserControlPerformances();
            this.Content = usc;
        }

        private void PricesGrid_Click(object sender, MouseButtonEventArgs e)
        {
            UserControl usc = new UserControlPrices();
            this.Content = usc;
        }

        private void TourGrid_Click(object sender, MouseButtonEventArgs e)
        {
            UserControl usc = new UserControlTour();
            this.Content = usc;
        }

        private void SubscribersGrid_Click(object sender, MouseButtonEventArgs e)
        {
            UserControl usc = new UserControlSubscribers();
            this.Content = usc;
        }
    }
}

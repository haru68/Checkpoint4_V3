using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Checkpoint4_V2;
using Checkpoint4_V2.BackEnd;

namespace Checkpoint4_WPF
{
    /// <summary>
    /// Logique d'interaction pour UserControlPerformances.xaml
    /// </summary>
    public partial class UserControlPerformances : UserControl
    {
        public UserControlPerformances(Performance performance = null)
        {
            InitializeComponent();
            Performance_lv.ItemsSource = PerformanceLoader.Load();
        }

        private void ViewPerformance_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Performance selectedPerformance = (Performance)Performance_lv.SelectedItem;
            UserControl usc = new UserControlStars(selectedPerformance);
            this.Content = usc;
        }

        private void SeeTours_Btn(object sender, RoutedEventArgs e)
        {
            UserControl usc;
            if (Performance_lv.SelectedItem != null)
            {
                Performance selectedPerformance = (Performance)Performance_lv.SelectedItem;
                usc = new UserControlTour(selectedPerformance);
            }
            else
            {
                usc = new UserControlTour();
            }
            
            this.Content = usc;
        }

        private void SeeStars_Btn(object sender, RoutedEventArgs e)
        {
            UserControl usc;
            if (Performance_lv.SelectedItem != null)
            {
                Performance selectedPerformance = (Performance)Performance_lv.SelectedItem;
                usc = new UserControlStars(selectedPerformance);
            }
            else
            {
                usc = new UserControlStars();
            }

            this.Content = usc;
        }
    }
}

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Checkpoint4_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UserControlSetter.SetGridMain(GridMain, "FirstPage");
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ListViewMenu.Width = 200;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ListViewMenu.Width = 60;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string menuAction = ((ListViewItem)((ListView)sender).SelectedItem).Name;
            UserControlSetter.SetGridMain(GridMain, menuAction);
        }

        private void AboutUs_Click(object sender, MouseButtonEventArgs e)
        {
            string menuAction = "ItemAboutUs";
            UserControlSetter.SetGridMain(GridMain, menuAction);
        }

        private void Contact_Click(object sender, MouseButtonEventArgs e)
        {
            string menuAction = "ItemContact";
            UserControlSetter.SetGridMain(GridMain, menuAction);
        }

    }
}

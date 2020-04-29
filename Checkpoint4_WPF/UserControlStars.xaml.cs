using System.Windows;
using System.Windows.Controls;
using Checkpoint4_V2;

namespace Checkpoint4_WPF
{
    /// <summary>
    /// Logique d'interaction pour UserControlStars.xaml
    /// </summary>
    public partial class UserControlStars : UserControl
    {
        public UserControlStars(Performance performance = null)
        {
            InitializeComponent();
            if(performance != null)
            {
                Star_lv.ItemsSource = StarLoader.Load(performance);
            }
            else
            {
                Star_lv.ItemsSource = StarLoader.Load();
            }
        }

        private void ExportStars_Btn(object sender, RoutedEventArgs e)
        {
            NancyRequest nancyRequest = new NancyRequest();
            string response = nancyRequest.ExecuteRequest("Stars", "GET");
            FileWriter.Write("Stars", response);
            DialogBox.Ok("Success", "Stars exported well. \n Check Root folder in main folder.");
        }
    }
}

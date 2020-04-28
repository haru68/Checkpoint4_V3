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
    }
}

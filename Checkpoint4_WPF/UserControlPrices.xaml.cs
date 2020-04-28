using System.Windows.Controls;
using Checkpoint4_V2;

namespace Checkpoint4_WPF
{
    /// <summary>
    /// Logique d'interaction pour UserControlPrices.xaml
    /// </summary>
    public partial class UserControlPrices : UserControl
    {
        public UserControlPrices()
        {
            InitializeComponent();
            Price_Table.DataContext = Price.GetPrice();
        }
    }
}

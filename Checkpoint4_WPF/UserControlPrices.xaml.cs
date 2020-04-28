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

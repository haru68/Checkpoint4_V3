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

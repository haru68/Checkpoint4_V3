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
    /// Logique d'interaction pour UserControlPay.xaml
    /// </summary>
    public partial class UserControlPay : UserControl
    {
        public UserControlPay()
        {
            InitializeComponent();
            Amount_TextBlock.Text = Convert.ToString(UserSingleton.GetTotalAmount());
        }

        private void OnlyNumbersPreview(object sender, TextCompositionEventArgs e)
        {
            InputChecker.OnlyNumbersPreview(sender, e);
        }

        private void ConfirmPayment(object sender, RoutedEventArgs e)
        {
            if(!(String.IsNullOrEmpty(NumCreditCard_TextBox.Text) && String.IsNullOrEmpty(CCVCreditCard_TextBox.Text)))
            {
                ProcessingOrder.PaymentConfirmed();
                DialogBox.Ok("Success", "Great business with you, master chief");
            }
            else
            {
                DialogBox.Ok("Error", "Correctly fill the fields so i can buy a new bike.");
            }
        }
    }
}

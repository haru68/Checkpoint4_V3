using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
            List<String> fields = new List<String>();
            fields.Add(NumCreditCard_TextBox.Text);
            fields.Add(CCVCreditCard_TextBox.Text);

            if (InputChecker.AreAllFieldsComplete(fields))
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

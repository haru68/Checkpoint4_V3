using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logique d'interaction pour UserControlContact.xaml
    /// </summary>
    public partial class UserControlContact : UserControl
    {
        public UserControlContact()
        {
            InitializeComponent();
        }

        private void OnlyNumbersPreview(object sender, TextCompositionEventArgs e)
        {
            InputChecker.OnlyNumbersPreview(sender, e);
        }

        private void SendContact_Btn(object sender, RoutedEventArgs e)
        {
            if (AreAllFieldsComplete())
            {
                string mail = Mail_TxtBox.Text;
                string firstName = FirstName_TxtBox.Text;
                string name = Name_TxtBox.Text;
                string telephonNumber = Telephone_TxtBox.Text;
                string text = Text_TxtBox.Text;
                ContactForm contact = ContactFormFactory.Create(mail, firstName, name, telephonNumber, text);
                if (contact.SendForm())
                {
                    DialogBox.Ok("Well done", "Your contact form has been sent. We will reply you asap.");
                }
                else
                {
                    DialogBox.Ok("Error", "An error occured. Please try again.");
                }
            }
        }

        private bool AreAllFieldsComplete()
        {
            if (String.IsNullOrEmpty(Name_TxtBox.Text)
                || String.IsNullOrEmpty(FirstName_TxtBox.Text)
                || String.IsNullOrEmpty(Mail_TxtBox.Text)
                || String.IsNullOrEmpty(Telephone_TxtBox.Text)
                || String.IsNullOrEmpty(Text_TxtBox.Text))
            {
                DialogBox.Ok("Error", "Please, fill all the fields");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

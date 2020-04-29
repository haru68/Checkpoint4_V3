using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
                string familyName = Name_TxtBox.Text;
                string phoneNumber = Telephone_TxtBox.Text;
                string text = Text_TxtBox.Text;
                ContactForm contact = ContactFormFactory.Create(mail, firstName, familyName, phoneNumber, text);
                if (contact.SendForm())
                {
                    Reset();
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
            List<String> fields = new List<string>();
            fields.Add(Name_TxtBox.Text);
            fields.Add(FirstName_TxtBox.Text);
            fields.Add(Mail_TxtBox.Text);
            fields.Add(Telephone_TxtBox.Text);
            fields.Add(Text_TxtBox.Text);
            if (InputChecker.AreAllFieldsComplete(fields))
            {
                return true;
            }
            else
            {
                DialogBox.Ok("Error", "Please, fill all the fields");
                return false;
            }
        }

        private void Reset()
        {
            Mail_TxtBox.Text = String.Empty;
            FirstName_TxtBox.Text = String.Empty;
            Name_TxtBox.Text = String.Empty;
            Telephone_TxtBox.Text = String.Empty;
            Text_TxtBox.Text = String.Empty;
        }
    }
}

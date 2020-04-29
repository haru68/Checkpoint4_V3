using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Checkpoint4_V2;

namespace Checkpoint4_WPF
{
    /// <summary>
    /// Logique d'interaction pour UserControlSubscribers.xaml
    /// </summary>
    public partial class UserControlSubscribers : UserControl
    {
        public UserControlSubscribers()
        {
            InitializeComponent();
            Region_cmbBox.ItemsSource = RegionLoader.Load();
            if(UserSingleton.GetInstance.IsAuthenticated)
            {
                CanOnlyDisconnect();
            }
        }

        private void CanOnlyDisconnect()
        {
            Welcome_TxtBlock.Text = "Welcome " + UserSingleton.GetInstance.User.Login;
            WelcomUser_Grid.Visibility = Visibility.Visible;
            Login_Grid.Visibility = Visibility.Hidden;
            Inscription_Grid.Visibility = Visibility.Hidden;
            Login_Btn.Visibility = Visibility.Hidden;
            Inscription_Btn.Visibility = Visibility.Hidden;
        }

        private void DiplayInscription(object sender, RoutedEventArgs e)
        {
            Inscription_Grid.Visibility = Visibility.Visible;
            Login_Grid.Visibility = Visibility.Hidden;
        }

        private void DisplayLogin(object sender, RoutedEventArgs e)
        {
            Inscription_Grid.Visibility = Visibility.Hidden;
            Login_Grid.Visibility = Visibility.Visible;
        }

        private void txtPasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoginClick_Btn(sender, e);
            }
        }

        private void LoginClick_Btn(object sender, RoutedEventArgs e)
        {
            UserSingleton.GetInstance.Init(UserName_TxtBox.Text, Password_TxtBox.Password);
            if (UserSingleton.GetInstance.IsAuthenticated)
            {
                User user = UserSingleton.GetInstance.User;
                CanOnlyDisconnect();
            }
            else
            {
                DialogBox.Ok("Error", "Invalid login and/or password. Please, try again");
            }
            ResetLogin();
        }

        private void CancelClick_Btn(object sender, RoutedEventArgs e)
        {
            ResetLogin();
        }

        private void ResetLogin()
        {
            Password_TxtBox.Password = string.Empty;
            UserName_TxtBox.Text = string.Empty;
            UserName_TxtBox.Focus();
        }

        private void Subscribe_Btn(object sender, RoutedEventArgs e)
        {
            if(AreUserFieldsOk())
            {
                string login = Login_TxtBox.Text;
                string password = Password_Box.Password;
                DateTime birthday = (DateTime) Birthday_DatePicker.SelectedDate;
                short streetNumber = Convert.ToInt16(StreetNumber_TxtBox.Text);
                string streetName = StreetName_TxtBox.Text;
                string cityName = CityName_TxtBox.Text;
                string postalCode = PostalCode_TxtBox.Text;
                Region region = (Region) Region_cmbBox.SelectedItem;

                City city = CityFactory.Get(cityName, postalCode, region);
                Address address = AddressFactory.Get(streetNumber, streetName, city);
                string encryptedPassword = Password.Encrypt(password.ToString());

                if(!User.IsInDb(login, encryptedPassword))
                {
                    User user = UserFactory.Create(login, encryptedPassword, birthday, address);
                    DialogBox.Ok("Success", "User has been correctly recorded");
                    ResetInscription();
                }
                else
                {
                    DialogBox.Ok("Error", "Check fields");
                }
            }
            else
            {
                DialogBox.Ok("Error", "Check fields");
            }
        }

        private void Cancel_Btn(object sender, RoutedEventArgs e)
        {
            ResetInscription();
        }

        private void ResetInscription()
        {
            Login_TxtBox.Text = string.Empty;
            Password_Box.Password = string.Empty;
            Birthday_DatePicker.SelectedDate = null;
            StreetNumber_TxtBox.Text = string.Empty;
            StreetName_TxtBox.Text = string.Empty;
            CityName_TxtBox.Text = string.Empty;
            PostalCode_TxtBox.Text = string.Empty;
            Region_cmbBox.SelectedIndex = -1;
        }

        private void OnlyNumbers(object sender, TextCompositionEventArgs e)
        {
            InputChecker.OnlyNumbersPreview(sender, e);
        }

        private void OnlyLetters(object sender, TextCompositionEventArgs e)
        {
            InputChecker.OnlyLettersPreview(sender, e);
        }

        private bool AreUserFieldsOk()
        {
            bool isLoginComplete = InputChecker.IsLoginOK(Login_TxtBox.Text);
            bool isPasswordComplete = InputChecker.IsPasswordOk(Password_Box.Password);
            bool isBirthdayOk = InputChecker.IsBirthdayOk(Birthday_DatePicker.SelectedDate);
            bool isStreetNumOk = InputChecker.IsStringOk(StreetNumber_TxtBox.Text);
            bool isStreetNameOk = InputChecker.IsStringOk(StreetName_TxtBox.Text);
            bool isCityNameOk = InputChecker.IsStringOk(CityName_TxtBox.Text);
            bool isPostalCodeOk = InputChecker.IsPostalCodeOk(PostalCode_TxtBox.Text);

            if(isLoginComplete && isPasswordComplete && isBirthdayOk && isStreetNumOk
                && isStreetNameOk && isCityNameOk && isPostalCodeOk)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Disconnect_btn(object sender, RoutedEventArgs e)
        {
            UserSingleton.Disconnect();
            WelcomUser_Grid.Visibility = Visibility.Hidden;
            Login_Grid.Visibility = Visibility.Visible;
            Login_Btn.Visibility = Visibility.Visible;
            Inscription_Btn.Visibility = Visibility.Visible;
        }
    }
}

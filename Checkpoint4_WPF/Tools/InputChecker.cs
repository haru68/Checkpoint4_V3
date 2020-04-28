using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace Checkpoint4_WPF
{
    public static class InputChecker
    {
        public static void OnlyNumbersPreview(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public static void OnlyLettersPreview(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-z,']+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public static bool IsLoginOK(string login)
        {
            if (!(String.IsNullOrEmpty(login))
                && login.Length >= 5)
            {
                return true;
            }
            else
            {
                DialogBox.Ok("Error", "Invalid login.");
                return false;
            }
        }

        public static bool IsPasswordOk(string password)
        {
            if(!(String.IsNullOrEmpty(password))
                && password.Length >= 10)
            {
                return true;
            }
            else
            {
                DialogBox.Ok("Error", "Min 10 caracters for passwords");
                return false;
            }
        }

        public static bool IsBirthdayOk(DateTime? date)
        {
            int fifteenYears = 365 * 15;
            DateTime fifteenYearsAgo = DateTime.Today - TimeSpan.FromDays(fifteenYears);
            if((date <= fifteenYearsAgo)
                && date != null)
            {
                return true;
            }
            else
            {
                DialogBox.Ok("Error", "Invalid date");
                return false;
            }
        }

        public static bool IsStringOk(string text)
        {
            if(!(String.IsNullOrEmpty(text)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsPostalCodeOk(string text)
        {
            if(Int32.TryParse(text, out int useless)
                && text.Length == 5)
            {
                return true;
            }
            else
            {
                DialogBox.Ok("Error", "Invalid postal code");
                return false;
            }
        }

        public static bool AreAllFieldsComplete(List<String> fields)
        {
            bool complete = true;
            foreach(String field in fields)
            {
                if (String.IsNullOrEmpty(field))
                {
                    complete = false;
                }
            }
            return complete;
        }

        public static int GetNumber(string text)
        {
            int number = -1;
            Int32.TryParse(text, out number);
            return number;
        }
    }
}

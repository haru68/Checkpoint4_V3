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
using System.Windows.Shapes;

namespace Checkpoint4_WPF
{
    /// <summary>
    /// Logique d'interaction pour DialogBox.xaml
    /// </summary>
    public partial class DialogBox : Window
    {
        private bool Result { get; set; }
        public DialogBox(string title, string message)
        {
            InitializeComponent();
            this.Title = title;
            this.lbl_Text.Text = message;
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            Result = true;
            this.DialogResult = true;
        }

        public static bool Ok(string title, string message)
        {
            DialogBox dialogBox = new DialogBox(title, message);
            dialogBox.ShowDialog();
            return dialogBox.Result;
        }
    }
}

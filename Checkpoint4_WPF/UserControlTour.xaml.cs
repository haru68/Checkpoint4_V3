﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Checkpoint4_V2;

namespace Checkpoint4_WPF
{
    /// <summary>
    /// Logique d'interaction pour UserControlTour.xaml
    /// </summary>
    public partial class UserControlTour : UserControl
    {
        public List<Tour> Tours { get; set; }
        public List<Performance> Performances { get; set; }
        public UserControlTour(Performance performance = null)
        {
            InitializeComponent();
            if(performance != null)
            {
                Tours = TourLoader.Load(performance);
            }
            else
            {
                Tours = TourLoader.Load();
            }
            Tours_lv.ItemsSource = Tours;
        }

        private void AddProcessingOrder_btn(object sender, RoutedEventArgs e)
        {
            int adults = InputChecker.GetNumber(AdultNumber_TxtBox.Text);
            int children = InputChecker.GetNumber(ChildrenNumber_TxtBox.Text);
            if(Tours_lv.SelectedItems != null && (adults > 0 || children > 0))
            {
                Tour selectedTour = (Tour)Tours_lv.SelectedItem;
                if(selectedTour.IsEnoughAvailableSeats(adults + children))
                {
                    ProcessingOrder processingOrder = ProcessingOrderFactory.Create(adults, children, selectedTour);
                    if (processingOrder.IsOrderRegistered())
                    {
                        DialogBox.Ok("Error", "Such an order already exists.");
                    }
                    else
                    {
                        processingOrder.AddInSingleton();
                        selectedTour.BookSeats(adults + children);
                        DialogBox.Ok("Success", "Order has been recorded");
                    }
                }
                else
                {
                    DialogBox.Ok("Error", "Snif, not enough place. Check for another");
                }
            }
            else
            {
                DialogBox.Ok("Error", "Please, check fields");
            }
        }

        private void Number_Preview(object sender, TextCompositionEventArgs e)
        {
            InputChecker.OnlyNumbersPreview(sender, e);
        }

        private void ViewPerformance_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListViewItem item = sender as ListViewItem;
            object obj = item.Content;
            Performance performance = ((Tour)obj).Performance;

            UserControl usc = new UserControlPerformances(performance);
            this.Content = usc;
        }
    }
}

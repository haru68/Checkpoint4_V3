using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Checkpoint4_WPF
{
    class UserControlSetter
    {
        public static void SetGridMain(Grid grid, String name)
        {
            UserControl destination = GetUserControlByName(name);
            if (grid.Name == "GridMain")
            {
                grid.Children.Clear();
                grid.Children.Add(destination);
            }
        }

        private static UserControl GetUserControlByName(string name)
        {
            UserControl resControl;
            switch (name)
            {
                case "ItemFirstPage":
                    resControl = new UserControlFirstPage();
                    break;
                case "ItemPerformances":
                    resControl = new UserControlPerformances();
                    break;
                case "ItemPrices":
                    resControl = new UserControlPrices();
                    break;
                case "ItemTour":
                    resControl = new UserControlTour();
                    break;
                case "ItemBasket":
                    resControl = new UserControlBasket();
                    break;
                case "ItemSubscribers":
                    resControl = new UserControlSubscribers();
                    break;
                case "ItemAboutUs":
                    resControl = new UserControlAboutUs();
                    break;
                case "ItemContact":
                    resControl = new UserControlContact();
                    break;
                case "ItemStars":
                    resControl = new UserControlStars();
                    break;
                default:
                    resControl = new UserControlFirstPage();
                    break;
            }
            return resControl;
        }
    }
}

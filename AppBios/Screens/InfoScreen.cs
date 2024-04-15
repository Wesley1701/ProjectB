using AppBios.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppBios.Screens
{
    internal class InfoScreen : Screen
    {
        public InfoScreen(Account user)
        {
            this.ScreenName = "Information";
            this.User = user;
        }
        public InfoScreen()
        {
            this.ScreenName = "Information";
        }
        public void ShowScreen()
        {
            Console.Clear();
            First();
            Console.WriteLine("\n\nThis cinema consist of a bar, a lounge area and 3 auditoriums with seats for 150-, 300- and 500 respectively ");
            Console.WriteLine("Location: Wijnhaven 107, 3011 WN, Rotterdam");
            Console.WriteLine("Phone Number: (010) 333 00 29");
            Console.WriteLine("\nPress any key to go back to the homescreen");
            Console.ReadLine();

        }
    }
}

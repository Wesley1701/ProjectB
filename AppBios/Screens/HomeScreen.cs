using AppBios.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppBios.Screens
{
    internal class HomeScreen : Screen
    {
        public HomeScreen(Account user)
        {
            this.ScreenName = "Main Menu";
            this.User = user;
        }
        public HomeScreen()
        {
            this.ScreenName = "Main Menu";
        }

        public void ShowScreen()
        {
            var options = new Dictionary<string, System.Action> {
                {"1", moviesScreen},{"2", ordersScreen}, {"3", infoPage}, {"4", loginPage}, {"5", signUpPage}, {"6", quitApp}
            };
            Console.Clear();
            First();
            if (User != null)
            {
                Console.WriteLine($"Welcome {User.FirstName},");
            }
            Console.WriteLine("Please select an option\n\n");
            Console.WriteLine("[1] Show all movies");
            Console.WriteLine("[2] Show orders");
            Console.WriteLine("[3] Show information about cinema");
            if (User != null)
            {
                Console.WriteLine("[4] Log out");
            }
            else
            {
                Console.WriteLine("[4] Login");
                Console.WriteLine("[5] Sign up");
            }
            Console.WriteLine("[6] Exit");
            string option = Console.ReadLine();
            while (true)
            {
                if (IsOption(option, options))
                {
                    if (this.User != null && (option == "4" || option == "5"))
                    {
                        if (option == "4")
                        {
                            LogOut();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("That's not a valid option, please pick a valid option");
                            option = Console.ReadLine();
                        }
                    }
                    else
                    {
                        options[option]();
                        break;
                    }

                }
                else
                {
                    Console.WriteLine("That's not a valid option, please pick a valid option");
                    option = Console.ReadLine();
                }
            }
            this.ShowScreen();
        }
        public void LogOut()
        {
            this.User.WriteToFile();
            this.User = null;
        }
    }
}

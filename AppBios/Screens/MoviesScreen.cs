using AppBios.Controllers;
using AppBios.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppBios.Screens
{
    internal class MoviesScreen : Screen {
        public MoviesScreen(Account user)
            {
                this.ScreenName = "Movies";
                this.User = user;
            }
        public MoviesScreen()
        {
            this.ScreenName = "Movies";
        }

        public void ShowScreen()
        {
            Console.Clear();
            First();
            Console.WriteLine("Please select an movie to see more information\n\n");
            Movies movies = new Movies();
            string[] names = movies.GetAllMovieNames();
            string[] options = new string[names.Length + 1];
            for (int i = 1; i <= names.Length; i++)
            {
                Console.WriteLine($"[{i}] {names[i - 1]}");
                options[i - 1] = "" + i;
            }
            Console.WriteLine($"\n[0] Go back to main menu");
            options[names.Length] = "0";
            while (true)
            {
                string option = Console.ReadLine();
                if (IsOption(option, options))
                {
                    if (options[names.Length] == option)
                    {
                        this.homeScreen();
                        break;
                    }
                    else
                    {
                        this.movieScreen(movies.GetByName(names[int.Parse(option) - 1]));
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("That's not a valid option, please pick a valid option");
                }
            }
            this.ShowScreen();
        }
    }
}

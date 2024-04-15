using AppBios.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppBios.Screens
{
    internal class MovieScreen : Screen
    {
        Movie Movie;
        public MovieScreen(Account user, Movie movie)
        {
            this.User = user;
            this.ScreenName = movie.Name;
            this.Movie = movie;
        }

        public void ShowScreen()
        {
            var options = new string[] { "1", "0" };
            Console.Clear();
            First();
            Console.WriteLine($"Genre: {this.Movie.Genre}");
            Console.WriteLine($"Description: {this.Movie.Description}");
            Console.WriteLine($"Duration: {this.Movie.Duration} minutes");
            Console.WriteLine("\n[1] Date & times");
            Console.WriteLine("[0] Go back to all movies");
            while (true)
            {
                string option = Console.ReadLine();
                if (IsOption(option, options))
                {
                    if (option == "1")
                    {
                        while (true) 
                        {
                            Console.Clear();
                            First();
                            var options1 = this.Movie.ShowTimes();
                            Console.WriteLine("[0] Go back");
                            options1["0"] = -1; 
                            string option1 = Console.ReadLine();
                            if (IsOption(option1, options1))
                            {
                                if (option1 == "0")
                                {
                                    break;
                                } else
                                {
                                    chairSelectScreen(options1[option1]);
                                }
                            } else
                            {
                                Console.WriteLine("Pick a Valid option");
                            }
                        }
                        ShowScreen();
                        break;
                    }
                    else if (option == "0")
                    {
                        this.moviesScreen();
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("That's not a valid option, please pick a valid option"); ;
                }
            }
        }
    }
}

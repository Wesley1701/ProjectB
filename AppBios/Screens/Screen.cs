using AppBios.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppBios.Screens
{
    abstract class Screen
    {
        public string ScreenName;
        public Account User;
        public void First()
        {
            Console.WriteLine();
            Console.WriteLine("Heart of Cinema");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine($"|{ScreenName}|");
        }
        public bool IsOption(string option, Dictionary<String, System.Action> options)
        {
            if (options.ContainsKey(option))
            {
                return true;
            }
            return false;
        }
        public bool IsOption(string option, string[] options)
        {
            for (int i = 0; i < options.Length; i++)
            {
                if (option == options[i])
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsOption(string option, Dictionary<string, int> options)
        {
            if (options.ContainsKey(option))
            {
                return true;
            }
            return false;
        }
        public void homeScreen()
        {
            HomeScreen home = new HomeScreen(this.User);
            home.ShowScreen();
        }
        public void moviesScreen()
        {
            MoviesScreen movie = new MoviesScreen(this.User);
            movie.ShowScreen();
        }
        public void movieScreen(Movie option)
        {
            MovieScreen movie = new MovieScreen(this.User, option);
            movie.ShowScreen();
        }
        public void chairSelectScreen(int show)
        {
            ChairSelectScreen chairSelect = new ChairSelectScreen(this.User, show);
            chairSelect.ShowScreen();
        }
        public void ordersScreen()
        {
            OrdersScreen pref = new OrdersScreen(this.User);
            pref.ShowScreen();
        }
        public void infoPage()
        {
            InfoScreen info = new InfoScreen(this.User);
            info.ShowScreen();
        }
        public void loginPage()
        {
            LoginScreen login = new LoginScreen(this.User);
            login.ShowScreen();
        }
        public void signUpPage()
        {
            SignUpScreen signUp = new SignUpScreen(this.User);
            signUp.ShowScreen();
        }
        public void quitApp()
        {
            System.Environment.Exit(0);
        }
    }
}

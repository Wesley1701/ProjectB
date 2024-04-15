using AppBios.Controllers;
using AppBios.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppBios.Screens
{
    internal class LoginScreen : Screen
    {
        public LoginScreen(Account user)
        {
            this.ScreenName = "Login";
            this.User = user;
        }
        public LoginScreen()
        {
            this.ScreenName = "Login";
        }
        public void ShowScreen()
        {
            bool LoggingIn = true;
            string Email = "";
            string Password = "";
            string hiddenPassword = "";
            var options = new Dictionary<string, System.Action> {
                {"1", null}, {"2", null}, {"3", null}, {"0", homeScreen}
            };
            while (LoggingIn)
            {
                Console.Clear();
                First();
                Console.WriteLine("Fill in the following information to login");
                Console.WriteLine($"[1] Email: {Email}");
                Console.WriteLine($"[2] Password: {hiddenPassword}");
                Console.WriteLine($"\n\n[3] Login");
                Console.WriteLine($"[0] Main Menu");
                while (true)
                {
                    string option = Console.ReadLine();
                    if (IsOption(option, options))
                    {
                        if (options[option] != null)
                        {
                            LoggingIn = false;
                            options[option]();
                        }
                        else
                        {
                            if (option == "1")
                            {
                                Console.WriteLine("Type in your email");
                                Email = Console.ReadLine();
                                break;
                            }
                            else if (option == "2")
                            {
                                Console.WriteLine("Type in your password");
                                Password = Console.ReadLine();
                                hiddenPassword = "";
                                for (int i = 0; i < Password.Length; i++)
                                {
                                    hiddenPassword += "*";
                                }
                                break;
                            }
                            else
                            {
                                Accounts accounts = new Accounts();
                                Account temp = accounts.GetByEmail(Email);
                                if (temp != null)
                                {
                                    if (temp.Password == Password)
                                    {
                                        this.User = temp;
                                        homeScreen();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid email or password, please try again");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid email or password, please try again");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("That's not a valid option, please pick a valid option");
                    }
                }
            }
        }
    }
}


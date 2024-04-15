using AppBios.Controllers;
using AppBios.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppBios.Screens
{
    internal class SignUpScreen : Screen
    {
        public SignUpScreen(Account user)
        {
            this.ScreenName = "Sign Up";
            this.User = user;
        }
        public SignUpScreen()
        {
            this.ScreenName = "Sign Up";
        }
        public void ShowScreen()
        {
            Console.Clear();
            First();
            bool SigningUp = true;
            string FirstName = "";
            string LastName = "";
            string Email = "";
            string Password = "";
            string hiddenPassword = "";
            var options = new Dictionary<string, System.Action> {
                {"1", null}, {"2", null}, {"3", null}, {"4", null}, {"5", null}, {"0" , homeScreen}
            };
            while (SigningUp)
            {
                Console.Clear();
                this.First();
                Console.WriteLine("Please fill in the following information");
                Console.WriteLine($"[1] First Name: {FirstName}");
                Console.WriteLine($"[2] Last Name: {LastName}");
                Console.WriteLine($"[3] Email: {Email}");
                Console.WriteLine($"[4] Password: {hiddenPassword}");
                Console.WriteLine("\n\n[5] Sign Up");
                Console.WriteLine("[0] Main Menu");
                while (true)
                {
                    string option = Console.ReadLine();
                    if (IsOption(option, options))
                    {
                        if (options[option] != null)
                        {
                            SigningUp = false;
                            options[option]();
                        }
                        else
                        {
                            if (option == "1")
                            {
                                Console.WriteLine("Type in your first name");
                                FirstName = Console.ReadLine();
                                break;
                            }
                            else if (option == "2")
                            {
                                Console.WriteLine("Type in your last name");
                                LastName = Console.ReadLine();
                                break;
                            }
                            else if (option == "3")
                            {
                                Console.WriteLine("Type in your email");
                                string temp = Console.ReadLine();
                                if (ValidEmail(temp))
                                {
                                    Accounts accounts = new Accounts();
                                    if (accounts.AvailableEmail(temp))
                                    {
                                        Email = temp;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("This email is already in use, please login or try again");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("This is not a valid Email, please try again");
                                }
                            }
                            else if (option == "4")
                            {
                                Console.WriteLine("Type in your password");
                                Console.WriteLine("Use at least six characters, one lowercase letter, one uppercase letter and a number");
                                string temp = Console.ReadLine();
                                if (ValidPassword(temp))
                                {
                                    Password = temp;
                                    hiddenPassword = "";
                                    for (int i = 0; i < Password.Length; i++)
                                    {
                                        hiddenPassword += "*";
                                    }
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("This is not a valid password, please try again\nUse at least six characters, one lowercase letter, one uppercase letter and a number");
                                }

                            }
                            else
                            {
                                if (FirstName != "" && LastName != "" && Email != "" && Password != "")
                                {
                                    this.User = new Account(FirstName, LastName, Email, Password);
                                    this.User.WriteToFile();
                                    SigningUp = false;
                                    homeScreen();
                                }
                                else
                                {
                                    Console.WriteLine("Please fill in all information before signing up");
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
        public bool ValidEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }

        public bool ValidPassword(string password)
        {
            if (password.Length >= 6)
            {
                bool lower = false;
                bool upper = false;
                bool number = false;
                foreach (char ltr in password)
                {
                    if (Char.IsLower(ltr))
                    {
                        lower = true;
                    }
                    else if (Char.IsUpper(ltr))
                    {
                        upper = true;
                    }
                    else if (Char.IsNumber(ltr))
                    {
                        number = true;
                    }
                }
                return lower && upper && number;
            }
            return false;
        }
    }
}


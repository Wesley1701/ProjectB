using AppBios.Controllers;
using AppBios.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppBios.Screens
{
    internal class ChairSelectScreen : Screen
    {
        int ShowId;
        public ChairSelectScreen(Account user, int showId)
        {
            this.User = user;
            this.ScreenName = "Chair Selection";
            this.ShowId = showId;
        }

        public void ShowScreen()
        {
            Console.Clear();
            First();
            Shows shows = new Shows();
            Show show = shows.GetById(ShowId);
            Movies movies = new Movies();
            Console.WriteLine(movies.GetById(show.MovieId).Name);
            show.ShowSeats();
            int tickets;
            int row;
            int seat;
            int seatIndex;
            Dictionary<string, int> order = new Dictionary<string, int> { };
            order["showId"] = ShowId;
            while (true)
            {
                Console.WriteLine("Please pick the number of tickets: ");
                string answer = Console.ReadLine();
                bool IsNumber = true;
                foreach (char ltr in answer)
                {
                    if (!Char.IsNumber(ltr))
                    {
                        Console.WriteLine("Please pick a number");
                        IsNumber = false;
                        break;
                    }
                }
                if (IsNumber && answer != "")
                {
                    tickets = int.Parse(answer);
                    if (tickets > 8)
                    {
                        Console.WriteLine("To buy more than 8 tickets please contact us directly");
                        Console.ReadLine();
                        homeScreen();
                    } else if (tickets <= 0)
                    {
                        Console.WriteLine("Please pick atleast 1 or more tickets");
                        Console.ReadLine();
                        ShowScreen();
                        break;
                    }
                    order["tickets"] = tickets;
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine("Please pick a row");
                string answer = Console.ReadLine();
                bool IsNumber = true;
                foreach (char ltr in answer)
                {
                    if (!Char.IsNumber(ltr))
                    {
                        Console.WriteLine("Please pick a number");
                        IsNumber = false;
                        break;
                    }
                }
                if (IsNumber && answer != "")
                {
                    row = int.Parse(answer);
                    if (!(row > 0 && row <= show.Seating.Length))
                    {
                        Console.WriteLine("Please pick a valid row");
                    } else
                    {
                        order["row"] = row;
                        order["rowIndex"] = row - 1;
                        break;
                    }
                }
            }
            while (true)
            {
                Console.WriteLine("Please pick the left most seat");
                string answer = Console.ReadLine();
                bool IsNumber = true;
                foreach (char ltr in answer)
                {
                    if (!Char.IsNumber(ltr))
                    {
                        Console.WriteLine("Please pick a number");
                        IsNumber = false;
                        break;
                    }
                }
                if (IsNumber && answer != "")
                {
                    seat = int.Parse(answer);
                    seatIndex = seat - (((show.Seating[(show.Seating.Length / 2)].Length) - show.Seating[row - 1].Length) / 2) ;
                    if (!(seatIndex > 0 && seatIndex + tickets <= show.Seating[row - 1].Length))
                    {
                        Console.WriteLine("There aren't enough seats to the right, please pick another seat");
                    } else
                    {
                        order["leftSeat"] = seat;
                        order["leftSeatIndex"] = seatIndex;
                        break;
                    }
                }
            }
            Console.WriteLine("Press 1 to confirm your reservation");
            double cost = GetPrize(order, show);
            if (Console.ReadLine() == "1")
            {
                if (User == null)
                {
                    Console.WriteLine("Please put in a email for the reservation:");
                    string email = Console.ReadLine();
                    while(!ValidEmail(email))
                    {
                        Console.WriteLine("This is not a valid email, plese try again");
                        Console.WriteLine("Please put in a email for the reservation:");
                        email = Console.ReadLine();
                    }
                    Reservations reservations = new Reservations();
                    int id = reservations.NextId();
                    Reservation reservation = new Reservation(id, email, cost, order);
                    reservation.WriteToFile();
                }
                else 
                {
                    User.AddOrder(order);
                    User.Cost += cost;
                    User.WriteToFile();
                    Reservations reservations = new Reservations();
                    int id = reservations.NextId();
                    Reservation reservation = new Reservation(id, User.Email, cost, order);
                    reservation.WriteToFile();
                }
                for (int i = 0; i < tickets; i++)
                    {
                        show.Seating[row - 1][seatIndex - 1 + i].IsTaken = true;
                    }
                show.WriteToFile();
                Console.ReadLine();
            }
            
        }
        public static double GetPrize(Dictionary<string, int> order, Show show)
        {
            int tickets = order["tickets"];
            int row = order["rowIndex"];
            int leftSeat = order["leftSeatIndex"];
            double prize = 0;
            for (int i = 0; i < tickets; i++)
            {
                prize += show.Seating[row][leftSeat + i].Cost;
            }
            return prize;
        }
        public bool ValidEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
    }
}

using AppBios.Controllers;
using AppBios.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppBios.Screens
{
    internal class OrdersScreen : Screen
    {
        public OrdersScreen(Account user)
        {
            this.ScreenName = "Orders";
            this.User = user;
        }
        public OrdersScreen()
        {
            this.ScreenName = "Orders";
        }
        public void ShowScreen()
        {
            Console.Clear();
            First();
            if (User != null)
            {
                foreach (Dictionary<string, int> item in User.Orders)
                {
                    OrderInfo(item);
                }
                Console.WriteLine($"Total prize: {string.Format("{0:0.00}", User.Cost)} ");
            }
            else
            {
                Reservations reservations = new Reservations();
                Console.WriteLine("Please put in your email to see your orders: ");
                string email = Console.ReadLine();
                Console.WriteLine("=================================================");
                List<Reservation> orders = reservations.GetByEmail(email);
                if (orders.Count != 0)
                {
                    double cost = 0;
                    foreach (Reservation r in orders)
                    {
                        OrderInfo(r.Order);
                        cost += r.Cost;
                    }
                    Console.WriteLine($"Total prize: {string.Format("{0:0.00}", cost)} EUR");
                }
                else
                {
                    Console.WriteLine("There are no orders linked to this email");
                }
            }
            Console.ReadLine();
        }

        public void OrderInfo(Dictionary<string, int> item)
        {
            Shows shows = new Shows();
            Show show = shows.GetById(item["showId"]);
            Movies movies = new Movies();
            Movie movie = movies.GetById(show.MovieId);
            Console.WriteLine($"Movie name: {movie.Name}");
            Console.WriteLine($"Date + time: {show.ShowTime}");
            Console.WriteLine($"Auditorium: {show.AuditoriumId}");
            Console.WriteLine($"Row: {item["row"]}");
            string seats = $"{item["leftSeat"]}";
            for (int i = 1; i < item["tickets"]; i++)
            {
                seats += $", {(item["leftSeat"] + i)}";
            }
            Console.WriteLine($"Seats: {seats}");
            Console.WriteLine("=================================================");
        }
    }
}

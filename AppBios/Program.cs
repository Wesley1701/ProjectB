using AppBios.Controllers;
using AppBios.Models;
using AppBios.Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppBios
{
    class Program
    {
        static void Main(string[] args)
        {
            HomeScreen home = new HomeScreen();
            home.ShowScreen();
        }

        static Show CreateShow(int auditoriumId, int movieId, DateTime showTime, Shows shows)
        {
            int id = shows.NextId();

            Auditoriums _ = new Auditoriums();
            Auditorium auditorium = _.GetById(auditoriumId);
            int size = auditorium.Seats.Length;
            Seat[][] seats = new Seat[size][];
            for (int i = 0; i < size; i++)
            {
                seats[i] = new Seat[auditorium.Seats[i]];
                for (int j = 0; j< auditorium.Seats[i]; j++)
                {
                    seats[i][j] = new Seat(7.50);
                }
            }
            Show show = new Show(id, auditoriumId, movieId, showTime, seats);
            return show;
        }
    }
}
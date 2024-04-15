using AppBios.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AppBios.Models
{
    internal class Show
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("auditoriumId")]
        public int AuditoriumId { get; set; }
        [JsonPropertyName("movieId")]
        public int MovieId { get; set; } 
        [JsonPropertyName("showtime")]
        public DateTime ShowTime { get; set; }  
        [JsonPropertyName("seating")]
        public Seat[][] Seating { get; set; }

        public Show(int id, int auditoriumId, int movieId, DateTime showTime, Seat[][] seating)
        {
            Id = id;
            AuditoriumId = auditoriumId;
            MovieId = movieId;
            ShowTime = showTime;
            Seating = seating;
        }
        public Show() { }

        public void ShowSeats()
        {
            int max = Seating[(Seating.Length / 2)].Length;
            string s = "   ";
            for (int i = 1; i <= max; i++) { s += i > 9 ? $" {i}" : $" {i} "; }
            Console.WriteLine(s);
            for (int i = 1; i <= Seating.Length; i++)
            {
                s = i > 9 ? $"{i} " : $"{i}  ";
                for (int j = 1; j <= ((max - Seating[i-1].Length )/ 2); j++) { s += "   "; }
                for (int j = 0; j < Seating[i-1].Length; j++)
                {
                    if (Seating[i-1][j].IsTaken)
                    {
                        s += "[X]";
                    }
                    else
                    {
                        s += "[0]";
                    }
                    
                }
                Console.WriteLine(s);
            }
        }
        public void WriteToFile()
        {
            Shows shows = new Shows();
            shows.UpdateList(this);
        }
    }
}

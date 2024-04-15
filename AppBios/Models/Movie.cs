using AppBios.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AppBios.Models
{
    public class Movie
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("genre")]
        public string Genre { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        public Movie(string name, string genre, int duration, string description)
        {
            Movies movies = new Movies();
            this.Id = movies.NextId();
            this.Name = name;
            this.Genre = genre;
            this.Duration = duration;
            this.Description = description;
        }

        public Movie() { }
        public Dictionary<string, int> ShowTimes()
        {
            Shows shows = new Shows();
            var plays = shows.GetByMovie(this.Id);
            Dictionary<string, int> options = new Dictionary<string, int> { };
            int i = 0;
            DateTime current = DateTime.Now;
            DateTime nextWeek = current.AddDays(7);
            foreach (var play in plays)
            {
                if (play.ShowTime > current && play.ShowTime < nextWeek)
                {
                    Console.WriteLine($"[{++i}] {play.ShowTime.ToString("f")}, Auditorium: {play.AuditoriumId}");
                    options["" + i] = play.Id;
                }
            }
            return options;
        }
        public void WriteToFile()
        {
            Movies movies = new Movies();
            movies.UpdateList(this);
        }
    }
}

using AppBios.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AppBios.Models
{
    internal class Reservation
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("cost")]
        public double Cost { get; set; }
        [JsonPropertyName("order")]
        public Dictionary<string, int> Order { get; set; }

        public Reservation(int id, string email, double cost, Dictionary<string, int> order)
        {
            Id = id;
            Email = email;
            Cost = cost;
            Order = order;
        }
        public Reservation() { }
        public void WriteToFile()
        {
            Reservations reservations = new Reservations();
            reservations.UpdateList(this);
        }
    }
}

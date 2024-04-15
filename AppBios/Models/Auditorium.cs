using AppBios.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AppBios.Models
{
    internal class Auditorium
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("seats")]
        public int[] Seats { get; set; }

        public void WriteToFile()
        {
            Auditoriums accounts = new Auditoriums();
            accounts.UpdateList(this);
        }
    }
}

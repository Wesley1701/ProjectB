using AppBios.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AppBios.Models
{
    public class Account
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("firstname")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastname")]
        public string LastName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
        [JsonPropertyName("cost")]
        public double Cost { get; set; }
        [JsonPropertyName("orders")]
        public List<Dictionary<string, int>> Orders { get; set; }

        public Account(string firstname, string lastname, string email, string password)
        {
            Accounts accounts = new Accounts();
            this.Id = accounts.NextId();
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Email = email;
            this.Password = password;
            this.Cost = 0;
            this.Orders = new List<Dictionary<string, int>> { };
        }

        public Account(){}
        public void AddOrder(Dictionary<string, int> order)
        {
            if (Orders == null)
            {
                Orders = new List<Dictionary<string, int>> { order };
            } else
            {
                Orders.Add(order);
            }
            this.WriteToFile();
        }
        public void WriteToFile()
        {
            Accounts accounts = new Accounts();
            accounts.UpdateList(this);
        }
    }
}

using AppBios.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AppBios.Controllers
{
    internal class Reservations
    {
        private List<Reservation> _reservations;
        string path;

        public Reservations()
        {
            JsonToClass PathCreater = new JsonToClass();
            path = PathCreater.CreatePath("reservations.json");
            Load();
        }

        public void Load()
        {
            string json = File.ReadAllText(path);

            _reservations = JsonConvert.DeserializeObject<List<Reservation>>(json);
        }
        public Reservation GetById(int id)
        {
            return _reservations.Find(x => x.Id == id);
        }

        public List<Reservation> GetByEmail(string email)
        {
            var reservations = _reservations.FindAll(x => x.Email == email);
            return reservations;
        }

        public int NextId()
        {
            int LastId = -1;
            foreach (Reservation a in _reservations)
            {
                if (a.Id > LastId)
                {
                    LastId = a.Id;
                }
            }
            return LastId + 1;
        }

        public void UpdateList(Reservation reservation)
        {
            int index = _reservations.FindIndex(s => s.Id == reservation.Id);
            if (index == -1)
            {
                _reservations.Add(reservation);

            }
            else
            {
                _reservations[index] = reservation;
            }
            Write();
        }

        public void Write()
        {
            string json = JsonConvert.SerializeObject(_reservations);

            File.WriteAllText(path, json);
            Console.WriteLine("Write done");
        }
    }
}

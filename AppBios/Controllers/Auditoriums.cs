using AppBios.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace AppBios.Controllers
{
    internal class Auditoriums
    {
        private List<Auditorium> _auditoriums;
        string path = System.IO.Path.GetFullPath("/Users/wesle/OneDrive/Hogeschool/Project/AppBios/AppBios/Data/auditoriums.json");

        public Auditoriums()
        {
            JsonToClass PathCreater = new JsonToClass();
            path = PathCreater.CreatePath("auditoriums.json");
            Load();
        }

        public void Load()
        {
            string json = File.ReadAllText(path);

            _auditoriums = JsonSerializer.Deserialize<List<Auditorium>>(json);
        }
        public Auditorium GetById(int id)
        {
            return _auditoriums.Find(x => x.Id == id);
        }

        public void UpdateList(Auditorium auditorium)
        {
            int index = _auditoriums.FindIndex(s => s.Id == auditorium.Id);
            if (index == -1)
            {
                _auditoriums.Add(auditorium);

            }
            else
            {
                _auditoriums[index] = auditorium;
            }
            Write();
        }

        public void Write()
        {
            string json = JsonSerializer.Serialize(_auditoriums);

            File.WriteAllText(path, json);
            Console.WriteLine("Write done");
        }
    }
}

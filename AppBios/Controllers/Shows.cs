using AppBios.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace AppBios.Controllers
{
    internal class GFG2 : IComparer<Show>
    {
        public int Compare(Show x, Show y)
        {
            if (x == null || y == null)
            {
                return 0;
            }
            return x.ShowTime.CompareTo(y.ShowTime);
        }
    }
    internal class Shows
    {
        private List<Show> _shows;
        string path;

        public Shows()
        {
            JsonToClass PathCreater = new JsonToClass();
            path = PathCreater.CreatePath("shows.json");
            Load();
        }

        public void Load()
        {
            string json = File.ReadAllText(path);

            _shows = JsonConvert.DeserializeObject<List<Show>>(json);
        }
        public Show GetById(int id)
        {
            return _shows.Find(x => x.Id == id);
        }

        public List<Show> GetByMovie(int id)
        {
            var shows = _shows.FindAll(x => x.MovieId == id);
            GFG2 gg = new GFG2();
            shows.Sort(gg);
            return shows;
        }
        public int NextId()
        {
            int LastId = -1;
            foreach (Show a in _shows)
            {
                if (a.Id > LastId)
                {
                    LastId = a.Id;
                }
            }
            return LastId + 1;
        }

        public void UpdateList(Show show)
        {
            int index = _shows.FindIndex(s => s.Id == show.Id);
            if (index == -1)
            {
                _shows.Add(show);

            }
            else
            {
                _shows[index] = show;
            }
            Write();
        }

        public void Write()
        {
            string json = JsonConvert.SerializeObject(_shows);

            File.WriteAllText(path, json);
            Console.WriteLine("Write done");
        }
    }
}
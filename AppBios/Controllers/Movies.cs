using AppBios.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace AppBios.Controllers
{
    class GFG : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            if (x == null || y == null)
            {
                return 0;
            }

            return x.Name.CompareTo(y.Name);

        }
    }
    public class Movies
    {
        private List<Movie> _movies;
        string path;
        public Movies()
        {
            JsonToClass PathCreater = new JsonToClass();
            path = PathCreater.CreatePath("movies.json");
            Load();
        }

        public void Load()
        {
            string json = File.ReadAllText(path);

            _movies = JsonSerializer.Deserialize<List<Movie>>(json);
        }

        public Movie GetById(int id)
        {
            return _movies.Find(x => x.Id == id);
        }

        public Movie GetByName(string name)
        {
            return _movies.Find(x => x.Name == name);
        }

        public string[] GetAllMovieNames()
        {
            GFG gg = new GFG();
            _movies.Sort(gg);
            int count = 0;
            foreach (Movie _ in _movies){ count++; }
            string[] movieNames = new string[count];
            int i = 0;
            foreach (Movie movie in _movies)
            {
                movieNames[i++] = movie.Name;
            }
            return movieNames;
        }

        public int NextId()
        {
            int LastId = -1;
            foreach (Movie a in _movies)
            {
                if (a.Id > LastId)
                {
                    LastId = a.Id;
                }
            }
            return LastId + 1;
        }
        public void UpdateList(Movie movie)
        {
            int index = _movies.FindIndex(s => s.Id == movie.Id);
            if (index == -1)
            {
                _movies.Add(movie);
            }
            else
            {
                _movies[index] = movie;
            }
            Write();
        }

        public void Write()
        {
            string json = JsonSerializer.Serialize(_movies);

            File.WriteAllText(path, json);
            Console.WriteLine("Write done");
        }
    }
}

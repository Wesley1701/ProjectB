using AppBios.Models;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Reflection;

namespace AppBios.Controllers
{
    public class Accounts
    {
        private List<Account> _accounts;
        string path;

        public Accounts()
        {
            JsonToClass PathCreater = new JsonToClass();
            path = PathCreater.CreatePath("accounts.json");
            Load();
        }

        public void Load()
        {
            string json = File.ReadAllText(path);

            _accounts = JsonConvert.DeserializeObject<List<Account>>(json);
        }

        public Account GetById(int id)
        {
            return _accounts.Find(x => x.Id == id);
        }

        public Account GetByEmail(string email)
        {
            return _accounts.Find(x => x.Email == email);
        }

        public bool AvailableEmail(string email)
        {
            int index = _accounts.FindIndex(s => s.Email == email);
            if (index == -1)
            {
                return true;
            }
            return false;
        }

        public int NextId()
        {
            int LastId = -1;
            foreach(Account a in _accounts)
            {
                if (a.Id > LastId)
                {
                    LastId = a.Id;
                }
            }
            return LastId + 1;
        }
        public void UpdateList(Account account)
        {
            int index = _accounts.FindIndex(s => s.Id == account.Id);
            if (index == -1)
            {
                _accounts.Add(account);

            } 
            else
            {
                _accounts[index] = account;
            }
            Write();
        }
        public void Write()
        {
            string json = JsonConvert.SerializeObject(_accounts);

            File.WriteAllText(path, json);
            Console.WriteLine("Write done");
        }
    }
}

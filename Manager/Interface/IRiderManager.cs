using System.Collections.Generic;
using DreamsFashionApp.Models.Entities;

namespace DreamsFashionApp.Manager.Interface
{
    public interface IRiderManager
    {
        public Rider Register(string name, string phoneNumber, string password, string email,string address);
         public Rider Get(int id);
         public Rider Get(string email);
         public List<Rider> GetAll();
         public Rider Update(string email, string name, string phoneNumber, string password, string address);
         public void Delete(int id);
        
    }
}
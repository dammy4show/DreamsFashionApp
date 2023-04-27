using System.Collections.Generic;
using DreamsFashionApp.Models.Entities;

namespace DreamsFashionApp.Manager.Interface
{
    public interface IOrderManager
    {
        public Order Create(string email, Dictionary<string, int> cart);
         public Order Get(int id);
         public Order Get(string email);
         public Order Update(User user, Dictionary<string, int>cart);
         
         public List<Order> GetAll();
          
          public void Delete(User user); 
    }
}
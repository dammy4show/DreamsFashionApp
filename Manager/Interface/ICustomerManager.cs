using System.Collections.Generic;
using DreamsFashionApp.Models.Entities;

namespace DreamsFashionApp.Manager.Interface
{
    public interface ICustomerManager
    {
        public Customer Register(string email, string name, string password, string phoneNumber, string address, string role, bool isDeleted);
        
        public Customer Get(string email);
        public Customer Get(int userId);
        public List<Customer> GetAll();
        public Customer Update(string email,  string name, string phoneNumber,string password, string address);
        public void Delete(int id);
        
        
        
    }
}
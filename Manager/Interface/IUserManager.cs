using System.Collections.Generic;
using DreamsFashionApp.Models.Entities;

namespace DreamsFashionApp.Manager.Interface
{
    public interface IUserManager
    {
         
         public User Get(int id);
         public User Get(string email);
         public List<User> GetAll();
         public void Delete(string email);
         public User Login(string email, string password);
         public decimal UpdateWallet(User user);
         public User Update( string name, string address, string email, string password, string phoneNumber);
         public decimal FundWallet( string email, decimal amount);
         public User Register(string name, string password, string phoneNumber, string email, string address,string role, bool isDeleted);
         
         public decimal MakePayment(string email, decimal amount );

    }
    
}
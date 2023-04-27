using DreamsFashionApp.Models.Entities;

namespace DreamsFashionApp.Manager.Interface
{
    public interface IAdminManager
    {
        
        // public Admin Register(string name, string phoneNumber, string password, string email, string address);
         
        public Admin Get(string email);
         public Admin Get(int userId);
    }
}
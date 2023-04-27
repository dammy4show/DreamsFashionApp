using System.Collections.Generic;
using DreamsFashionApp.Models.Entities;

namespace DreamsFashionApp.Manager.Interface
{
    public interface IProductManager
    {
        public Product Register(string productName, int quantity, decimal price);
        public Product GetByName(string productName);
        public Product GetById(int id);
        public decimal GetByPrice(Product product);
        public int GetByQuantity(Product product);
        public List<Product> GetAll();
        public Product Update(int id, string productName, int quantity, decimal price);
        public void Delete(int id);
    }
}
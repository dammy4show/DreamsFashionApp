using System.Collections.Generic;
using System.Text;

namespace DreamsFashionApp.Models.Entities
{
    public class Product : BaseEntity
    {
        
        public string ProductName;
        public int Quantity;
        public decimal Price;
       
        
        

        public Product(int id, string productName, int quantity,decimal price, bool isDeleted) : base(id, isDeleted)
        {
            Id = id;
            ProductName= productName;
            Quantity = quantity;
            Price = price;
            IsDeleted = isDeleted;
        }

        public static  Product ToProduct(string model)
        {
            var use = model.Split('\t');
            int id = int.Parse(use[0]);
            string productName = use[1];
            int quantity = int.Parse(use[2]);
            decimal price = decimal.Parse(use[3]);
            bool isDeleted = bool.Parse(use[4]);


           
            return new Product(id,productName, quantity, price, isDeleted);


 
        }
        public override string ToString()
        {


            return $"{Id}\t{ProductName}\t{Quantity}\t{Price}\t{IsDeleted}";
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using DreamsFashionApp.Manager.Interface;
using DreamsFashionApp.Models.Entities;

namespace DreamsFashionApp.Manager.Implementation
{
    public class ProductManager : IProductManager
    {

        IUserManager userManager = new UserManager();
        List<Product> productDb = new List<Product>();
        string file =    @"C:\Users\Sowunmi Damilola\Desktop\FULL STACK CLASSES\DreamsFashionApp\Files\productsDb.txt";

        public ProductManager()
        {
            ReadProducToFile();
        }

        public void ReadProducToFile()
         {
            if(File.Exists(file))
            {
                var products = File.ReadAllLines(file);
                foreach (var product in products)
                {
                    productDb.Add(Product.ToProduct(product));
                }

            }
            else
            {
                
                string path =  @"C:\Users\Sowunmi Damilola\Desktop\FULL STACK CLASSES\DreamsFashionApp\Files";
                Directory.CreateDirectory(path);
                string fileName = "productsDb.txt";
                string fullPath = Path.Combine(path, fileName);
                File.Create(fullPath);
            }
         }

          private void AddProductToFile(Product product)
         {
            using (StreamWriter stw = new StreamWriter(file, true))
            {
                stw.WriteLine(product.ToString());
            }
         }

         private void RefreshFile()
         {
            using(StreamWriter stw = new StreamWriter(file))
            foreach(var product in productDb)
            {
                stw.WriteLine(product.ToString());
            }
        }

        public Product Register(string productName, int quantity, decimal price)
        {
            var productExist = GetByName(productName);
            if(productExist == null)
            { 
                int id = productDb.Count +1;
                 bool isDeleted = false;
                Product product = new Product(id, productName, quantity, price , isDeleted );
                if(quantity <=0 || price <=0)
                {
                   Console.WriteLine("You cannot eneter a 0 for quantity and negative value for price");
                }
                else
                {
                    productDb.Add(product);
                    AddProductToFile(product);
                    return product;
                }
                
            }
            return null;
        }


        public Product GetByName(string productName)
        {
            foreach(var product in productDb)
            {
                if(product.ProductName == productName)
                {
                    return product;
                }
            }
            return null;
        }

         public decimal GetByPrice(Product product)
        {
            foreach( var pro in productDb)
            {
                if(pro == product)
                {
                    return pro.Price;
                }
            }
            return 0;

        }
        public int GetByQuantity(Product product)
        {
          foreach(var pro in productDb)
          {
            if(pro==product)
            {
                return pro.Quantity;
            }
          
          }
          return 0;
        }

        public Product GetById(int id)
        {

            foreach(var product in productDb)
            {
                if(product.Id == id)
                {
                    return product;
                }
            }
            return null;
        }

        public List<Product> GetAll()
        {
            return productDb;
        }

        public Product Update(int id, string productName, int quantity, decimal price)
        {
            var product = CheckIfExist(id);
            if(product != null)
            {
                product.Price = price;
                product.ProductName = productName;
                product.Quantity = quantity;
                RefreshFile();
                return product;
            }
            return null;

        }
        public void Delete(int id)
        {
            
            var product = GetById(id);
            if(product == null)
            {
                Console.WriteLine("Product does not exist");
            }
            product.IsDeleted = true;
            
            Console.WriteLine("Product deleted successfully");
            RefreshFile();
            
        }


        private Product CheckIfExist(int id)
        {
            foreach(var product in productDb)
            {
                if(product.Id == id && product.IsDeleted == false)
                {
                    return product;
                }
            }
            return null;
        }

        private Product CheckIfExist(string productName)
        {
            foreach(var product in productDb)
            {
                if(product.ProductName == productName && product.IsDeleted == false)
                {
                    return product;
                }
            }
            return null;
        }


        

        

        
    }
}
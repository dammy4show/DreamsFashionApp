using System;
using System.Collections.Generic;
using System.IO;
using DreamsFashionApp.Manager.Interface;
using DreamsFashionApp.Models.Entities;

namespace DreamsFashionApp.Manager.Implementation
{
    public class OrderManager : IOrderManager
    {
        IUserManager userManager = new UserManager();
        ICustomerManager customerManager = new CustomerManager();
        

          List<Order> orderDb = new List<Order>();
        string file =   @"C:\Users\Sowunmi Damilola\Desktop\FULL STACK CLASSES\DreamsFashionApp\Files\orderDb.txt";
       
        public OrderManager()
        {
            ReadOrderToFile();
        }
       
        private void ReadOrderToFile()
         {
            if(File.Exists(file))
            {
                var orders = File.ReadAllLines(file);
                foreach (var order in orders)
                {
                    orderDb.Add(Order.ToOrder(order));
                }

            }
            else
            { 
                string path =  @"C:\Users\Sowunmi Damilola\Desktop\FULL STACK CLASSES\DreamsFashionApp\Files";
                Directory.CreateDirectory(path);
                string fileName = "orderDb.txt";
                string fullPath = Path.Combine(path, fileName);
                File.Create(fullPath);
            }
         }

         private void AddOrderToFile(Order order)
         {
            using (StreamWriter stw = new StreamWriter(file, true))
            {
                stw.WriteLine(order.ToString());
            }
         }

         private void RefreshFile()
         {
            using(StreamWriter stw = new StreamWriter(file))
            foreach(var order in orderDb)
            {
                stw.WriteLine(order.ToString());
            }
         }
        
        public Order Create(string email,  Dictionary<string, int> cart)
        {
            
            

        }

        public Order Get(int id)
        {
            
             foreach( var order in orderDb)
            {
                if(order.Id == id)
                {
                    return order;
                }
            }
            return null;
            
        }

        public Order Get(string email)
        {
            var user = userManager.Get(email);
            foreach( var order in orderDb)
            {
                if(user.Email== email)
                {
                    return order;
                }
            }
            return null;
            
        }




        //Check if there's no need to add any link of user to order in other to get the details of the order in the user database..ire oo
        public Order Update(User user,  Dictionary<string, int> cart)
        {
            var order = Get(user.Email);
                       
            if(order != null)
            {
               order.Cart = cart;
               RefreshFile();
                
                return order ;
            
            }
            return null;

           
        }

        public List<Order> GetAll()
        {
            return orderDb;
        }

        public void Delete(User user)
        {
            var order = Get(user.Email);
            if(order == null)
            {
                Console.WriteLine("Order does not exist");
            }
            order.IsDeleted = true;
            RefreshFile();
            Console.WriteLine("Order deleted successfully");
        }

        

        
        private Order CheckIfExist(string email)
        {
            var user = userManager.Get(email);
            foreach(var order in orderDb)
            {
                if(user.Email == email && order.IsDeleted == false )
                {
                    return order;
                }
            }
            return null;
           
        }

        private Order CheckIfExist(int id)
        {
            foreach(var order in orderDb)
            {
                if(order.Id == id && order.IsDeleted == false )
                {
                    return order;
                }
            }
            return null;
           
        }

        

        
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using DreamsFashionApp.Manager.Interface;
using DreamsFashionApp.Models.Entities;

namespace DreamsFashionApp.Manager.Implementation
{
     class CustomerManager : ICustomerManager
    {
        IUserManager userManager = new UserManager();
        List<Customer> customerDb = new List<Customer>();
        string file =  @"C:\Users\Sowunmi Damilola\Desktop\FULL STACK CLASSES\DreamsFashionApp\Files\customerDb.txt";

        public CustomerManager()
        {
            ReadCustomerToFile();
        }
        
        public void ReadCustomerToFile()
         {
            if(File.Exists(file))
            {
                var customers = File.ReadAllLines(file);
                foreach (var customer in customers)
                {
                    customerDb.Add(Customer.ToCustomer(customer));
                }

            }
            else
            {
                
                string path =  @"C:\Users\Sowunmi Damilola\Desktop\FULL STACK CLASSES\DreamsFashionApp\Files";
                
                Directory.CreateDirectory(path);
                string fileName = "customerDb.txt";
                string fullPath = Path.Combine(path, fileName);
                File.Create(fullPath);
            }
         }

         private void AddCustomerToFile(Customer customer)
         {
            using (StreamWriter stw = new StreamWriter(file, true))
            {
                stw.WriteLine(customer.ToString());
            }
         }

         private void RefreshFile()
         {
            using(StreamWriter stw = new StreamWriter(file))
            foreach(var customer in customerDb)
            {
                stw.WriteLine(customer.ToString());
            }
         }

        public Customer Register(string email, string name, string password, string phoneNumber, string address, string role, bool isDeleted)
        {
          
            var userExist = userManager.Get(email);
            if(userExist == null)
            {
                
                var user = userManager.Register(name, password, phoneNumber, email, address, "Customer", false );
                if(user != null)
                {
                    Customer customer = new Customer(customerDb.Count +1, user.Id, false);
                    customerDb.Add(customer);
                    AddCustomerToFile(customer);
                    return customer;
                }
                
                
            }

            return null;

             
            
        }

        public Customer Get(string email)
        {
            var user = userManager.Get(email);
            foreach( var customer in customerDb)
            {
                
                if(user.Email == email)
                {
                    return customer;
                }
            }
            return null;
        }

        public Customer Get(int userId)
        {
            foreach( var customer in customerDb)
            {
                if(customer.UserId == userId)
                {
                    return customer;
                }
            }
            return null;

        }
        

        public List<Customer> GetAll()
        {
            
            return customerDb;
        }

        public Customer Update(string email, string name, string phoneNumber, string password, string address)
        {
            var user= userManager.Get(email);
            if(user != null)
            {
                user.Name = name;
                user.PhoneNumber = phoneNumber;
                user.Password = password;
                user.Address = address;
                
                var customer= Get(user.Id);
                RefreshFile();
                return customer;
            }
            return null;
        }

        public void Delete(int id)
        {
            
            var customer =Get(id);
            var user = userManager.Get(id);
            if(user != null && user.Role == "Customer")
            {
                user.IsDeleted = true;
                
                    customer.IsDeleted = true;
                    Console.WriteLine("Customer deleted successfully");
                    RefreshFile();
                
            }   
            else 
            {
                Console.WriteLine("Customer does not exist");
                
            }
            
        }

        

        


        


        

        private Customer CheckIfExist(int userId)
        {
            foreach( var customer in customerDb )
            {
                if(customer.UserId == userId && customer.IsDeleted == false)
                {
                    return customer;
                }
            }
            return null;
        }

        private Customer CheckIfExist(string email)
        {
            var user = userManager.Get(email);
            foreach(var customer in customerDb)
            {
                if(user.Email == email && customer.IsDeleted == false)
                {
                    return customer;
                }
            }
            return null;
        }

        
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using DreamsFashionApp.Manager.Interface;
using DreamsFashionApp.Models.Entities;

namespace DreamsFashionApp.Manager.Implementation
{
    public class UserManager : IUserManager
    {
        
        public static List<User> userDb = new List<User>();
        string file =  @"C:\Users\Sowunmi Damilola\Desktop\FULL STACK CLASSES\DreamsFashionApp\Files\userDb.txt";

        public UserManager()
        {
            ReadUserToFile();
        }
        public void ReadUserToFile()
        {
            if(File.Exists(file))
            {
                if(userDb.Count == 0)
                {
                    var users = File.ReadAllLines(file);
                    foreach(var user in users)
                    {
                        userDb.Add(User.ToUser(user));
                    }
                }
                else
                {
                    userDb.Clear();
                    var users = File.ReadAllLines(file);
                    foreach(var user in users)
                    {
                        userDb.Add(User.ToUser(user));
                    }

                }
                
            }
            else
            {
                string path =   @"C:\Users\Sowunmi Damilola\Desktop\FULL STACK CLASSES\DreamsFashionApp\Files";
                Directory.CreateDirectory(path);
                string fileName = "userDb.txt";
                string fullpath = Path.Combine(path, fileName);
                File.Create(fullpath);


            }
            
        }

        public void AddUserToFile(User user)
        {

            using (StreamWriter stw = new StreamWriter(file, true))
            {
                stw.WriteLine(user.ToString());
            }
        }

        public void RefreshFile()
         {
            using(StreamWriter stw = new StreamWriter(file))
            foreach(var item in userDb)
            {
                stw.WriteLine(item.ToString());
            }
         }
        

        public void Delete(string email)
        {
            var user =  CheckIfExist(email);
            {
                if(user != null)
                {
                    userDb.Remove(user);
                    RefreshFile();
                    Console.WriteLine("User successfully deleted");
                }
                Console.WriteLine("User does not exists");
            }
        }

        public User Get(int id)
        {
            foreach(var user in userDb )
            {
                if(user.Id == id)
                {
                    return user;
                }
            }
            return null;
        }

        public decimal FundWallet(string email, decimal amount)
        {
            var user = Get(email);
            if( amount <= 0)
            {
                Console.WriteLine("You have entered a wrong input");
                return 0;
            }
            else
            {
                user.Wallet += amount;
                Console.WriteLine($"Your account has been funded with {amount} and your balance is {user.Wallet}");
                UpdateWallet(user);
                RefreshFile();
                return user.Wallet;
            }
        }

        public decimal UpdateWallet(User user)
        {
            decimal newWallet = user.Wallet;
            return newWallet;
        }




         public User Update( string name, string address, string email, string password, string phoneNumber)
        {
            Console.WriteLine("Enter your old email");
            var mail = Console.ReadLine();
            var user = Get(mail);
            if(user != null)
            {
                user.Name = name;
                user.Address = address;
                user.PhoneNumber = phoneNumber;
                user.Password  = password;
                user.Email = email;
            
                RefreshFile();
                Console.WriteLine("Your details is successfully updated");
                return user;
                
            }
            Console.WriteLine("return null");
            return null;
        }
    

        public User Get(string email)
        {
            foreach(var user in userDb)
            {
                if(user.Email == email)
                {
                    return user;
                }
            }
            return null;
        }

        public List<User> GetAll()
        {
            return userDb;
        }

        public User Login(string email, string password)
        {
           
            foreach(var user in userDb)
            {
                if(user.Email == email && user.Password == password && user.IsDeleted == false)
                {
                    Console.WriteLine("You are welcome...Thank you for visiting our store");
                    return user;
                }
            }
           
            return  null;

        }

        

        private User CheckIfExist(string email)
        {
            foreach( var user in userDb)
            {
                if(user.Email == email)
                {
                    return user;
                }
            }
            return null;
        }

        public decimal MakePayment(string email, decimal amount )
        {
            
            var user = Get(email);
            
                    if(user.Wallet >= amount  )
                    {
                        user.Wallet -= amount;
                        DateTime  now = DateTime.Now;
                        Console.WriteLine($"Your account has been debited with {amount} at {now.ToString("F")} and your balance is {user.Wallet}");
                        if (amount> 2000)
                        {
                            user.Wallet += 500;
                            Console.WriteLine("We have given you a bonus of 500 because you bought fabrics more than 2000");
                        }
                        RefreshFile();
                        return amount;
                    }
                    else 
                    {
                        Console.WriteLine("Insufficent Balance");
                        return 0;

                    }
                }

        


        public User Register(string name, string password, string phoneNumber, string email, string address,string role, bool isDeleted)
        {

            User user = new User(userDb.Count + 1 , name, password, phoneNumber, email, address, 0, role, false);
            userDb.Add(user);
            AddUserToFile(user);
            return user;
        }

        
    }
}
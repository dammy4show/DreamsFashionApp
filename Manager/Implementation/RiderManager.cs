using System;
using System.Collections.Generic;
using System.IO;
using DreamsFashionApp.Manager.Interface;
using DreamsFashionApp.Models.Entities;

namespace DreamsFashionApp.Manager.Implementation
{
    public class RiderManager : IRiderManager
    {

        List<Rider> riderDb = new List<Rider>();
        IUserManager userManager = new UserManager();
        string file =   @"C:\Users\Sowunmi Damilola\Desktop\FULL STACK CLASSES\DreamsFashionApp\Files\riderDb.txt";


        public RiderManager()
        {
            ReadRiderToFile();
        }
        public void ReadRiderToFile()
         {

            
            if(File.Exists(file))
            {
                var riders = File.ReadAllLines(file);
                foreach (var rider in riders)
                {
                    riderDb.Add(Rider.ToRider(rider));
                }

            }
            else
            {
                
                string path =  @"C:\Users\Sowunmi Damilola\Desktop\FULL STACK CLASSES\DreamsFashionApp\Files";
                Directory.CreateDirectory(path);
                string fileName = "riderDb.txt";
                string fullPath = Path.Combine(path, fileName);
                File.Create(fullPath);
            }
         }

         private void AddRiderToFile(Rider rider)
         {
            using (StreamWriter stw = new StreamWriter(file, true))
            {
                stw.WriteLine(rider.ToString());
            }
         }

         private void RefreshFile()
         {
            using(StreamWriter stw = new StreamWriter(file))
            foreach(var rider in riderDb)
            {
                stw.WriteLine(rider.ToString());
            }
         }

        public Rider Register(string name, string phoneNumber, string password, string email, string address)
        {
          
                
            var userExist = userManager.Get(email);
            if(userExist == null)
            {
                
                var user = userManager.Register(name,password, phoneNumber,  email, address, "Rider", false );
                if(user != null)
                {
                    Rider rider = new Rider(riderDb.Count +1, user.Id, false);
                    riderDb.Add(rider);
                    AddRiderToFile(rider);
                    return rider;
                }
                
                
            }

            return null;

             

        }

        public void Delete(int id)
        {
           var rider = CheckIfExist(id);
            if(rider == null)
            {
                Console.WriteLine("Rider does not exist");
            }
            rider.IsDeleted = true;
            Console.WriteLine("Rider deleted successfully");
            RefreshFile();
        }

        public Rider Get(int id)
        {
            foreach( var rider in riderDb)
            {
                if(rider.Id == id)
                {
                    return rider;
                }
            }
            return null;
        }

        public Rider Get(string email)
        {
            var user = userManager.Get(email);
            foreach( var rider in riderDb)
            {
                
                if(user.Email == email)
                {
                    return rider;
                }
            }
            return null;
        }

        public List<Rider> GetAll()
        {
            return riderDb;
        }

    
        public Rider Update(string email, string name, string phoneNumber, string password, string address)
        {
            var user= userManager.Get(email);
            if(user != null)
            {
                user.Name = name;
                user.PhoneNumber = phoneNumber;
                user.Password = password;
                user.Address = address;
                RefreshFile();
                var rider= Get(user.Id);
                RefreshFile();
                return rider;
            }
            return null;
        }

        

        private Rider CheckIfExist(int id)
        {
            foreach( var rider in riderDb )
            {
                if(rider.Id== id && rider.IsDeleted == false)
                {
                    return rider;
                }
            }
            return null;
        }

        private Rider CheckIfExist(string email)
        {
            var user = userManager.Get(email);
            foreach(var rider in riderDb)
            {
                if(user.Email == email && rider.IsDeleted == false)
                {
                    return rider;
                }
            }
            return null;
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using DreamsFashionApp.Manager.Interface;
using DreamsFashionApp.Models.Entities;

namespace DreamsFashionApp.Manager.Implementation
{
    public class AdminManager : IAdminManager
    {
        
        IUserManager userManager = new UserManager();
        List<Admin> adminDb = new List<Admin>();
         string file = @"C:\Users\Sowunmi Damilola\Desktop\FULL STACK CLASSES\DreamsFashionApp\Files\adminDb.txt";
         

        public AdminManager()
        {
            ReadAdminToFile();
        }
         public void ReadAdminToFile()
         {
            if(File.Exists(file))
            {
                var admins = File.ReadAllLines(file);
                foreach (var admin in admins)
                {
                    adminDb.Add(Admin.ToAdmin(admin));
                }

            }
            else
            {
                
                string path =  @"C:\Users\Sowunmi Damilola\Desktop\FULL STACK CLASSES\DreamsFashionApp\Files";
                
                Directory.CreateDirectory(path);
                string fileName = "adminDb.txt";
                string fullPath = Path.Combine(path, fileName);
                File.Create(fullPath);
            }
         }

         private void AddAdminToFile(Admin admin)
         {
            using (StreamWriter stw = new StreamWriter(file, true))
            {
                stw.WriteLine(admin.ToString());
            }
         }

         private void RefreshFile()
         {
            using(StreamWriter stw = new StreamWriter(file))
            foreach(var item in adminDb)
            {
                stw.WriteLine(item.ToString());
            }
         }
        
        //Check that its updating in the adminMenu
       

        public Admin Get(string email)
        {
            var user = userManager.Get(email);
            var admin = CheckIfExist(email);
            foreach (var item in adminDb)
            {
                if(user.Email == email)
                return admin;
            }
            return null;
        }

        public Admin Get(int userId)
        {
            
            foreach (var admin in adminDb)
            {
                if(admin.UserId == userId)
                return admin;
            }
            return null;
        }

         private Admin CheckIfExist(int userId)
        { 
            foreach(var admin in adminDb)
            {
                
                if(admin.UserId == userId)
                {
                    return admin;
                }
            }
            return null;
        }

        private Admin CheckIfExist(string email)
        { 
            var user = userManager.Get(email);
            foreach(var admin in adminDb)
            {
                
                if(user.Email == email)
                {
                    return admin;
                }
            }
            return null;
        }
    }
}
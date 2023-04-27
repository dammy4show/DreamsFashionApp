using System;
using DreamsFashionApp.Manager.Implementation;
using DreamsFashionApp.Manager.Interface;
using DreamsFashionApp.Menu.Implementation;

namespace DreamsFashionApp.Menu
{
    public class MainMenu
    {

        IUserManager userManager = new UserManager();
        IAdminManager adminManager = new AdminManager();
        AdminMenu adminMenu = new AdminMenu();
        RiderMenu riderMenu = new RiderMenu();
        CustomerMenu customerMenu = new CustomerMenu();
        ICustomerManager customerManager = new CustomerManager();
        IRiderManager riderManager = new RiderManager();


        public void Menu()
        {
            Console.WriteLine("Welcome to Dreams Fabrics...Dress the way you want to be address\nEnter 1 to sign up\nEnter 2 to LogIn");
            int option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                RegisterMenu();
                Menu();
            }
            else if (option == 2)
            {
                LogInMenu();

            }
            else
            {
                Console.WriteLine("You have entered a wrong option");
                Menu();
            }
        }
        public void RegisterMenu()
        {
            Console.WriteLine("Please enter your  name");
            string name = Console.ReadLine();

            Console.WriteLine("Please enter your email");
            string email = Console.ReadLine();

            Console.WriteLine("Please enter your password");
            string password = Console.ReadLine();
            Console.WriteLine("Please enter your phone number");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Please enter your address");
            string address = Console.ReadLine();
            
            Console.WriteLine("\nEnter 1 for Customer\nEnter 2 for Rider");
            int option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                
                var customer = customerManager.Register(email,name, password, phoneNumber, address, "Customer", false);

                Console.WriteLine("You have successfully registered as customer");

            }
            else if (option == 2)
            {
                var rider = riderManager.Register(name, phoneNumber, password, email, address);
                Console.WriteLine("You have successfully registered as rider");

            }
            else
            {
                Console.WriteLine("You cannot register twice");
            }


        }


        public void LogInMenu()
        {
            Console.WriteLine("Enter your Email:");
            string email = Console.ReadLine();
            Console.WriteLine("Please enter your password");
            string password = Console.ReadLine();
            var login = userManager.Login(email, password);

            if (login != null)
            {

                if (login.Role == "Admin")
                {
                    adminMenu.AdminMain();
                }
                else if (login.Role == "Customer")
                {
                    customerMenu.CustomerMain();
                }
                else if (login.Role == "Rider")
                {
                    riderMenu.RiderMain();
                }

            }

            else
            {
                Console.WriteLine("Wrong input....Enter a Valid Email And Password");
                Console.WriteLine("Do you wish LogIn\nEnter 1 to LogIn\n Enter 2 to LogOut");
                int input = int.Parse(Console.ReadLine());
                if (input == 1)
                {
                    var menu = new MainMenu();
                    menu.LogInMenu();
                }

            }
        }


    }




}
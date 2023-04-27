using System;
using DreamsFashionApp.Manager.Implementation;
using DreamsFashionApp.Manager.Interface;
using DreamsFashionApp.Menu.Interface;

namespace DreamsFashionApp.Menu.Implementation
{
    public class AdminMenu :IAdminMenu
    {
        IProductManager productManager = new ProductManager();
        IRiderManager riderManager = new RiderManager();
        ICustomerManager customerManager = new CustomerManager();
        IOrderManager orderManager = new OrderManager();
        CustomerMenu customerMenu = new CustomerMenu();
        IUserManager userManager = new UserManager();
        IAdminManager adminManager = new AdminManager();

       
        
        
        public void AdminMain()
        {
            Console.WriteLine("Enter 1 to Upload Products\nEnter 2 to view All Customers\nEnter 3 to View All Riders\nEnter 4 to Disable Customer\nEnter 5 to  View All Products\nEnter 6 to Disable Rider\nEnter 7 to Delete Product\nEnter 8 to Update Details\nEnter 9 to Log Out");
            int option = int.Parse(Console.ReadLine());
            if(option == 1)
            {
                UploadProduct();
                
            }
            else if(option == 2)
            {
                 ViewAllCustomers();

            }
            else if(option == 3)
            {
                ViewAllRiders();

            }
            else if(option == 4)
            {
                DisableCustomer();
                
            }
            else if(option == 5)
            {
                ViewAllProducts();

            }
            else if(option == 6) 
            {
                DeleteRider();

            }
            else if(option == 7)
            {
                
                DeleteProduct();
                  
            }
            
            else if(option == 8)
            {
                UpdateAdmin();
            }
            else if(option == 9)
            {
                LogOut();

            }
            
            else
            {
                Console.WriteLine("You have entered a Wrong Input");
                AdminMain();
            }
        }
        public void UploadProduct()
        {
            Console.WriteLine("Enter your Product Name");
            string productName = Console.ReadLine();
            Console.WriteLine("Enter the Product Price ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Available Quantity");
            int quantity = int.Parse(Console.ReadLine());
            productManager.Register(productName, quantity, price );
            
            Console.WriteLine("Enter 1 to upload more product \nEnter 2 to Stop Uploading");
            int option = int.Parse(Console.ReadLine());
            if(option == 1)
            {
                UploadProduct();
            
            }
            else if (option == 2)
            {
                AdminMain();
            }
           
        }

                //Check if it works or you will just need to use customer.Id and customer.UserId
        public void ViewAllCustomers( )
        {
            
             var customers = customerManager.GetAll();
            foreach(var customer in customers)
            {
                //var user = userManager.Get(customer.UserId);
                Console.WriteLine($"{customer.Id}\t{customer.UserId}\t{customer.IsDeleted}");
            }
            AdminMain();
        }

        public void ViewAllRiders()
        {
             var rider = riderManager.GetAll();
             foreach(var item in rider)
             {
                //var user = userManager.Get(item.UserId);
                Console.WriteLine($"{item.Id}\t{item.UserId}\t{item.IsDeleted}");
             }
             AdminMain();
        }

        public void DisableCustomer()
        {
            
            Console.WriteLine("Enter the User Id ");
            int id = int.Parse(Console.ReadLine());
            customerManager.Delete(id);
            AdminMain();

        }

        

        public void ViewAllProducts()
        {
            var product = productManager.GetAll();
            foreach(var item in product)
            {
                Console.WriteLine($"{item.ProductName}\t {item.Quantity}\t {item.Price}");
            }
            AdminMain();
            
        }
                public void DeleteRider()
        {
            Console.WriteLine("Please enter the id of the rider");
            int id =int.Parse(Console.ReadLine());
            riderManager.Delete(id);
            AdminMain();
        }
        

        public void DeleteProduct()
        {
            Console.WriteLine("Please enter Product Id ");
            int id= int.Parse(Console.ReadLine());
            productManager.Delete(id);
            AdminMain();
            
        }


        public void LogOut()
        {
            Console.WriteLine("Have a good day");
            MainMenu mainMenu = new MainMenu();
            mainMenu.Menu();
        }

        
        



        public void UpdateAdmin()
        {
            Console.WriteLine("Please enter your new name");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter your new address");
            string address = Console.ReadLine();
            Console.WriteLine("Please enter your new email");
            string email = Console.ReadLine();
            Console.WriteLine("Please enter your new password");
            string password = Console.ReadLine();
            Console.WriteLine("Please enter your new phoneNumber");
            string phoneNumber = Console.ReadLine();
            userManager.Update(name, address, email, password, phoneNumber);
            AdminMain();

        }
        

    }
}
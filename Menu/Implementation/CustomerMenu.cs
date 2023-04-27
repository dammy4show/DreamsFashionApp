using System;
using System.Collections.Generic;
using DreamsFashionApp.Manager.Implementation;
using DreamsFashionApp.Manager.Interface;

namespace DreamsFashionApp.Menu.Implementation
{
    public class CustomerMenu
    {
        IProductManager productManager = new ProductManager();

        ICustomerManager customerManager = new CustomerManager();
        IOrderManager orderManager = new OrderManager();
        IUserManager userManager = new UserManager();
        public void CustomerMain()
        {
            Console.WriteLine("Enter 1 to view All products\nEnter 2 to Fund Wallet\nEnter 3 to Make Order\nEnter 4 to Update Profile\nEnter 5 to LogOut");
            int option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                ViewAllProducts();
            }
            else if (option == 2)
            {
                FundWallet();

            }
            else if (option == 3)
            {
                MakeOrder();
            }
            else if (option == 4)
            {
                UpdateCustomer();
            }
            else if (option == 5)
            {
                LogOut();
            }

        }


        public void FundWallet()
        {

            Console.WriteLine("Enter your Email for Verification");
            string email = Console.ReadLine();
            Console.WriteLine("Enter the  Fund Amount");
            decimal amount = decimal.Parse(Console.ReadLine());
            userManager.FundWallet(email, amount);
            CustomerMain();
        }

        public void MakeOrder()
        {
            Console.WriteLine("These are the Products that are available");
            var Catalog = productManager.GetAll();
            foreach (var item in Catalog)
            {
                if (item.IsDeleted == false)
                {
                    Console.WriteLine($"{item.ProductName}\t {item.Quantity}\t {item.Price}");
                }
                else
                {

                    Console.WriteLine("null");
                }

                
            }
            Dictionary<string, int> cart = new Dictionary<string, int>();
            Console.Write("enter your Fabric Name : ");
            string fabricName = Console.ReadLine();
            Console.Write("enter your quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter your email");
            string email = Console.ReadLine();
            var c = orderManager.Create(email, cart);
            var prod = productManager.GetByName(fabricName);
            var quantityAvailable = productManager.GetByQuantity(prod);
            if (quantity > quantityAvailable || quantity < quantityAvailable )
            {
                Console.WriteLine($"You cannot order...Quantity available is {quantityAvailable}..You can call the HR on 0803456789");
               CustomerMain();
            }
            else
            {
                 cart.Add(fabricName, quantity);
            var productDetails = productManager.GetByName(fabricName);
            var product = productManager.GetAll();
            product.Remove(productDetails);
            System.Console.WriteLine($"welcome {fabricName} \t {quantity} has successfuly picked to your cart ");
            Console.WriteLine("Enter 1 to pick more\nEnter 2 to Stop picking");
            int option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                MakeOrder();

            }
            else if(option ==2)
            {
            Console.WriteLine("Enter 1 to make payment\nEnter 2 to goBack to MainMenu");
            int options = int.Parse(Console.ReadLine());
                if (options == 1)
                {
                Console.WriteLine("Enter your amount ");
                decimal amount = decimal.Parse(Console.ReadLine());
                var productPrice = prod.Price;
                    if(amount == productPrice )
                    {
                        userManager.MakePayment(email, amount);
                    }
                    else
                    {
                        Console.WriteLine("You have entered a wrong amount");
                    }
                        
                
                
                CustomerMain();
            }
            else if(option == 2)
            {
                CustomerMain();
            }
            else
            {
                Console.WriteLine("You have entered a wrong input");
            }
            




            }
            

            }
           
        }

        public void ViewAllProducts()
        {
            var product = productManager.GetAll();
            foreach (var item in product)
            {
                if (item.IsDeleted == false)
                {
                    Console.WriteLine($"{item.ProductName}\t {item.Quantity}\t {item.Price}");
                }
                else
                {

                    Console.WriteLine("null");
                }


            }
            CustomerMain();
        }

        public void LogOut()
        {
            Console.WriteLine("Thank you choosing us...We hope to see you soon");
            

        }

        public void UpdateCustomer()
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
            CustomerMain();

        }

    }
}
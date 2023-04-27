using System;
using DreamsFashionApp.Menu.Interface;

namespace DreamsFashionApp.Menu.Implementation
{
    public class RiderMenu :IRiderMenu
    {
        public void RiderMain()
        {
            Console.WriteLine("Enter 1 to View All Sales\nEnter 2 to Deliver Products\nEnter 3 to Log out  ");
            int option= int.Parse(Console.ReadLine());
            if(option == 1)
            {
                ViewAllSales();
            }
            else if(option == 2)
            {
                DeliverProduct();
            }
            else if(option == 3)
            {
                LogOut();
            }
            else
            {
                Console.WriteLine("You have input a Wrong Option");

            }
        }

        public void ViewAllSales()
        {
            throw new NotImplementedException();
        }
        public void DeliverProduct()
        {
            throw new NotImplementedException();
        }

        public void LogOut()
        {
            Console.WriteLine("Thank you Dear Esteemed rider...Delivery is the sole of our business...Ensure you deliver");
            
        }
    }
}
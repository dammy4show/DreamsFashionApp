using System;
using System.Collections.Generic;
using DreamsFashionApp.Manager.Implementation;
using DreamsFashionApp.Menu;
using DreamsFashionApp.Menu.Implementation;
using DreamsFashionApp.Models.Entities;

namespace DreamsFashionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Menu();

            
            // Dictionary<string, int> cart = new Dictionary<string, int>
            // {
            //     {"ankarsa", 3},
            // };
            // OrderManager orderManager = new OrderManager();
            // var c = orderManager.Create("dammy@gmail.com", cart);
            // System.Console.WriteLine($"{c}", "seeee");
            // UserManager userManager = new UserManager();
            // userManager.ReadUserToFile();

           
        }
    }
}

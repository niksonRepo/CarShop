using System;
using System.Collections.Generic;
using System.Linq;
using CarShop.Library;

namespace CarShop.Frontend
{
    class Program
    {
        static readonly CarOperations CarOperator = new CarOperations();

        static void Main(string[] args)
        {
            CarOperator.ShowMenu();

            var exit = "continue";

            while (exit == "continue")
            {
                var option = Console.ReadLine();

                if (option is "exit")//if(option != null && option == exit)
                {
                    exit = option;
                }

                switch (option)
                {
                    case "1":
                        //Add car to the list
                        CarOperator.AddCarToTheList();
                        break;
                    case "2":
                        //Find a car by is available
                        CarOperator.FindAvailableCarsCount();
                        break;
                    case "3":
                        //Get cars by year
                        CarOperator.GetCarByYear();
                        break;
                    case "4":
                        //Show list of all presented cars
                        CarOperator.ShowListOfAllCars();
                        break;
                    case "5":
                        //Buying a car
                        CarOperator.BuyCar();
                        break;
                }
            };
        }
    }
}

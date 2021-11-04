using System;
using CarShop.Library;

namespace CarShop.Frontend
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = new Car()
            {
                Model = "BMW M5",
                Color = "Black",
                Year = 2021
            };

            var carOperator = new CarOperations();
            carOperator.AddCarToTheList(car);

            //ShowMenu();
        }

        public static void ShowMenu()
        {
            Console.WriteLine("Please choose car operation:");
            Console.WriteLine("1. Add car to the shop");
            Console.WriteLine("2. Find car by criteria");
            Console.WriteLine("3. Get available cars");
            Console.ReadLine();
        }
    }
}

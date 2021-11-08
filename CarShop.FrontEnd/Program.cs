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
            ShowMenu();

            string exit = "continue";

            while (exit == "continue")
            {
                string option = Console.ReadLine();

                if (option.Equals("exit"))
                {
                    exit = option;
                }

                switch (option)
                {
                    case "1":
                        //Add car to the list
                        AddCarToTheList();
                        break;
                    case "2":
                        //Find a car by is available
                        Console.WriteLine($"Available car count is: {CarOperator.FindAvailableCarsCount()}");
                        break;
                    case "3":
                        //Get cars by year
                        GetCarByYear();
                        break;
                    case "4":
                        //Show list of all presented cars
                        ShowListOfAllCars();
                        break;
                    case "5":
                        //Get available cars
                        break;
                }
            };
        }

        public static void ShowMenu()
        {
            Console.WriteLine("Please choose car operation:");
            Console.WriteLine("1. Add car to the shop");
            Console.WriteLine("2. Find car by is available");
            Console.WriteLine("3. Find car by year");
            Console.WriteLine("4. Show list of all presented cars");
            Console.WriteLine("5. Buy a car");
        }

        public static Car CreateCarObject(int id)
        {
            var car = new Car
            {
                Id = id
            };

            Console.WriteLine("Please add car model:");
            car.Model = Console.ReadLine();

            Console.WriteLine("Add car color");
            car.Color = Console.ReadLine();

            Console.WriteLine("Add car year");
            car.Year = Convert.ToInt32(Console.ReadLine());

            return car;
        }

        public static void AddCarToTheList()
        {
            int id = 0;
            var continues = true;

            while (continues)
            {
                var car = CreateCarObject(id);
                CarOperator.AddCarToTheList(car);

                Console.WriteLine("Do you want to create more cars?(Yes/No)");

                var yesNo = Console.ReadLine();
                if (yesNo != "Yes")
                {
                    continues = false;
                    ShowMenu();
                }

                id++;
            }
        }

        public static void GetCarByYear()
        {
            Console.WriteLine("Please provide year");
            var year = Convert.ToInt32(Console.ReadLine());
            var carArray = CarOperator.FindCarByYear(year);

            foreach (var car in carArray)
            {
                Console.WriteLine($"Found car Id: {car.Id} model: {car.Model}");
            }
        }

        public static void ShowListOfAllCars()
        {
            int i = 0;

            foreach (var car in CarOperator.CarArray)
            {
                if (car != null)
                {
                    Console.WriteLine($"{i}. Car with {car.Id} model: {car.Model}");
                }

                i++;
            }
        }
    }
}

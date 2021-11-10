using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Library
{
    public class CarOperations : ICarOperations
    {
        public Car[] CarArray = new Car[100];

        public void AddCarToTheList(Car car)
        {
            var index = CarArray.Count(x => x != null);
            CarArray[index] = car;
        }

        public void FindAvailableCarsCount()
        {
            Console.WriteLine($"Available car count is: {CarArray.Count(x => x is {IsAvailable: true})}");
        }

        public Car[] FindCarByYear(int year)
        {
            return CarArray.Where(x => x != null && x.Year == year).ToArray();
        }

        public void ByCar(int id)
        {
            var selectedCar = CarArray.FirstOrDefault(x => x.Id == id);

            if (selectedCar != null)
            {
                selectedCar.Sold = true;
                selectedCar.IsAvailable = false;

                Console.WriteLine(
                    $"Congratulation with purchasing car : {selectedCar.Model}. Would you like to have receipt(Yes/No)?");

                var acceptReceipt = Console.ReadLine() == "Yes";

                if (acceptReceipt)
                {
                    Console.WriteLine(GetReceipt(selectedCar));
                }
            }
            else
            {
                Console.WriteLine($"There is not car with id: {id}");
            }
        }

        public string GetReceipt(Car car)
        {
            var receipt = new Recipient()
            {
                Car = car,
                Date = DateTime.Now,
                RecipientId = Guid.NewGuid().ToString(),
                RecipientName = "Car selling receipt"
            };

            return @$"
                        Receipt number: {receipt.RecipientId}
                        Receipt name: {receipt.RecipientName}
                        Model: {receipt.Car.Model}
                        Year:  {receipt.Car.Year}
                        Color: {receipt.Car.Color}
                        Date:  {receipt.Date.Date}
                    ";
        }

        public void ShowMenu()
        {
            Console.WriteLine("Please choose car operation:");
            Console.WriteLine("1. Add car to the shop");
            Console.WriteLine("2. Find car by is available");
            Console.WriteLine("3. Find car by year");
            Console.WriteLine("4. Show list of all presented cars");
            Console.WriteLine("5. Buy a car");
        }

        public Car CreateCarObject(int id)
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

        public void AddCarToTheList()
        {
            int id = 0;
            var continues = true;

            while (continues)
            {
                var car = CreateCarObject(id);
                AddCarToTheList(car);

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

        public void GetCarByYear()
        {
            Console.WriteLine("Please provide year");
            var year = Convert.ToInt32(Console.ReadLine());
            var carArray = FindCarByYear(year);

            foreach (var car in carArray)
            {
                Console.WriteLine($"Found car Id: {car.Id} model: {car.Model}");
            }
        }

        public void ShowListOfAllCars()
        {
            int i = 0;

            foreach (var car in CarArray)
            {
                if (car != null)
                {
                    Console.WriteLine($"{i}. Car with {car.Id} model: {car.Model}");
                }

                i++;
            }
        }

        public void BuyCar()
        {
            Console.WriteLine("Please provide car id from the car list");
            var carId = Convert.ToInt32(Console.ReadLine());

            ByCar(carId);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Library
{
    public class CarOperations : ICarOperations
    {
        private const string TextFile = @"C:\SchoolFiles\CarData.txt";

        public List<Car> CarDictionary = new();

        public void FindAvailableCarsCount()
        {
            var count = CarDictionary.Count(x => x != null && x.IsAvailable == true);
             UserOutput.FindAvailableCarMessage(count);
        }

        public Car[] FindCarByYear(int year)
        {
            int index = 0;
            var carArray = new Car[100];
            var carList = CarDictionary.Where(x => x != null && x.Year == year);

            foreach (var car in carList)
            {
                carArray[index] = car;
                index++;
            }

            return carArray;
        }

        public void ByCar(int id)
        {
            var selectedCar = CarDictionary.FirstOrDefault(x => x.Id == id);

            if (selectedCar != null)
            {
                selectedCar.Sold = true;
                selectedCar.IsAvailable = false;

                UserOutput.CongratulationMessage(selectedCar.Model);
            }
            else
            {
                UserOutput.NoCarWithIdMessage(id);
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

        public void AddCarToTheList(Car car)
        {
            CarDictionary.Add(car);
        }

        public void GetCarByYear(int year)
        {
            var carArray = FindCarByYear(year);

            foreach (var car in carArray)
            {
                UserOutput.FoundCarMessage(car.Id, car.Model);
            }
        }

        public void ShowListOfAllCars()
        {
            var i = 0;

            foreach (var car in CarDictionary)
            {
                if (car != null)
                {
                    UserOutput.ShowListOfCarsMessage(car.Id, car.Model, i);
                }

                i++;
            }
        }

        public void GetDataFormFile()
        {
            if (File.Exists(TextFile)) {  
                // Read entire text file content in one string    
                string text = File.ReadAllText(TextFile);

                var strArray = text.Split(',');
                
                foreach (var s in strArray)
                {
                    //s.Split(":")[]
                }
                Console.WriteLine(text);
            }
            else
            {

            }
        }
    }
}

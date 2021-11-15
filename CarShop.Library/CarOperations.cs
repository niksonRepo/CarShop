using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Library
{
    public class CarOperations : ICarOperations
    {
        public Dictionary<int, Car> CarDictionary = new();

        public void FindAvailableCarsCount()
        {
            var count = CarDictionary.Count(x => x.Value != null && x.Value.IsAvailable == true);
             UserOutput.FindAvailableCarMessage(count);
        }

        public Car[] FindCarByYear(int year)
        {
            int index = 0;
            var carArray = new Car[100];
            var carList = CarDictionary.Where(x => x.Value != null && x.Value.Year == year);

            foreach (var car in carList)
            {
                carArray[index] = car.Value;
                index++;
            }

            return carArray;
        }

        public void ByCar(int id)
        {
            var selectedCar = CarDictionary.FirstOrDefault(x => x.Value.Id == id);

            if (selectedCar.Value != null)
            {
                selectedCar.Value.Sold = true;
                selectedCar.Value.IsAvailable = false;

                UserOutput.CongratulationMessage(selectedCar.Value.Model);
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
            CarDictionary.Add(car.Id, car);
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
                if (car.Value != null)
                {
                    UserOutput.ShowListOfCarsMessage(car.Value.Id, car.Value.Model, i);
                }

                i++;
            }
        }
    }
}

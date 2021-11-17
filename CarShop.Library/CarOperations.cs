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
        public List<Car> Carlist = new();

        public void FindAvailableCarsCount()
        {
            var count = Carlist.Count(x => x != null && x.IsAvailable == true);
             UserOutput.FindAvailableCarMessage(count);
        }

        public Car[] FindCarByYear(int year)
        {
            int index = 0;
            var carArray = new Car[100];
            var carList = Carlist.Where(x => x != null && x.Year == year);

            foreach (var car in carList)
            {
                carArray[index] = car;
                index++;
            }

            return carArray;
        }

        public void ByCar(int id)
        {
            var selectedCar = Carlist.FirstOrDefault(x => x.Id == id);

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
            Carlist.Add(car);
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

            foreach (var car in Carlist)
            {
                if (car != null)
                {
                    UserOutput.ShowListOfCarsMessage(car.Id, car.Model, i);
                }

                i++;
            }
        }
    }
}

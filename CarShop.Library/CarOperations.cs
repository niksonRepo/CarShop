using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Library
{
    public class CarOperations : ICarOperations
    {
        public List<Car> CarList = new();
        
        public void FindAvailableCarsCount()
        {
             var count = CarList.Count(x => x is {IsAvailable: true});
             UserOutput.FindAvailableCarMessage(count);
        }

        public Car[] FindCarByYear(int year)
        {
            return CarList.Where(x => x != null && x.Year == year).ToArray();
        }

        public void ByCar(int id)
        {
            var selectedCar = CarList.FirstOrDefault(x => x.Id == id);

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
            var id = 0;
            var continues = true;

            while (continues)
            {
                CarList.Add(car);

                UserOutput.DoYouWantToAddMoreCarsMessage();

                var yesNo = Console.ReadLine();

                if (yesNo != "Yes")
                {
                    continues = false;
                    UserOutput.ShowMenu();
                }

                id++;
            }
        }

        public void GetCarByYear()
        {
            UserOutput.ProvideYearMessage();
            var year = Convert.ToInt32(Console.ReadLine());
            var carArray = FindCarByYear(year);

            foreach (var car in carArray)
            {
                UserOutput.FoundCarMessage(car.Id, car.Model);
            }
        }

        public void ShowListOfAllCars()
        {
            var i = 0;

            foreach (var car in CarList)
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

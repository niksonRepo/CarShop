using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Library
{
    public class CarOperations: ICarOperations
    {
        //public List<Car> ListOfCars = new List<Car>();
        public Car[] CarArray = new Car[100];

        public void AddCarToTheList(Car car)
        {
            //ListOfCars.Add(car);
            var index = CarArray.Count(x => x != null);
            CarArray[index] = car;
        }

        public int FindAvailableCarsCount()
        {
            return CarArray.Count(x => x != null && x.IsAvailable);
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
            }
        }
        
        public string GetReceipt()
        {
            //create new class with props
            return null;
        }
    }
}

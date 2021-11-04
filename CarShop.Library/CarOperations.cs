using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Library
{
    public class CarOperations: ICarOperations
    {
        private List<Car> ListOfCars = new List<Car>();

        public void AddCarToTheList(Car car)
        {
            ListOfCars.Add(car);
        }

        public int FindAvailableCarsCount()
        {
            return 1;
        }

        public Car FindCar(int year)
        {
            return null;
        }

        public string GetRecipiet()
        {
            return null;
        }
    }
}

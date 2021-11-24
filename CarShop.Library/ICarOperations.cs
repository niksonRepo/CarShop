using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Library
{
    public interface ICarOperations
    {
        void AddCarToTheList(Car car);
        Car[] FindCarByYear(int year);
        void FindAvailableCarsCount();
        string GetReceipt(Car car);
        void ByCar(int id);
        public void GetCarByYear(int year);
    }
}

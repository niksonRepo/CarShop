﻿using System;
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
            var count = CarArray.Count(x => x != null);
            CarArray[count] = car;
        }

        public int FindAvailableCarsCount()
        {
            return 1;
        }

        public Car FindCar(int year)
        {
            return null;
        }
        
        public string GetReceipt()
        {
            return null;
        }
    }
}

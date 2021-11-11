using System;
using System.Collections.Generic;
using System.Linq;
using CarShop.Library;

namespace CarShop.Frontend
{
    class Program
    {
        static readonly CarOperations CarOperator = new();

        static void Main(string[] args)
        {
            UserOutput.ShowMenu();

            var exit = "continue";

            while (exit == "continue")
            {
                var option = Console.ReadLine();

                if (option is "exit")//if(option != null && option == exit)
                {
                    exit = option;
                }

                switch (option)
                {
                    case "1":
                        //Add car to the list
                        var car = CreateCarObject();
                        CarOperator.AddCarToTheList(car);
                        break;
                    case "2":
                        //Find a car by is available
                        CarOperator.FindAvailableCarsCount();
                        break;
                    case "3":
                        //Get cars by year
                        CarOperator.GetCarByYear();
                        break;
                    case "4":
                        //Show list of all presented cars
                        CarOperator.ShowListOfAllCars();
                        break;
                    case "5":
                        //Buying a car
                        UserOutput.ProvideCarIdMessage();
                        var id = Convert.ToInt32(Console.ReadLine());
                        
                        CarOperator.ByCar(id);
                        
                        var receiptData = CarOperator.GetReceipt(CarOperator.CarList.FirstOrDefault(x => x.Id == id));
                        UserOutput.ReceiptMessage(receiptData);

                        break;
                }
            };
        }
        
        public static Car CreateCarObject()
        {
            var car = new Car();
            
            UserOutput.ChooseModelMessage();
            car.Model = Console.ReadLine();

            UserOutput.ChooseModelMessage();
            car.Model = Console.ReadLine();

            UserOutput.ChooseColorMessage();
            car.Color = Console.ReadLine();

            UserOutput.ChooseYearMessage();
            car.Year = Convert.ToInt32(Console.ReadLine());

            return car;
        }
    }
}

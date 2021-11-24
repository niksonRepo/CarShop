using System;
using System.Linq;
using CarShop.Library;

namespace CarShop.Frontend
{
    class Program
    {
        private static readonly CarOperator CarOperator = new();
        private static readonly CarFileOperator CarFileOperator = new();

        static void Main(string[] args)
        {
            try
            {
                MainMethod();
            }
            catch (FormatException exception)
            {
                Console.WriteLine($"Exception message: {exception.Message}");
            }
            catch (NullReferenceException exception)
            {
                Console.WriteLine($"Exception message: {exception.Message}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception message: {exception.Message}");
            }
            finally
            {
                MainMethod();
            }

            Console.ReadLine();
        }

        public static void MainMethod()
        {
            UserOutput.ShowMenu();

            var exit = "continue";

            while (exit == "continue")
            {
                var option = Console.ReadLine();

                if (option is "exit") //if(option != null && option == exit)
                {
                    exit = option;
                }

                switch (option)
                {
                    case "1":
                        //Add car to the list
                        AddingCarsToTheList();
                        break;
                    case "2":
                        //Find a car by is available
                        //CarOperator.FindAvailableCarsCount();
                        CarFileOperator.FindAvailableCarsCount();
                        break;
                    case "3":
                        //Get cars by year
                        UserOutput.ProvideYearMessage();
                        var year = Convert.ToInt32(Console.ReadLine());
                        //CarOperator.GetCarByYear(year);
                        CarFileOperator.FindCarByYear(year);
                        break;
                    case "4":
                        //Show list of all presented cars
                        //CarOperator.ShowListOfAllCars();
                        CarFileOperator.ShowListOfTheCars();
                        break;
                    case "5":
                        //Buying a car
                        UserOutput.ProvideCarIdMessage();
                        var id = Convert.ToInt32(Console.ReadLine());

                        //CarOperator.ByCar(id);
                        CarFileOperator.ByCar(id);
                        var carObject = CarOperator.Carlist.FirstOrDefault(x => x.Id == id);

                        if (carObject != null)
                        {
                            UserOutput.ReceiptMessage(CarOperator.GetReceipt(carObject));
                        }

                        break;
                }
            }
        }

        public static Car CreateCarObject()
        {
            var car = new Car();

            UserOutput.ChooseIdMessage();

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                car.Id = id;
            }
            else
            {
                throw new Exception("Invalid car id");
            }
            
            UserOutput.ChooseModelMessage();
            car.Model = Console.ReadLine();

            UserOutput.ChooseColorMessage();
            car.Color = Console.ReadLine();

            UserOutput.ChooseYearMessage();
            car.Year = Convert.ToInt32(Console.ReadLine());

            return car;
        }

        public static void AddingCarsToTheList()
        {
            var continues = true;

            while (continues)
            {
                var car = CreateCarObject();
                //CarOperator.AddCarToTheList(car);
                
                CarFileOperator.AddCarToFile(car);
                UserOutput.DoYouWantToAddMoreCarsMessage();

                var yesNo = Console.ReadLine();

                if (yesNo == "Yes") continue;

                continues = false;
                UserOutput.ShowMenu();
            }
        }
    }
}

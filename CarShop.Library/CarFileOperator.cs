using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Library
{
    public class CarFileOperator : ICarFileOperations
    {
        private const string RootFolder = @"C:\SchoolFiles";
        private const string FilePath = @"C:\SchoolFiles\CarData.txt";

        public bool CheckIfFileExists()
        {
            return File.Exists(FilePath);
        }

        public bool CheckIfDirectoryExists()
        {
            return Directory.Exists(RootFolder);
        }

        public void IfFileNotExistCreateNewFile(bool exists)
        {
            if (!exists)
            {
                File.Create(FilePath);
            }
        }

        public void IfDirectoryNotExistCreateNewDirectory(bool exists)
        {
            if (!exists)
            {
                File.Create(FilePath);
            }
        }

        public void AddCarToFile(Car car)
        {
            var data = $"{car.Id},{car.Color},{car.Model},{car.Year},{car.IsAvailable},{car.Sold}";
            File.AppendAllText(FilePath, data + Environment.NewLine);
        }

        public void ByCar(int id)
        {
            var carList = GetCarList();
            var selectedCar = carList.FirstOrDefault(x => x.Id == id);

            if (selectedCar != null)
            {
                selectedCar.Sold = true;
            }

            UpdateFile(carList);
        }

        public void FindAvailableCarsCount()
        {
            var carList = GetCarList();
            UserOutput.FindAvailableCarMessage(carList.Count(x => x != null && x.IsAvailable));
        }

        public List<Car> FindCarByYear(int year)
        {
            var carList = GetCarList().Where(x => x.Year == year).ToList();

            foreach (var car in carList)
            {
                UserOutput.FoundCarMessage(car.Id, car.Model);
            }

            return carList;
        }

        public List<Car> ShowListOfTheCars()
        {   
            var i = 0;
            var carList = GetCarList();

            foreach (var car in carList)
            {
                if (car != null)
                {
                    UserOutput.ShowListOfCarsMessage(car.Id, car.Model, i);
                }

                i++;
            }

            return GetCarList();
        }

        private void UpdateFile(List<Car> carList)
        {
            string fileContent = "";

            foreach (var car in carList)
            {
                fileContent += $"{car.Id},{car.Color},{car.Model},{car.Year},{car.IsAvailable},{car.Sold}" + Environment.NewLine;
            }

            File.WriteAllText(FilePath, fileContent);
        }

        private List<Car> GetCarList()
        {
            var carList = new List<Car>();

            foreach (var line in File.ReadLines(FilePath))
            {
                var car = new Car();
                var carItems = line.Split(',');//1,red,audi,2021,True,False

                car.Id = Convert.ToInt32(carItems[0]);
                car.Color = carItems[1];
                car.Model = carItems[2];
                car.Year = Convert.ToInt32(carItems[3]);
                car.IsAvailable = Convert.ToBoolean(carItems[4]);
                car.Sold = Convert.ToBoolean(carItems[5]);

                carList.Add(car);
            }

            return carList;
        }
    }
}

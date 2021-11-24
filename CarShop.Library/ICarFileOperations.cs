using System.Collections.Generic;

namespace CarShop.Library
{
    public interface ICarFileOperations
    {
        bool CheckIfFileExists();
        bool CheckIfDirectoryExists();
        void IfFileNotExistCreateNewFile(bool exists);
        void IfDirectoryNotExistCreateNewDirectory(bool exists);
        void AddCarToFile(Car car);
        List<Car> ShowListOfTheCars();
        List<Car> FindCarByYear(int year);
        void FindAvailableCarsCount();
        void ByCar(int id);
    }
}
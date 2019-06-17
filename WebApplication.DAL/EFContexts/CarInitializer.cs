using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.DAL.Entities;

namespace WebApplication.DAL.EFContexts
{
    public class CarInitializer : DropCreateDatabaseAlways<CarContext>
    {
        protected override void Seed(CarContext db)
        {
            db.Manufacturers.Add(new Manufacturer { Name = "Toyota", Price = 10 });
            db.Manufacturers.Add(new Manufacturer { Name = "Renault", Price = 7 });
            db.Manufacturers.Add(new Manufacturer { Name = "Chevrolet", Price = 8 });
            db.SaveChanges();


            db.QualityClasses.Add(new QualityClass { Name = "A", Price = 10 });
            db.QualityClasses.Add(new QualityClass { Name = "B", Price = 11 });
            db.QualityClasses.Add(new QualityClass { Name = "C", Price = 12 });
            db.QualityClasses.Add(new QualityClass { Name = "D", Price = 13 });
            db.QualityClasses.Add(new QualityClass { Name = "E", Price = 14 });
            db.QualityClasses.Add(new QualityClass { Name = "F", Price = 15 });
            db.QualityClasses.Add(new QualityClass { Name = "J", Price = 16 });
            db.QualityClasses.Add(new QualityClass { Name = "M", Price = 17 });
            db.QualityClasses.Add(new QualityClass { Name = "S", Price = 18 });
            db.SaveChanges();

            db.CarModels.Add(new CarModel
            {
                ManufacturerId = db.Manufacturers.FirstOrDefault(it => it.Name == "Toyota").Id,
                Name = "Tundra",
                Year = 2015,
                AirConditioning = true,
                QualityClassId = db.QualityClasses.FirstOrDefault(it => it.Name == "J").Id,
                PassengerCount = 4,
                DoorCount = 4,
                GearBox = "Автоматическая",
                LargeLuggageCount = 1,
                SmallLuggageCount = 1

            });

            db.CarModels.Add(new CarModel
            {
                ManufacturerId = db.Manufacturers.FirstOrDefault(it => it.Name == "Toyota").Id,
                Name = "Tundra",
                Year = 2016,
                AirConditioning = true,
                QualityClassId = db.QualityClasses.FirstOrDefault(it => it.Name == "J").Id,
                PassengerCount = 4,
                DoorCount = 4,
                GearBox = "Механическая",
                LargeLuggageCount = 1,
                SmallLuggageCount = 1
            });

            db.CarModels.Add(new CarModel
            {
                ManufacturerId = db.Manufacturers.FirstOrDefault(it => it.Name == "Renault").Id,
                Name = "Logan",
                Year = 2015,
                AirConditioning = true,
                QualityClassId = db.QualityClasses.FirstOrDefault(it => it.Name == "J").Id,
                PassengerCount = 4,
                DoorCount = 4,
                GearBox = "Автоматическая",
                LargeLuggageCount = 1,
                SmallLuggageCount = 1
            });

            db.CarModels.Add(new CarModel
            {
                ManufacturerId = db.Manufacturers.FirstOrDefault(it => it.Name == "Renault").Id,
                Name = "Sandero",
                Year = 2015,
                AirConditioning = true,
                QualityClassId = db.QualityClasses.FirstOrDefault(it => it.Name == "J").Id,
                PassengerCount = 4,
                DoorCount = 4,
                GearBox = "Механическая",
                LargeLuggageCount = 1,
                SmallLuggageCount = 1
            });

            db.CarModels.Add(new CarModel
            {
                ManufacturerId = db.Manufacturers.FirstOrDefault(it => it.Name == "Chevrolet").Id,
                Name = "Colorado",
                Year = 2015,
                AirConditioning = true,
                QualityClassId = db.QualityClasses.FirstOrDefault(it => it.Name == "J").Id,
                PassengerCount = 4,
                DoorCount = 5,
                GearBox = "Механическая",
                LargeLuggageCount = 1,
                SmallLuggageCount = 1
            });

            db.CarModels.Add(new CarModel
            {
                ManufacturerId = db.Manufacturers.FirstOrDefault(it => it.Name == "Chevrolet").Id,
                Name = "Camaro",
                Year = 2015,
                AirConditioning = true,
                QualityClassId = db.QualityClasses.FirstOrDefault(it => it.Name == "S").Id,
                PassengerCount = 4,
                DoorCount = 2,
                GearBox = "Механическая",
                LargeLuggageCount = 1,
                SmallLuggageCount = 1
            });

            db.SaveChanges();

            db.Cars.Add(new Car { AvaibleNow = true, CarModelId = db.CarModels.FirstOrDefault(it => it.Name == "Camaro").Id });
            db.Cars.Add(new Car { AvaibleNow = true, CarModelId = db.CarModels.FirstOrDefault(it => it.Name == "Camaro").Id });
            db.Cars.Add(new Car { AvaibleNow = true, CarModelId = db.CarModels.FirstOrDefault(it => it.Name == "Colorado").Id });
            db.Cars.Add(new Car { AvaibleNow = false, CarModelId = db.CarModels.FirstOrDefault(it => it.Name == "Sandero").Id });
            db.Cars.Add(new Car { AvaibleNow = true, CarModelId = db.CarModels.FirstOrDefault(it => it.Name == "Sandero").Id });
            db.Cars.Add(new Car { AvaibleNow = true, CarModelId = db.CarModels.FirstOrDefault(it => it.Name == "Tundra").Id });
            db.Cars.Add(new Car { AvaibleNow = true, CarModelId = db.CarModels.FirstOrDefault(it => it.Name == "Tundra").Id });
            db.Cars.Add(new Car { AvaibleNow = true, CarModelId = db.CarModels.FirstOrDefault(it => it.Name == "Tundra").Id });
            db.Cars.Add(new Car { AvaibleNow = true, CarModelId = db.CarModels.FirstOrDefault(it => it.Name == "Camaro").Id });
            db.Cars.Add(new Car { AvaibleNow = false, CarModelId = db.CarModels.FirstOrDefault(it => it.Name == "Colorado").Id });
            db.SaveChanges();
        }
    }
}

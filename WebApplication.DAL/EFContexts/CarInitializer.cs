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
        public enum EnumGearBoxType
        {
            Автомат = 1,
            Ручная = 2
        }
        protected override void Seed(CarContext db)
        {
            db.ServiceEntities.Add(new ServiceEntity { Name = "Driver", Price = 10 }); ;

            db.RentalCenters.Add(new RentalCenter { City = "Киев" });
            db.RentalCenters.Add(new RentalCenter { City = "Харьков" });
            db.RentalCenters.Add(new RentalCenter { City = "Львов" });

            db.Manufacturers.Add(new Manufacturer { Name = "Toyota", Price = 10 });
            db.Manufacturers.Add(new Manufacturer { Name = "Renault", Price = 7 });
            db.Manufacturers.Add(new Manufacturer { Name = "Chevrolet", Price = 8 });
            db.SaveChanges();


            db.QualityClasses.Add(new QualityClass { Name = "A", Price = 10, Photo = "/Content/StandartCars/A.jpg", Description = "Компактные автомбили" });
            db.QualityClasses.Add(new QualityClass { Name = "B", Price = 11, Photo = "/Content/StandartCars/B.jpg", Description = "Малогабаритные" });
            db.QualityClasses.Add(new QualityClass { Name = "C", Price = 12, Photo = "/Content/StandartCars/C.jpg", Description = "Средний класс (нижний)" });
            db.QualityClasses.Add(new QualityClass { Name = "D", Price = 13, Photo = "/Content/StandartCars/D.jpg", Description = "Семейный седан" });
            db.QualityClasses.Add(new QualityClass { Name = "E", Price = 14, Photo = "/Content/StandartCars/E.jpg", Description = "Средний класс (верхний)" });
            db.QualityClasses.Add(new QualityClass { Name = "F", Price = 15, Photo = "/Content/StandartCars/F.jpg", Description = "Представительский" });
            db.QualityClasses.Add(new QualityClass { Name = "J", Price = 16, Photo = "/Content/StandartCars/J.jpg", Description = "Внедорожники" });
            db.QualityClasses.Add(new QualityClass { Name = "M", Price = 17, Photo = "/Content/StandartCars/M.jpg", Description = "Мультифункциональные" });
            db.QualityClasses.Add(new QualityClass { Name = "S", Price = 18, Photo = "/Content/StandartCars/S.jpg", Description = "Купе" });
            db.SaveChanges();

            db.CarModels.Add(new CarModel
            {
                ManufacturerId = db.Manufacturers.FirstOrDefault(it => it.Name == "Toyota").Id,
                Name = "Tundra",
                AirConditioning = true,
                QualityClassId = db.QualityClasses.FirstOrDefault(it => it.Name == "J").Id,
                PassengerCount = 4,
                DoorCount = 4,
                GearBox = Enum.GetName(typeof(EnumGearBoxType), 1).ToString(),
                LargeLuggageCount = 1,
                SmallLuggageCount = 1,
                Photo = "/Content/StandartCars/A.jpg"

            });
            db.CarModels.Add(new CarModel
            {
                ManufacturerId = db.Manufacturers.FirstOrDefault(it => it.Name == "Chevrolet").Id,
                Name = "Undra",
                AirConditioning = true,
                QualityClassId = db.QualityClasses.FirstOrDefault(it => it.Name == "A").Id,
                PassengerCount = 4,
                DoorCount = 4,
                GearBox = Enum.GetName(typeof(EnumGearBoxType), 2).ToString(),
                LargeLuggageCount = 1,
                SmallLuggageCount = 1,
                Photo = "/Content/StandartCars/A.jpg"

            });

            //db.CarModels.Add(new CarModel
            //{
            //    ManufacturerId = db.Manufacturers.FirstOrDefault(it => it.Name == "Toyota").Id,
            //    Name = "Tundra",
            //    Year = 2016,
            //    AirConditioning = true,
            //    QualityClassId = db.QualityClasses.FirstOrDefault(it => it.Name == "J").Id,
            //    PassengerCount = 4,
            //    DoorCount = 4,
            //    GearBox = "Механическая",
            //    LargeLuggageCount = 1,
            //    SmallLuggageCount = 1
            //});

            //db.CarModels.Add(new CarModel
            //{
            //    ManufacturerId = db.Manufacturers.FirstOrDefault(it => it.Name == "Renault").Id,
            //    Name = "Logan",
            //    Year = 2015,
            //    AirConditioning = true,
            //    QualityClassId = db.QualityClasses.FirstOrDefault(it => it.Name == "J").Id,
            //    PassengerCount = 4,
            //    DoorCount = 4,
            //    GearBox = "Автоматическая",
            //    LargeLuggageCount = 1,
            //    SmallLuggageCount = 1
            //});

            //db.CarModels.Add(new CarModel
            //{
            //    ManufacturerId = db.Manufacturers.FirstOrDefault(it => it.Name == "Renault").Id,
            //    Name = "Sandero",
            //    Year = 2015,
            //    AirConditioning = true,
            //    QualityClassId = db.QualityClasses.FirstOrDefault(it => it.Name == "J").Id,
            //    PassengerCount = 4,
            //    DoorCount = 4,
            //    GearBox = "Механическая",
            //    LargeLuggageCount = 1,
            //    SmallLuggageCount = 1
            //});

            //db.CarModels.Add(new CarModel
            //{
            //    ManufacturerId = db.Manufacturers.FirstOrDefault(it => it.Name == "Chevrolet").Id,
            //    Name = "Colorado",
            //    Year = 2015,
            //    AirConditioning = true,
            //    QualityClassId = db.QualityClasses.FirstOrDefault(it => it.Name == "J").Id,
            //    PassengerCount = 4,
            //    DoorCount = 5,
            //    GearBox = "Механическая",
            //    LargeLuggageCount = 1,
            //    SmallLuggageCount = 1
            //});

            //db.CarModels.Add(new CarModel
            //{
            //    ManufacturerId = db.Manufacturers.FirstOrDefault(it => it.Name == "Chevrolet").Id,
            //    Name = "Camaro",
            //    Year = 2015,
            //    AirConditioning = true,
            //    QualityClassId = db.QualityClasses.FirstOrDefault(it => it.Name == "S").Id,
            //    PassengerCount = 4,
            //    DoorCount = 2,
            //    GearBox = "Механическая",
            //    LargeLuggageCount = 1,
            //    SmallLuggageCount = 1
            //});

            db.SaveChanges();

            //db.Cars.Add(new Car { CarModelId = db.CarModels.FirstOrDefault(it => it.Name == "Camaro").Id, RentalCenterId = db.RentalCenters.FirstOrDefault(it => it.City == "Киев").Id });
            //db.Cars.Add(new Car { CarModelId = db.CarModels.FirstOrDefault(it => it.Name == "Camaro").Id, RentalCenterId = db.RentalCenters.FirstOrDefault(it => it.City == "Киев").Id });
            //db.Cars.Add(new Car { CarModelId = db.CarModels.FirstOrDefault(it => it.Name == "Colorado").Id, RentalCenterId = db.RentalCenters.FirstOrDefault(it => it.City == "Киев").Id });
            //db.Cars.Add(new Car { CarModelId = db.CarModels.FirstOrDefault(it => it.Name == "Sandero").Id, RentalCenterId = db.RentalCenters.FirstOrDefault(it => it.City == "Киев").Id });
            //db.Cars.Add(new Car { CarModelId = db.CarModels.FirstOrDefault(it => it.Name == "Sandero").Id, RentalCenterId = db.RentalCenters.FirstOrDefault(it => it.City == "Киев").Id });
            //db.Cars.Add(new Car { CarModelId = db.CarModels.FirstOrDefault(it => it.Name == "Tundra").Id, RentalCenterId = db.RentalCenters.FirstOrDefault(it => it.City == "Киев").Id });
            //db.Cars.Add(new Car { CarModelId = db.CarModels.FirstOrDefault(it => it.Name == "Tundra").Id, RentalCenterId = db.RentalCenters.FirstOrDefault(it => it.City == "Киев").Id });
            //db.Cars.Add(new Car { CarModelId = db.CarModels.FirstOrDefault(it => it.Name == "Tundra").Id, RentalCenterId = db.RentalCenters.FirstOrDefault(it => it.City == "Киев").Id });
            //db.Cars.Add(new Car { CarModelId = db.CarModels.FirstOrDefault(it => it.Name == "Camaro").Id, RentalCenterId = db.RentalCenters.FirstOrDefault(it => it.City == "Киев").Id });
            //db.Cars.Add(new Car { CarModelId = db.CarModels.FirstOrDefault(it => it.Name == "Colorado").Id, RentalCenterId = db.RentalCenters.FirstOrDefault(it => it.City == "Киев").Id });
            //db.SaveChanges();
        }
    }
}

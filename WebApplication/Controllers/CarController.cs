using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.BLL.DataTransferObjects;
using WebApplication.BLL.Interfaces;
using WebApplication.Models;
using WebApplication.Models.ViewModels;

namespace WebApplication.Controllers
{
    public class CarController : Controller
    {
        readonly ICarService _carService;
        readonly ICarModelService _carModelService;
        public CarController(ICarService carService, ICarModelService carModelService)
        {
            _carService = carService;
            _carModelService = carModelService;
        }
        // GET: Car
        public ActionResult CarList()
        {
            //var currentUserId = User.Identity.GetUserName();
            IEnumerable<CarDTO> carsDTOs = _carService.GetCars();
            List<CarModelDTO> modelDTOs = new List<CarModelDTO>();
            foreach (var it in carsDTOs)
            {
                modelDTOs.Add(_carModelService.GetCarModel(it.CarModelId));
            }

            return View(modelDTOs);
        }

        // GET: Car/Details/5
        public ActionResult Details(int id)
        {
            var car = _carModelService.GetCarModel(id);
            return View(car);
        }
        // GET: Car/Create
        public ActionResult Create()
        {
            //ViewBag.Manufacturers = _carService.GetManufacturers().ToList();
            //ViewBag.CarModels = _carService.GetCarModels().ToList();

            return View();
        }

        // POST: Car/Create
       

      

        public ActionResult CreateCar()
        {
            var ModelsNames = new List<string>();
            foreach (var it in _carModelService.GetCarModels())
            {
                ModelsNames.Add(it.Name);
            }
            ViewBag.CarModel = ModelsNames;
            return View(new CreateCarViewModel());
        }

        [HttpPost]
        public ActionResult CreateCar(CreateCarViewModel item)
        {
            var model = _carModelService.GetCarModels().ToList().FirstOrDefault(it => it.Name == item.ModelName);
            var carDto = new CarDTO { AvaibleNow = true, CarModelId = model.Id };
            _carService.CreateCar(carDto);
            return RedirectToAction("CreateCar");
        }

        // GET: Car/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Car/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Car/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Car/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}

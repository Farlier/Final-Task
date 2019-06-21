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
using WebApplication.Models.FilterModels;
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
     
        // GET: Car/Details/5
        public ActionResult Details(int id)
        {
            var mapper = new MapperConfiguration(cg => cg.CreateMap<CarModelDTO, CarModelView>()).CreateMapper();
            var modelView = mapper.Map<CarModelDTO, CarModelView>(_carModelService.GetCarModel(id));

            return View(modelView);
        }

        // POST: Car/Create
        public ActionResult CreateCar()
        {
            var ModelsNames = new List<string>();
            foreach (var it in _carModelService.GetCarModels())
            {
                ModelsNames.Add(it.Name);
            }

            return View(new CreateCarViewModel { ValidModels = ModelsNames });
        }

        [HttpPost]
        public ActionResult CreateCar(CreateCarViewModel item)
        {
            var model = _carModelService.GetCarModels().ToList().FirstOrDefault(it => it.Name == item.ModelName);
            if (model == null)
                ModelState.AddModelError("ModelName", "Выберите модель авто!");
            if (ModelState.IsValid)
            {
                var carDto = new CarDTO { CarModelId = model.Id, RentalCenterId = 1 };

                _carService.CreateCar(carDto);
            }

            var ModelsNames = new List<string>();
            foreach (var it in _carModelService.GetCarModels())
            {
                ModelsNames.Add(it.Name);
            }
            ViewBag.CarModel = ModelsNames;
            return RedirectToAction("CreateCar");
        }

        [HttpPost]
        public ActionResult GetConfig(string City)
        {

            return View("Index");
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
        [HttpPost]
        public ActionResult UploadPhoto(HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                // сохраняем файл в папку Files в проекте
                upload.SaveAs(Server.MapPath("~/Content/Cars/" + fileName));
                System.Drawing.Image img = System.Drawing.Image.FromFile("~/Content/Cars/filename");
                if (img.Width != 320 || img.Height != 240)
                    throw new Exception("Размеры изображения!!");
                System.IO.File.Delete("~/Content/Cars/filename");
            }
            return RedirectToAction("CarList");
        }
    }
}

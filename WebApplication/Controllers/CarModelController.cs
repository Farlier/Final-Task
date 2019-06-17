using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.BLL.DataTransferObjects;
using WebApplication.BLL.Interfaces;
using WebApplication.Models.ViewModels;

namespace WebApplication.Controllers
{
    public class CarModelController : Controller
    {
        readonly ICarModelService _carModelService;
        readonly IManufacturerService _manufacturerService;
        readonly IQualityClassService _qualityService;

        public CarModelController(ICarModelService carModelService, IManufacturerService manufacturerService, IQualityClassService qualityClassService)
        {
            _carModelService = carModelService;
            _manufacturerService = manufacturerService;
            _qualityService = qualityClassService;
        }
        // GET: CarModel
        public ActionResult Index()
        {
            return View();
        }

        // GET: CarModel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarModel/Create
        public ActionResult CreateCarModel()
        {
            var Manufacturers = new List<string>();
            foreach (var it in _manufacturerService.GetManufacturers().ToList())
            {
                Manufacturers.Add(it.Name);
            }

            var QC = new List<string>();
            foreach (var it in _qualityService.GetQualityClasses().ToList())
            {
                QC.Add(it.Name);
            }
            ViewBag.QualityC = QC;
            ViewBag.Manufacturers = Manufacturers;
            return View(new CreateCarModelViewModel());
        }

        [HttpPost]
        public ActionResult CreateCarModel(CreateCarModelViewModel item)
        {
            var mapper = new MapperConfiguration(cg => cg.CreateMap<CreateCarModelViewModel, CarModelDTO>()).CreateMapper();
            var model = mapper.Map<CreateCarModelViewModel,CarModelDTO>(item);

            int? manufacturerId= _manufacturerService.GetManufacturers().ToList().Find(it => it.Name == item.ManufacturerName).Id;
            if (manufacturerId != null)
                model.ManufacturerId = manufacturerId.Value;

            int? qualityId = _qualityService.GetQualityClasses().ToList().Find(it => it.Name == item.QualityClassName).Id;
            if (qualityId != null)
                model.QualityClassId = qualityId.Value;

            _carModelService.CreateCarModel(model);
            return RedirectToAction("CreateCarModel");
        }

        // GET: CarModel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CarModel/Edit/5
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

        // GET: CarModel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CarModel/Delete/5
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

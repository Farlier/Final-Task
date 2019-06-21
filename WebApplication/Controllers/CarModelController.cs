using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using WebApplication.BLL.DataTransferObjects;
using WebApplication.BLL.Interfaces;
using WebApplication.Models.FilterModels;
using WebApplication.Models.ViewModels;

namespace WebApplication.Controllers
{
    public class CarModelController : Controller
    {
        readonly ICarService _carService;
        readonly ICarModelService _carModelService;
        readonly IManufacturerService _manufacturerService;
        readonly IQualityClassService _qualityClassService;

        public CarModelController(
            ICarModelService carModelService, 
            IManufacturerService manufacturerService, 
            IQualityClassService qualityClassService,
            ICarService carService)
        {
            _carModelService = carModelService;
            _manufacturerService = manufacturerService;
            _qualityClassService = qualityClassService;
            _carService = carService;
        }

        // GET: CarModel
        public ActionResult CarModelList(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";
            var mapper = new MapperConfiguration(cg => cg.CreateMap<CarModelDTO, CarModelView>()).CreateMapper();
            var modelView = mapper.Map<List<CarModelDTO>, List<CarModelView>>(_carModelService.GetCarModels().ToList());

            for(int i=0;i<modelView.Count;i++)
            {
                modelView[i].Count = GetCountAuto(modelView[i].Id);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    modelView = modelView.OrderByDescending(s => s.Name).ToList();
                    break;
                case "Price":
                    modelView = modelView.OrderBy(s => s.Price).ToList();
                    break;
                case "price_desc":
                    modelView = modelView.OrderByDescending(s => s.Price).ToList();
                    break;
                default:
                    modelView = modelView.OrderBy(s => s.Name).ToList();
                    break;
            }
            return View(modelView);
        }

        public ActionResult SelectionResult(string sortOrder, string manufacturer, string qualityClass)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";
            ViewBag.Manufacturer = manufacturer;
            ViewBag.QualityClass = qualityClass;

            List<CarModelDTO> modelDTOs = new List<CarModelDTO>();                    

            if (manufacturer != null)
            {
                var manufacturerObj = _manufacturerService.GetManufacturers().FirstOrDefault(it => it.Name == manufacturer);
                modelDTOs = _carModelService.GetCarModels().Where(it => it.ManufacturerId == manufacturerObj.Id).ToList();
            }

            if (qualityClass != null)
            {
                var qualityClassObj = _qualityClassService.GetQualityClasses().FirstOrDefault(it => it.Name == qualityClass);
                modelDTOs = _carModelService.GetCarModels().Where(it => it.QualityClassId == qualityClassObj.Id).ToList();
            }

            var mapper = new MapperConfiguration(cg => cg.CreateMap<CarModelDTO, CarModelView>()).CreateMapper();
            var modelView = mapper.Map<List<CarModelDTO>, List<CarModelView>>(modelDTOs);

            for (int i = 0; i < modelView.Count; i++)
            {
                modelView[i].Count = GetCountAuto(modelView[i].Id);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    modelView = modelView.OrderByDescending(s => s.Name).ToList();
                    break;
                case "Price":
                    modelView = modelView.OrderBy(s => s.Price).ToList();
                    break;
                case "price_desc":
                    modelView = modelView.OrderByDescending(s => s.Price).ToList();
                    break;
                default:
                    modelView = modelView.OrderBy(s => s.Name).ToList();
                    break;
            }
            return View(modelView);
        }

        [HttpGet]
        public ActionResult Filter()
        {
            List<ManufacturerFilter> manufacturerFiltersl = new List<ManufacturerFilter>();
            List<QualityClassFilter> qualityClassFiltersl = new List<QualityClassFilter>();

            foreach (var it in _manufacturerService.GetManufacturers().ToList())
            {
                manufacturerFiltersl.Add(new ManufacturerFilter { Checked = false, ManufacturerName = it.Name });
            }

            foreach (var it in _qualityClassService.GetQualityClasses().ToList())
            {
                qualityClassFiltersl.Add(new QualityClassFilter { Checked = false, QualityClassName = it.Name });
            }

            return PartialView("FilterPartial", new FilterViewModel { manufacturerFilters = manufacturerFiltersl, qualityClassFilters = qualityClassFiltersl });
        }

        // GET: CarModel/Details/5
        public ActionResult Details(int id)
        {
            var mapper = new MapperConfiguration(cg => cg.CreateMap<CarModelDTO, CarModelView>()).CreateMapper();
            var modelView = mapper.Map<CarModelDTO, CarModelView>(_carModelService.GetCarModel(id));
            return View(modelView);
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
            foreach (var it in _qualityClassService.GetQualityClasses().ToList())
            {
                QC.Add(it.Name);
            }

            return View(new CreateCarModelViewModel { ManufacturersView = Manufacturers, QualityClassesView = QC });
        }

        [HttpPost]
        public ActionResult CreateCarModel(CreateCarModelViewModel item)
        {
            string fileName = string.Empty;

            if (Request.Files.Count > 0)
            {
                foreach (string it in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[it];
                    string fname = System.IO.Path.GetFileName(file.FileName);
                    string extension = System.IO.Path.GetExtension(file.FileName);
                    if (fname != string.Empty && extension != string.Empty)
                    {
                        fileName = "/Content/Cars/" + item.Name + extension;
                        fileName = Regex.Replace(fileName, @"\s", "_");
                        file.SaveAs(Server.MapPath(fileName));
                    }
                    else
                        fileName = "/Content/Cars/No_image.jpg";
                }


            }

            var mapper = new MapperConfiguration(cg => cg.CreateMap<CreateCarModelViewModel, CarModelDTO>()).CreateMapper();
            var model = mapper.Map<CreateCarModelViewModel, CarModelDTO>(item);

            int? manufacturerId = _manufacturerService.GetManufacturers().ToList().Find(it => it.Name == item.ManufacturerName).Id;
            if (manufacturerId != null)
                model.ManufacturerId = manufacturerId.Value;

            int? qualityId = _qualityClassService.GetQualityClasses().ToList().Find(it => it.Name == item.QualityClassName).Id;
            if (qualityId != null)
                model.QualityClassId = qualityId.Value;
            model.Photo = fileName;
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

        public int GetCountAuto(int id)
        {
            return _carService.GetAvaibleCars().Where(it => it.CarModelId == id).Count();
        }
    }
}

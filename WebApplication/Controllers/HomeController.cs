using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.BLL.Interfaces;
using AutoMapper;
using WebApplication.BLL.DataTransferObjects;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        IQualityClassService _qualityClassService;
        public HomeController(IQualityClassService qualityClassService)
        {
            _qualityClassService = qualityClassService;
        }
        public ActionResult Index()
        {
            var mapper = new MapperConfiguration(cg => cg.CreateMap<QualityClassDTO, QualityClassViewModel>()).CreateMapper();
            var models = mapper.Map<IEnumerable<QualityClassDTO>, List<QualityClassViewModel>>(_qualityClassService.GetQualityClasses());
            return View(models);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       

        public ActionResult Create()
        {
            //ViewBag.Manufacturers = _carService.GetManufacturers().ToList();
            //ViewBag.CarModels = _carService.GetCarModels().ToList();

            return View();
        }

    }
}
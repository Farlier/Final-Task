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
    public class ManufacturerController : Controller
    {
        readonly IManufacturerService _manufacturerService;
        public ManufacturerController(IManufacturerService carService)
        {
            _manufacturerService = carService;
        }
        // GET: Manufacturer
        public ActionResult ManufacturerList()
        {
            return View();
        }

        // GET: Manufacturer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Manufacturer/Create
        [HttpPost]
        public ActionResult CreateManufacturer(CreateManufacturerViewModel item)
        {
            var mapper = new MapperConfiguration(cg => cg.CreateMap<CreateManufacturerViewModel, ManufacturerDTO>()).CreateMapper();
            var mrDto = mapper.Map<CreateManufacturerViewModel, ManufacturerDTO>(item);
            _manufacturerService.CreateManufacturer(mrDto);
            return RedirectToAction("CreateManufacturer");
        }

        public ActionResult CreateManufacturer()
        {

            return View(new CreateManufacturerViewModel());
        }

        // GET: Manufacturer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Manufacturer/Edit/5
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

        // GET: Manufacturer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Manufacturer/Delete/5
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

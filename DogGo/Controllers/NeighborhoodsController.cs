using DogGo.Models;
using DogGo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogGo.Controllers
{
    
    
    public class NeighborhoodsController : Controller
    {
        ////////// Starter //////////
        private readonly NeighborhoodRepository _neighborhoodRepo;

        // The constructor accepts an IConfiguration object as a parameter. This class comes from the ASP.NET framework and is useful for retrieving things out of the appsettings.json file like connection strings.
        public NeighborhoodsController(IConfiguration config)
        {
            _neighborhoodRepo = new NeighborhoodRepository(config);
        }

        ////////// End Starter //////////
        ///
        // GET: NeighborhoodsController
        public ActionResult Index()
        {
            List<Neighborhood> neighborhoods = _neighborhoodRepo.GetAll();
            return View(neighborhoods);
        }

        // GET: NeighborhoodsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NeighborhoodsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NeighborhoodsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NeighborhoodsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NeighborhoodsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NeighborhoodsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NeighborhoodsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

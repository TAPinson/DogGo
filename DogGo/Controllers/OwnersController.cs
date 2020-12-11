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
    public class OwnersController : Controller
    {
        private readonly OwnerRepository _ownerRepo;

        // The constructor accepts an IConfiguration object as a parameter. This class comes from the ASP.NET framework and is useful for retrieving things out of the appsettings.json file like connection strings.
        public OwnersController(IConfiguration config)
        {
            _ownerRepo = new OwnerRepository(config);
        }

        // GET: OwnersController1
        public ActionResult Index()
        {
            List<Owner> owners = _ownerRepo.GetAllOwners();
            return View(owners);
        }

        // GET: OwnersController1/Details/5
        public ActionResult Details(int id)
        {
            Owner owner = _ownerRepo.GetOwnerById(id);

            if (owner == null)
            {
                return NotFound();
            }

            return View(owner);
        }

        // GET: OwnersController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OwnersController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Owner owner)
        {
            try
            {
                _ownerRepo.AddOwner(owner);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(owner);
            }
        }

        // GET: OwnersController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OwnersController1/Edit/5
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

        // GET: OwnersController1/Delete/5
        public ActionResult Delete(int id)
        {
            Owner owner = _ownerRepo.GetOwnerById(id);
            return View(owner);
        }

        // POST: OwnersController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Owner owner)
        {
            try
            {
                _ownerRepo.DeleteOwner(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(owner);
            }
        }
    }
}

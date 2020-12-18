using Doggo.Repositories;
using DogGo.Models;
using DogGo.Models.ViewModels;
using DogGo.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DogGo.Controllers
{
    [Authorize]
    public class DogsController : Controller
    {
        ////////// Starter //////////
        //private readonly DogRepository _dogRepo;
        private IDogRepository _dogRepo;
        private IOwnerRepository _ownerRepo;

        // The constructor accepts an IConfiguration object as a parameter. This class comes from the ASP.NET framework and is useful for retrieving things out of the appsettings.json file like connection strings.
        public DogsController(IDogRepository dogRepo, IOwnerRepository ownerRepo)
        {
            _dogRepo = dogRepo;
            _ownerRepo = ownerRepo;
        }

        ////////// End Starter //////////


        // GET: DogsController
        
        public ActionResult Index()
        {
            int ownerId = GetCurrentUserId();
            Owner owner = _ownerRepo.GetOwnerById(ownerId);
            List<Dog> dogs = _dogRepo.GetDogsByOwnerId(ownerId);

            foreach (Dog dog in dogs)
            {
                dog.Owner = owner;
            }

            return View(dogs);
        }

        // GET: DogsController/Details/5
        public ActionResult Details(int id)
        {
            Dog dog = _dogRepo.GetDogById(id);

            Owner owner = _ownerRepo.GetOwnerById(dog.OwnerId);

            dog.Owner = owner;

            if (dog == null)
            {
                return NotFound();
            }

            DogProfileViewModel vm = new DogProfileViewModel()
            {
                dog = dog
            };
            return View(vm);
        }

        // GET: DogsController/Create
        
        public ActionResult Create()
        {
            return View();
        }

        // POST: DogsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dog dog)
        {
            try
            {
                dog.OwnerId = GetCurrentUserId();
                _dogRepo.AddDog(dog);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(dog);
            }
        }


        // GET: DogsController/Edit/5
        
        public ActionResult Edit(int id)
        {
            Dog dog = _dogRepo.GetDogById(id);

            if (dog == null)
            {
                return NotFound();
            }

            if (dog.OwnerId != GetCurrentUserId())
            {
                return NotFound();
            }

            return View(dog);
        }

        // POST: DogsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]        
        public ActionResult Edit(int id, Dog dog)
        {
            try
            {
                dog.OwnerId = GetCurrentUserId();

                _dogRepo.UpdateDog(dog);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(dog);
            }
        }

        // GET: DogsController/Delete/5
        public ActionResult Delete(int id)
        {
            Dog dog = _dogRepo.GetDogById(id);

            if (dog.OwnerId != GetCurrentUserId())
            {
                return NotFound();
            }

            return View(dog);
        }

        // POST: DogsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Dog dog)
        {
            try
            {
                _dogRepo.DeleteDog(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(dog);
            }
        }
        
        private int GetCurrentUserId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }
    }
}

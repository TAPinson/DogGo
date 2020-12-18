using Doggo.Repositories;
using DogGo.Models;
using DogGo.Models.ViewModels;
using DogGo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace DogGo.Controllers
{
    public class WalkersController : Controller
    {
        ///// Starter /////
        private IWalkerRepository _walkerRepo;
        private INeighborhoodRepository _neighborhoodRepo;
        private IWalkRepository _walkRepo;
        private IOwnerRepository _ownerRepo;

        // The constructor accepts an IConfiguration object as a parameter. This class comes from the ASP.NET framework and is useful for retrieving things out of the appsettings.json file like connection strings.
        public WalkersController(IWalkerRepository walkerRepo, INeighborhoodRepository neighborhoodRepo, IWalkRepository walkRepo, IOwnerRepository ownerRepo)
        {
            _walkerRepo = walkerRepo;
            _neighborhoodRepo = neighborhoodRepo;
            _walkRepo = walkRepo;
            _ownerRepo = ownerRepo;
        }
        ///// End Starter /////

        // GET: WalkersController
        public ActionResult Index()
        {
            try
            {
                int loggedInUser = GetCurrentUserId();
                Owner thisUser = _ownerRepo.GetOwnerById(loggedInUser);
                List<Walker> walkers = _walkerRepo.GetWalkersInNeighborhood(thisUser.NeighborhoodId);
                return View(walkers);
            }
            catch
            {
                List<Walker> walkers = _walkerRepo.GetAllWalkers();
                return View(walkers);
            }            
        }

        // GET: WalkersController/Details/5
        public ActionResult Details(int id)
        {
            Walker walker = _walkerRepo.GetWalkerById(id);
            Neighborhood neighborhood = _neighborhoodRepo.GetNeighborhoodById(walker.NeighborhoodId);
            walker.Neighborhood = neighborhood;
            List<Walk> walks = _walkRepo.GetWalkerViewWalks(id);
            if (walker == null)
            {
                return NotFound();
            }
            ProfileViewModel vm = new ProfileViewModel()
            {
                Walker = walker,
                Walks = walks
            };
            return View(vm);
        }

        // GET: WalkersController/Create
        public ActionResult Create()
        {
            List<Neighborhood> neighborhoods = _neighborhoodRepo.GetAll();
            WalkerFormViewModel vm = new WalkerFormViewModel()
            {
                Walker = new Walker(),
                Neighborhoods = neighborhoods
            };          
            return View(vm);
        }

        // POST: WalkersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Walker walker)
        {
            try
            {
                _walkerRepo.AddWalker(walker);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WalkersController/Edit/5
        public ActionResult Edit(int id)
        {
            Walker walker = _walkerRepo.GetWalkerById(id);

            List<Neighborhood> neighborhoods = _neighborhoodRepo.GetAll();

            WalkerEditViewModel vm = new WalkerEditViewModel()
            {
                Walker = walker,
                Neighborhoods = neighborhoods
            };

            return View(vm);
        }

        // POST: WalkersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Walker walker)
        {
            try
            {
                // Create Edit Walker method to finish this
                _walkerRepo.UpdateWalker(walker);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(walker) ;
            }
        }

        // GET: WalkersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WalkersController/Delete/5
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

        private int GetCurrentUserId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }
    }
}

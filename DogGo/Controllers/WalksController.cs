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
    public class WalksController : Controller
    {
        ///// Starter /////
        private IWalkRepository _walkRepo;
        private IWalkerRepository _walkerRepo;
        private IOwnerRepository _ownerRepo;
        private IDogRepository _dogRepo;
        private IWalkStatusRepository _walkStatusRepo;
        

        // The constructor accepts an IConfiguration object as a parameter. This class comes from the ASP.NET framework and is useful for retrieving things out of the appsettings.json file like connection strings.
        public WalksController(IWalkRepository walkRepo, IWalkerRepository walkerRepo, IOwnerRepository ownerRepo, IDogRepository dogRepo, IWalkStatusRepository walkStatusRepo)
        {
            _walkRepo = walkRepo;
            _walkerRepo = walkerRepo;
            _ownerRepo = ownerRepo;
            _dogRepo = dogRepo;
            _walkStatusRepo = walkStatusRepo;
        }
        ///// End Starter /////
        
        // GET: WalksController
        public ActionResult Index()
        {
            List<Walk> walks = _walkRepo.GetAllWalks();
            return View(walks);
        }

        // GET: WalksController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WalksController/Create
        public ActionResult Create()
        {
            int currentUserId = GetCurrentUserId();
            Owner thisOwner = _ownerRepo.GetOwnerById(currentUserId);

            Walk walk = new Walk();

            WalkFormViewModel vm = new WalkFormViewModel()
            {
                Walkers = _walkerRepo.GetWalkersInNeighborhood(thisOwner.NeighborhoodId),
                Dogs = _dogRepo.GetDogsByOwnerId(thisOwner.Id),
                WalkStatuses = _walkStatusRepo.GetWalkStatuses(),
                Walk = walk
            };

            return View(vm);
        }

        // POST: WalksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Walk walk)
        {
            try
            {
                _walkRepo.AddWalk(walk);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(walk);
            }
        }

        // GET: WalksController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WalksController/Edit/5
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

        // GET: WalksController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WalksController/Delete/5
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

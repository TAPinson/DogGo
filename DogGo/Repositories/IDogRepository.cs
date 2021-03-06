﻿using DogGo.Models;
using System.Collections.Generic;

namespace Doggo.Repositories
{
    public interface IDogRepository
    {
        Dog GetDogById(int id);
        List<Dog> GetAllDogs();
        List<Dog> GetDogsByOwnerId(int ownerId);

        public void AddDog(Dog dog);

        public void UpdateDog(Dog dog);

        public void DeleteDog(int id);
    }
}
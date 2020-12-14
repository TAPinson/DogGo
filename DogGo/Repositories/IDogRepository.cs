using DogGo.Models;
using System.Collections.Generic;

namespace Doggo.Repositories
{
    public interface IDogRepository
    {
        Dog GetDogById(int id);
        List<Dog> GetAllDogs();
        List<Dog> GetDogsByOwnerId(int ownerId);
    }
}
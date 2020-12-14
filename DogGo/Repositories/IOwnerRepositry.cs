using DogGo.Models;
using System.Collections.Generic;

namespace Doggo.Repositories
{
    public interface IOwnerRepository
    {
        Owner GetOwnerById(int id);
        List<Owner> GetAllOwners();
        void UpdateOwner(Owner owner);
        void DeleteOwner(int ownerId);
        void AddOwner(Owner owner);
        Owner GetOwnerByEmail(string email);

    }
}
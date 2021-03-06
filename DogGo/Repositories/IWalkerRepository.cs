﻿using DogGo.Models;
using System.Collections.Generic;

namespace Doggo.Repositories
{
    public interface IWalkerRepository
    {
        List<Walker> GetAllWalkers();
        Walker GetWalkerById(int id);
        List<Walker> GetWalkersInNeighborhood(int neighborhoodId);
        void AddWalker(Walker walker);
        void UpdateWalker(Walker walker);
    }
}
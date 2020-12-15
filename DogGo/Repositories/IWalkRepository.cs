﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogGo.Models;

namespace DogGo.Repositories
{
    public interface IWalkRepository
    {
        List<Walk> GetAllWalks();

        List<Walk> GetByWalker(int id);

        List<Walk> GetWalkerViewWalks(int id);
    }
}

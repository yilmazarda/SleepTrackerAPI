using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeAPI.Data;
using sleep_tracker_api.models;

namespace sleep_tracker_api.Data
{
    public interface ISleepRepository : IRepository<Sleep>
    {
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeAPI.Data;
using sleep_tracker_api.models;

namespace sleep_tracker_api.Data
{
    public class SleepRepository : Repository<Sleep>,ISleepRepository
    {
        public SleepRepository(SleepContext sleepContext) : base(sleepContext)
        {
            
        }
    }
}
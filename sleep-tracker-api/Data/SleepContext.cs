using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sleep_tracker_api.models;

namespace sleep_tracker_api.Data
{
    public class SleepContext : DbContext
    {
        public SleepContext(DbContextOptions<SleepContext> options): base(options)
        {
            
        }
        public DbSet<Sleep> Sleeps {get; set;}
    }
}
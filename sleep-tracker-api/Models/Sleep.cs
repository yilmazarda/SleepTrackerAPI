using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sleep_tracker_api.models
{
    public class Sleep
    {
        [Key]
        public int Id { get; set;}

        [Required]
        public DateTime SleepStart { get; set;}

        [Required]
        public DateTime SleepEnd { get; set;}
        
        public TimeSpan SleepDuration => SleepEnd.Subtract(SleepStart);

        
    }
}
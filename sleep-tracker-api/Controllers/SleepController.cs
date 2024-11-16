using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sleep_tracker_api.Data;
using sleep_tracker_api.models;

namespace sleep_tracker_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SleepController : ControllerBase
    {
        private readonly ISleepRepository _repository;

        public SleepController(ISleepRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sleep>>> GetSleepRecords() {
            var sleep = await _repository.GetAllAsync();
            return Ok(sleep);
        }   

        [HttpGet("{id}")]
        public async Task<ActionResult<Sleep>> GetSleepById(int id) {
            var sleep = await _repository.GetByIdAsync(id);
            return Ok(sleep);
        }

        [HttpPost]
        public async Task<ActionResult> PostSleep([FromBody] Sleep sleep){
            await _repository.AddAsync(sleep);
            return CreatedAtAction(nameof(GetSleepById), new { id = sleep.Id }, sleep);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Sleep>> PutSleep(int id,[FromBody] Sleep sleep)
        {
            var findSleep = await _repository.GetByIdAsync(id);
            
            if(findSleep == null)
            {
                return NotFound();
            }

            findSleep.SleepStart = sleep.SleepStart;
            findSleep.SleepEnd = sleep.SleepEnd;
            await _repository.UpdateAsync(findSleep);

            return Ok(findSleep);
        }   

        [HttpDelete("{id}")]
        public async Task<ActionResult<Sleep>> DeleteSleep(int id)
        {
            var findSleep = await _repository.GetByIdAsync(id);

            if(findSleep == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(findSleep);

            return NoContent();
        }
    }
}
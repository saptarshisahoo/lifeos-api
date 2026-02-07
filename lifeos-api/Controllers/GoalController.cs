using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using lifeos_api.Models;
using lifeos_api.Services;

namespace lifeos_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoalController : ControllerBase
    {
        private readonly IGoalService _goalService;
        private readonly ILogger<GoalController> _logger;

        public GoalController(IGoalService goalService, ILogger<GoalController> logger)
        {
            _goalService = goalService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Goal>>> Get()
        {
            var goals = await _goalService.GetAllAsync();
            return Ok(goals);
        }   

        [HttpGet("{id}", Name = "GetGoalById")]
        public async Task<ActionResult<Goal>> Get(Guid id)
        {
            var goal = await _goalService.GetByIdAsync(id);
            if (goal == null) return NotFound();
            return Ok(goal);
        }

        [HttpPost]
        public async Task<ActionResult<Goal>> Create([FromBody] Goal goal)
        {
            var created = await _goalService.CreateAsync(goal);
            return CreatedAtRoute("GetGoalById", new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Goal goal)
        {
            var updated = await _goalService.UpdateAsync(id, goal);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _goalService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
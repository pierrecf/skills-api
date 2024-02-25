using Microsoft.AspNetCore.Mvc;
using skills_api.DTO.Goal;
using skills_api.Services.Interfaces;

namespace skills_api.Controllers
{
    [Route("api/goals")]
    [ApiController]
    public class GoalController(IGoalService goalService) : ControllerBase
    {
        // GET: api/Goal
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<GoalDTO>>> GetGoals(int userId)
        {
            var goals = await goalService.GetAllGoalsAsync(userId);
            return Ok(goals);
        }
        

        // PUT: api/Goal/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGoal([FromBody] GoalDTO goalDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var goal = await goalService.UpdateGoalAsync(goalDto);
                return Ok(goal);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }

        // POST: api/Goal
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GoalDTO>> PostGoal([FromBody] CreateGoalDTO createGoalDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdGoalDto = await goalService.CreateGoalAsync(createGoalDto);
                return CreatedAtAction(null, new { id = createdGoalDto.Id }, createGoalDto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // DELETE: api/Goal/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteGoal(int id)
        {
            var goal = await goalService.DeleteGoalAsync(id);
            return Ok(goal);
        }

      
    }
}

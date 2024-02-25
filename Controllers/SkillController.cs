using Microsoft.AspNetCore.Mvc;
using skills_api.DTO.Skill;
using skills_api.Services.Interfaces;

namespace skills_api.Controllers
{
    [Route("api/skills")]
    [ApiController]
    public class SkillController(ISkillService skillService) : ControllerBase
    {
        private readonly ISkillService _skillService = skillService;

        // GET: api/Skill
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillDTO>>> GetSkills()
        {
            var skills = await _skillService.GetAllSkillsAsync();
            return Ok(skills);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkill([FromBody] UpdateSkillDTO updateSkillDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var skill = await _skillService.UpdateSkillAsync(updateSkillDto);
                return Ok(skill);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }

       
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SkillDTO>> PostSkill([FromBody] CreateSkillDTO createSkillDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdSkillDto = await _skillService.CreateSkillAsync(createSkillDto);
                return CreatedAtAction(null, new { id = createdSkillDto.Id }, createdSkillDto);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }

        // DELETE: api/Skill/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            var skill = await _skillService.DeleteSkillAsync(id);
            return Ok(skill);
        }

       
    }
}

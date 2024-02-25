using skills_api.DTO.Skill;

namespace skills_api.DTO.Goal;

public class GoalDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int UserId { get; set; }
    public SkillDTO Skill { get; set; }
}
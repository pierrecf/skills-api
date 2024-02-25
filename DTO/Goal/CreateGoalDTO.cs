namespace skills_api.DTO.Goal;


public enum GoalStatus
{
    Innactive,
    Active,
    Failed,
    Accomplished
}
public class CreateGoalDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int UserId { get; set; }
    public int SkillId { get; set; }
}

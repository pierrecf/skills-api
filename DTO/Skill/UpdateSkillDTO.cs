namespace skills_api.DTO.Skill;

public class UpdateSkillDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? CategoryId { get; set; }
}
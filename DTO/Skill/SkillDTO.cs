using skills_api.DTO.Catogory;

namespace skills_api.DTO.Skill;

public class SkillDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public CategoryDTO Category { get; set; }
}
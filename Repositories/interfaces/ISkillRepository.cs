namespace skills_api.Repositories.Interfaces;

public interface ISkillRepository
{
    Task<Skill> CreateSkillAsync(Skill skill);
    Task<IEnumerable<Skill>> GetAllSkillsAsync();
    Task<Skill?> GetSkillByIdAsync(int id);
    Task<Skill> DeleteSkillAsync(Skill skill);
    Task<Skill> EditSkillAsync(Skill skill);
}
using skills_api.DTO.Skill;

namespace skills_api.Services.Interfaces;

public interface ISkillService
{
    Task<IEnumerable<SkillDTO>> GetAllSkillsAsync();
    Task<SkillDTO> CreateSkillAsync(CreateSkillDTO createSkillDto);
    Task<SkillDTO?> DeleteSkillAsync(int id);
    Task<SkillDTO> UpdateSkillAsync(UpdateSkillDTO skillDto);
}

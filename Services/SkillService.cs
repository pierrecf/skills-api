using MapsterMapper;
using skills_api.DTO.Skill;
using skills_api.Exceptions;
using skills_api.Repositories.Interfaces;
using skills_api.Services.Interfaces;

namespace skills_api.Services;

public class SkillService(ISkillRepository skillRepository, IMapper mapper) : ISkillService
{
    public async Task<SkillDTO> CreateSkillAsync(CreateSkillDTO createSkillDto)
    {
        var skill = mapper.Map<Skill>(createSkillDto);
        var createdSkill=await skillRepository.CreateSkillAsync(skill);
        return mapper.Map<SkillDTO>(createdSkill);
    }

    public async Task<IEnumerable<SkillDTO>> GetAllSkillsAsync()
    {
        var skills = await skillRepository.GetAllSkillsAsync();
        return mapper.Map<IEnumerable<SkillDTO>>(skills);
    }

    public async Task<SkillDTO?> DeleteSkillAsync(int id)
    {
        var skill = await skillRepository.GetSkillByIdAsync(id);
        if (skill==null)
        {
            throw new NotFoundException();
        }
        var deletedSkill = await skillRepository.DeleteSkillAsync(skill);
        return mapper.Map<SkillDTO>(deletedSkill);
    }

    public async Task<SkillDTO> UpdateSkillAsync(UpdateSkillDTO skillDto)
    {
        var skill = mapper.Map<Skill>(skillDto);
        var editedSkill = await skillRepository.EditSkillAsync(skill);
        return mapper.Map<SkillDTO>(editedSkill);
    }
}
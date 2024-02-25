using Microsoft.EntityFrameworkCore;
using skills_api.Repositories.Interfaces;

namespace skills_api.Repositories;


public class SkillRepository : ISkillRepository
{
    private readonly DatabaseContext _context;

    public SkillRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Skill>> GetAllSkillsAsync()
    {
        return await Task.FromResult(_context.Skills.Include(s=>s.Category).ToList());
    }

    public async Task<Skill?> GetSkillByIdAsync(int id)
    {
        return await _context.Skills.FindAsync(id);
    }

    public async Task<Skill> CreateSkillAsync(Skill skill)
    {
        await _context.Skills.AddAsync(skill);
        await _context.SaveChangesAsync();
        return skill;
    }

    public async Task<Skill> DeleteSkillAsync(Skill skill)
    {
        _context.Skills.Remove(skill);
        await _context.SaveChangesAsync();
        return skill;
    }

    public async Task<Skill> EditSkillAsync(Skill skill)
    {
        var editedSkill = await _context.Skills.FindAsync(skill.Id);
        _context.Skills.Entry(editedSkill).CurrentValues.SetValues(skill);
        await _context.SaveChangesAsync();
        return skill;
    }
}
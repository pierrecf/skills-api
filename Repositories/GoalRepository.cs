
using Microsoft.EntityFrameworkCore;
using skills_api.DTO.Goal;
using skills_api.Repositories.Interfaces;

public class GoalRepository:IGoalRepository
{
    private readonly DatabaseContext _context;


    public GoalRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<Goal> CreateGoalAsync(Goal goal)
    {
        await _context.Goals.AddAsync(goal);
        await _context.SaveChangesAsync();
        return goal;
    }

    public async Task<IEnumerable<Goal>> GetAllGoalsAsync(int userId)
    {
        return await Task.FromResult(_context.Goals.Where(g => g.UserId == userId)
            .Include(g => g.Skill).ThenInclude(s=>s.Category).ToList());
    }

    public async Task<Goal?> GetGoalByIdAsync(int id)
    {
        return await _context.Goals.FindAsync(id);
    }

    public async Task<Goal> DeleteGoalAsync(Goal goal)
    {
        _context.Goals.Remove(goal);
        await _context.SaveChangesAsync();
        return goal;
    }

    public async Task<Goal> EditGoalAsync(Goal goal)
    {
        var editedGoal = await _context.Goals.FindAsync(goal.Id);
        _context.Goals.Entry(editedGoal).CurrentValues.SetValues(goal);
        await _context.SaveChangesAsync();
        return goal;
    }
}
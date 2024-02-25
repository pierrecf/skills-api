namespace skills_api.Repositories.Interfaces;

public interface IGoalRepository
{
    Task<Goal> CreateGoalAsync(Goal goal);
    Task<IEnumerable<Goal>> GetAllGoalsAsync(int userId);
    Task<Goal?> GetGoalByIdAsync(int id);
    Task<Goal> DeleteGoalAsync(Goal goal);
    Task<Goal> EditGoalAsync(Goal goal);
}

using skills_api.DTO.Goal;

namespace skills_api.Services.Interfaces;

public interface IGoalService
{
    Task<IEnumerable<GoalDTO>> GetAllGoalsAsync(int userId);
    Task<GoalDTO> CreateGoalAsync(CreateGoalDTO createGoalDto);
    Task<GoalDTO> DeleteGoalAsync(int id);
    Task<GoalDTO> UpdateGoalAsync(GoalDTO goalDTO);
}
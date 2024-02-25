using MapsterMapper;
using skills_api.DTO.Goal;
using skills_api.Exceptions;
using skills_api.Repositories.Interfaces;
using skills_api.Services.Interfaces;

namespace skills_api.Services;

public class GoalService(IGoalRepository goalRepository, IMapper mapper) : IGoalService
{
    public async Task<IEnumerable<GoalDTO>> GetAllGoalsAsync(int userId)
    {
        var goals = await goalRepository.GetAllGoalsAsync(userId);
        return mapper.Map<IEnumerable<GoalDTO>>(goals);
    }

    public async Task<GoalDTO> CreateGoalAsync(CreateGoalDTO createGoalDto)
    {
        var goal = mapper.Map<Goal>(createGoalDto);
        var createdGoal = await goalRepository.CreateGoalAsync(goal);
        return mapper.Map<GoalDTO>(createdGoal);
    }

    public async Task<GoalDTO?> DeleteGoalAsync(int id)
    {
        var goal = await goalRepository.GetGoalByIdAsync(id);
        if (goal == null)
        {
            throw new NotFoundException();
        }

        var deletedGoal = await goalRepository.DeleteGoalAsync(goal);
        return mapper.Map<GoalDTO>(deletedGoal);
    }

    public async Task<GoalDTO> UpdateGoalAsync(GoalDTO goalDto)
    {
        var goal = mapper.Map<Goal>(goalDto);
        var editedGoal = await goalRepository.EditGoalAsync(goal);
        return mapper.Map<GoalDTO>(editedGoal);
    }
}
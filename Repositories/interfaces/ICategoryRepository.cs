namespace skills_api.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<Category> CreateCategoryAsync(Category category);
    Task<Category> DeleteCategoryAsync(Category category);
    Task<Category> EditCategoryAsync(Category category);
}
using skills_api.Repositories.Interfaces;

namespace skills_api.Repositories;

public class CategoryRepository : ICategoryRepository
{

    private readonly DatabaseContext _context;

    public CategoryRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await Task.FromResult(_context.Categories.ToList());
    }

    public async Task<Category> CreateCategoryAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> DeleteCategoryAsync(Category category)
    {
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();

        return category;
    }

    public async Task<Category> EditCategoryAsync(Category category)
    {
        var editedCategory = await _context.Categories.FindAsync(category.Id);
        _context.Categories.Entry(editedCategory!).CurrentValues.SetValues(category);
        await _context.SaveChangesAsync();
        return category;
    }
    
}
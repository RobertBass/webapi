using webapi.Models;

namespace webapi.Services;

public class CategoryService: ICategoryService
{
    TaskContext context;

    public CategoryService(TaskContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Category> GetCategories()
    {
        if (context == null)
    {
        throw new InvalidOperationException("CONTEXT_NOT_INITIALIZED");
    }
        return context.Categories;
    }

    public async Task AddCategory(Category category)
    {
        context.Categories.Add(category);
        await context.SaveChangesAsync();
    }

    public async Task UpdateCategory(Guid categoryId, Category category)
    {
        var categoryToUpdate = context.Categories.Find(categoryId);
        if (categoryToUpdate == null)
        {
            throw new InvalidOperationException("CATEGORY_NOT_FOUND");
        }
        categoryToUpdate.Name = category.Name;
        categoryToUpdate.Description = category.Description;
        categoryToUpdate.Level = category.Level;

        await context.SaveChangesAsync();
    }


    public async Task DeleteCategory(Guid categoryId)
    {
        var categoryToDelete = context.Categories.Find(categoryId);
        if (categoryToDelete == null)
        {
            throw new InvalidOperationException("CATEGORY_NOT_FOUND");
        }
        context.Categories.Remove(categoryToDelete);
        await context.SaveChangesAsync();
    }
}

public interface ICategoryService
{
    IEnumerable<Category> GetCategories();
    Task AddCategory(Category category);
    Task UpdateCategory(Guid categoryId, Category category);
    Task DeleteCategory(Guid categoryId);
}
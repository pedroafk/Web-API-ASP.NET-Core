using Microsoft.EntityFrameworkCore;
using ProductApi.Context;
using ProductApi.Models;

namespace ProductApi.Repositories;

//Repositório acessa o banco de dados
public class CategoryRepository : ICategoryRepository {
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    //Retorna todo mundo do banco de dados
    public async Task<IEnumerable<Category>> GetAll()
    {
        return await _context.Categories.ToListAsync();
    }

    //Retorna toda a categoria com seus produtos
    public async Task<IEnumerable<Category>> GetCategoriesProducts()
    {
        return await _context.Categories.Include(p => p.Products).ToListAsync();
    }

    //Retorna uma categoria do ID específico
    public async Task<Category> GetById(int id)
    {
        return await _context.Categories.Where(c => c.CategoryId == id).FirstOrDefaultAsync();
    }

    //Cria uma categoria
    public async Task<Category> Create(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }

    //Atualiza uma categoria
    public async Task<Category> Update(Category category)
    {
        _context.Entry(category).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return category;
    }

    //Deleta uma categoria
    public async Task<Category> Delete(int id)
    {
        var category = await GetById(id);
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return category;
    }

}

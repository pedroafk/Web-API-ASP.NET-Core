using ProductApi.Models;

namespace ProductApi.Repositories;

public interface ICategoryRepository{

    //Entidades Assíncronas
    Task<IEnumerable<Category>> GetAll();

    Task<IEnumerable<Category>> GetCategoriesProducts();

    Task<Category> GetById(int id);

    Task<Category> Create(Category category);

    Task<Category> Update(Category category);

    Task<Category> Delete(int id);
}
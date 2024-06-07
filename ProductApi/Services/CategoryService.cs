using AutoMapper;
using ProductApi.DTOs;
using ProductApi.Models;
using ProductApi.Repositories;

namespace ProductApi.Services;

public class CategoryService : ICategoryService
{
    //Serviço do repositório    
    private readonly ICategoryRepository _categoryRepository;
    //Mapeamento
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper ){
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategories()
    {
        var categoriesEntity = await _categoryRepository.GetAll();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategoriesProducts()
    {
        var categoriesEntity = await _categoryRepository.GetCategoriesProducts();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
    }

    public async Task<CategoryDTO> GetCategoryById(int id)
    {
        var categoriesEntity = await _categoryRepository.GetById(id);
        return _mapper.Map<CategoryDTO>(categoriesEntity);
    }

    public async Task AddCategory(CategoryDTO categoryDto)
    {
        var categoriesEntity = _mapper.Map<Category>(categoryDto);
        await _categoryRepository.Create(categoriesEntity);
        categoryDto.CategoryId = categoriesEntity.CategoryId;
    }

    public async Task UpdateCategory(CategoryDTO categoryDto)
    {
        var categoriesEntity = _mapper.Map<Category>(categoryDto);
        await _categoryRepository.Update(categoriesEntity);
    }

    public async Task RemoveCategory(int id)
    {
        var categoriesEntity = _categoryRepository.GetById(id).Result;
        await _categoryRepository.Delete(categoriesEntity.CategoryId);
    }

}

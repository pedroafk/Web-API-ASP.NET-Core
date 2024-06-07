using AutoMapper;
using ProductApi.DTOs;
using ProductApi.Models;
using ProductApi.Repositories;

namespace ProductApi.Services;

public class ProductServices : IProductService
{
    private readonly IMapper _mapper;
    private IProductRepository _productRepository;

    public ProductServices(IMapper mapper, IProductRepository productRepository){
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        var productsEntity = await _productRepository.GetAll();
        return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
    }

    public async Task<ProductDTO> GetProductById(int id)
    {
        var productsEntity = await _productRepository.GetById(id);
        return _mapper.Map<ProductDTO>(productsEntity);
    }

    public async Task AddProduct(ProductDTO productDto)
    {
        var productsEntity = _mapper.Map<Product>(productDto);
        await _productRepository.Create(productsEntity);
        productDto.Id = productsEntity.Id;
    }

    public async Task UpdateProduct(ProductDTO productDto)
    {
        var productsEntity = _mapper.Map<Product>(productDto);
        await _productRepository.Update(productsEntity);
    }
    public async Task RemoveProduct(int id)
    {
        var productsEntity = await _productRepository.GetById(id);
        await _productRepository.Delete(productsEntity.Id);
    }

}

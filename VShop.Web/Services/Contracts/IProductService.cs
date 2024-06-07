using VShop.Web.Models;

namespace VShop.Web.Services.Contracts;

public interface IProductService
{
    Task<IEnumerable<ProductViewModel>> GetAllProducts();
    Task<ProductViewModel> FindProductById(int id);
    Task<ProductViewModel> CreateProduct(ProductViewModel productVm);
    Task<ProductViewModel> UpdateProduct(ProductViewModel productVm);
    Task<bool> DeleteProduct(int id);
}

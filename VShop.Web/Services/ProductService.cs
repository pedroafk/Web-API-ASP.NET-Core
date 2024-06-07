using System.Text.Json;
using VShop.Web.Models;
using VShop.Web.Services.Contracts;

namespace VShop.Web.Services;

public class ProductService : IProductService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly JsonSerializerOptions _options;
    private const string apiEndpoint = "/api/products/";
    private ProductViewModel productVm;
    private IEnumerable<ProductViewModel> productsVm;

    public ProductService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<IEnumerable<ProductViewModel>> GetAllProducts()
    {
        var client = _clientFactory.CreateClient("ProductApi");

        using (var response = await client.GetAsync(apiEndpoint))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                productsVm = await JsonSerializer.DeserializeAsync<IEnumerable<ProductViewModel>>(apiResponse, _options);
            }
            else
            {
                return null;
            }
        }

        return productsVm;
    }

    public Task<ProductViewModel> FindProductById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ProductViewModel> CreateProduct(ProductViewModel productVm)
    {
        throw new NotImplementedException();
    }

    public Task<ProductViewModel> UpdateProduct(ProductViewModel productVm)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteProduct(int id)
    {
        throw new NotImplementedException();
    }
}

using AutoMapper;
using ProductApi.Models;

namespace ProductApi.DTOs.Mappings;

public class MappingProfile : Profile{

    //Mapeamento
    public MappingProfile(){
        CreateMap<Category, CategoryDTO>().ReverseMap();

        CreateMap<Product, ProductDTO>().ForMember(x => x.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

        CreateMap<ProductDTO, Product>();
    }

}
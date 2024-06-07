using AutoMapper;
using ProductApi.Models;

namespace ProductApi.DTOs.Mappings;

public class MappingProfile : Profile{

    //Mapeamento
    public MappingProfile(){
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Product, ProductDTO>().ReverseMap();
    }

}
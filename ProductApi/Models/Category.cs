namespace ProductApi.Models;

public class Category{

    public int CategoryId {get; set;}

    public string? Name {get; set;}

    //Uma categoria tem uma coleção de produtos
    public ICollection<Product>? Products {get; set;}

}
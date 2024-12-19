namespace ProductApi;

public interface IProductService
{
    ICollection<ProductModel> SearchForProducts(string searchTerms);
}

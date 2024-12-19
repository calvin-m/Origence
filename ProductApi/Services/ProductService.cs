namespace ProductApi;

public class ProductService : IProductService
{
    private IProductRepository _productRepository;
    private ILogger _logger;
    public ProductService(IProductRepository productRepository, ILogger logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }
    public ICollection<ProductModel> SearchForProducts(string searchTerms)
    {
        return _productRepository.SearchForProducts(searchTerms)
    }
}

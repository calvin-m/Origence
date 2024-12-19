using Microsoft.AspNetCore.Mvc;

namespace ProductApi;

public class ProductController : ApiController
{
    private IProductService _productService;
    private ILogger _logger;

    public ProductController(IProductService productService, ILogger logger)
    {
        _productService = productService;
        _logger = logger;
    }

    // POST api/search
    ICollection<ProductModel> SearchForProducts(UserModel user)
    {
        // user should be deseriabled from the JWT token
        return _productService.SearchForProducts(user);
    }
}

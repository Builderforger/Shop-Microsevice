using Grpc.Core;
using Shared.Protos;
using ShopApi.Service;

namespace ShopApi.GrpcServices;

public class ProductGrpcServiceImpl : ProductGrpcService.ProductGrpcServiceBase
{
    private readonly IProductService _productService;

    public ProductGrpcServiceImpl(IProductService productService)
    {
        _productService = productService;
    }

    public override async Task<ProductResponse> GetProductInfo(ProductRequest request, ServerCallContext context)
    {
        if (!Guid.TryParse(request.ProductId, out var id))
            return new ProductResponse { ProductId = request.ProductId, Name = string.Empty, Price = 0 };

        var product = await _productService.GetByIdAsync(id);
        if (product == null)
            return new ProductResponse { ProductId = request.ProductId, Name = string.Empty, Price = 0 };

        return new ProductResponse
        {
            ProductId = request.ProductId,
            Name = product.Name ?? string.Empty,
            Price = (double)product.Price
        };
    }
}

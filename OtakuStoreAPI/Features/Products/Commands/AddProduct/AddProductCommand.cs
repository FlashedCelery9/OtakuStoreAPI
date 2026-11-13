using MediatR;
using OtakuStoreAPI.DataBase;
using OtakuStoreAPI.DTO_s;
using OtakuStoreAPI.Models;

namespace OtakuStoreAPI.Features.Products.Commands.AddProduct;

public record AddProductCommand(CreateProductDto Dto) : IRequest<int>;

public class AddProductCommandHandler(StoreDbContext _context)
    : IRequestHandler<AddProductCommand, int>
{
    public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;
        var product = new Product()
        {
            Title = dto.Title,
            Price = dto.Price,
            Description = dto.Description,
            ImagesUrls = dto.ImagesUrls,
            Discount = dto.Discount,
            Amount = dto.Amount,
            Category = dto.Category,
            PublicatedAt = DateTime.Now
        };
        _context.Products.Add(product);
        await _context.SaveChangesAsync(cancellationToken);
        return product.Id;
    }
}


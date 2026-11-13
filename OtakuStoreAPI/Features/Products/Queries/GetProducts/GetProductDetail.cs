using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OtakuStoreAPI.DataBase;
using OtakuStoreAPI.DTO_s;

namespace OtakuStoreAPI.Features.Products.Queries.GetProducts;

public record GetProductDetail(int Id) : IRequest<ProductDetailsDto>;


public class GetProductDetailHandler(StoreDbContext _context, IMapper mapper) : IRequestHandler<GetProductDetail, ProductDetailsDto>
{
    public async Task<ProductDetailsDto> Handle(GetProductDetail request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (product == null)
        {
            return null;
        }
        return mapper.Map<ProductDetailsDto>(product);
    }
}
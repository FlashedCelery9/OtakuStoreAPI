using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OtakuStoreAPI.DataBase;
using OtakuStoreAPI.DTO_s;

namespace OtakuStoreAPI.Features.Products.Queries.GetProducts;

public record GetProductsCommand () : IRequest<List<ShopProductDto>>;

public class GetProductsCommandHandler(StoreDbContext _context, IMapper mapper) : IRequestHandler<GetProductsCommand, List<ShopProductDto>>
{
    public async Task<List<ShopProductDto>> Handle(GetProductsCommand request, CancellationToken cancellationToken)
    {
        var result = await _context.Products.ToListAsync(cancellationToken);
        
        return mapper.Map<List<ShopProductDto>>(result);
    }

} 
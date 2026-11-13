using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OtakuStoreAPI.DataBase;
using OtakuStoreAPI.DTO_s;
using OtakuStoreAPI.Models;

namespace OtakuStoreAPI.Features.Products.Queries.GetProducts;

public record GetProductsByCategory(string category) : IRequest<List<ShopProductDto>>;

public class GetProductsByCategoryHandler(StoreDbContext _context, IMapper mapper)
    : IRequestHandler<GetProductsByCategory, List<ShopProductDto>>
{
    public async Task<List<ShopProductDto>> Handle(GetProductsByCategory request, CancellationToken cancellationToken)
    {
        var result = await _context.Products.Where(p => p.Category == request.category).ToListAsync();
        if (!result.Equals(null) || result.Count > 0)
        {
            return mapper.Map<List<ShopProductDto>>(result);
        }
        return [];
    }
}
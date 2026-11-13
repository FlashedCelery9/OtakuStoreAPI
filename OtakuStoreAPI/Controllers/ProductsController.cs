using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OtakuStoreAPI.DTO_s;
using OtakuStoreAPI.Features.Products.Commands.AddProduct;
using OtakuStoreAPI.Features.Products.Queries.GetProducts;

namespace OtakuStoreAPI.Controllers;

[ApiController]
[Route("products")]

public class ProductsController(IMediator mediator) : ControllerBase
{
    [HttpPost("create")]
    [ProducesResponseType<int>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto createProductDto, CancellationToken cancellationToken)
    {
        var res = await mediator.Send(new AddProductCommand(createProductDto), cancellationToken);
        return Ok(res);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
    {   
        var res = await mediator.Send(new GetProductsCommand(), cancellationToken);
        if (res == null)
        {
            return NotFound("Product not found");
        }
        return Ok(res);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProductDetail([FromRoute] int id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetProductDetail(id), cancellationToken);
        if (result == null)
        {
            return NotFound("Product not found");
        }
        return Ok(result);
    }

    [HttpGet("category")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProductsByCategory(string category,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetProductsByCategory(category), cancellationToken);
        if (result.Count == 0)
        {
            return NotFound("No products found");
        } 
        return Ok(result);
    }
}

using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core;

using Microsoft.AspNetCore.Mvc;
using Fina.Core.Request.Categories;
using Fina.Core.Response;
using Fina.Core.Models;
namespace Fina.Api.Endpoints.Categories;

public class GetAllCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapGet("/", HandlerAsync)
        .WithName("Categories: Get All")
        .WithDescription("Lista todas as categorias")
        .WithOrder(5)
        .Produces<Response<Category?>>();


    public static async Task<IResult> HandlerAsync(
        ICategoryHandler handler,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllCategoryRequest
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            UserId = ApiConfiguration.UserId
        };

        var response = await handler.GetAllAsync(request);
        return response.IsSucessul ?
            TypedResults.Ok(response) :
            TypedResults.BadRequest(response);
    }
}

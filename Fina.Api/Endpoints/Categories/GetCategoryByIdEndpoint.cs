
using Fina.Api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Request.Categories;
using Fina.Core.Response;


namespace Fina.Api.Endpoints.Categories;

public class GetCategoryByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    => app.MapGet("/{id}", HandlerAsync)
        .WithName("Categories: Get by Id")
        .WithDescription("exibe a categoria")
        .WithOrder(5)
        .Produces<Response<Category?>>();


    public static async Task<IResult> HandlerAsync(
        ICategoryHandler handler,
        long id)
    {
        var request = new GetCategoryByIdRequest
        {
            Id = id,
            UserId = ApiConfiguration.UserId
        };

        var response = await handler.GetByIdAsync(request);
        return response.IsSucessul ?
            TypedResults.Ok(response) :
            TypedResults.BadRequest(response);
    }
}